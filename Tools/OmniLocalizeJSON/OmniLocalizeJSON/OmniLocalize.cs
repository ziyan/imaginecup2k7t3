using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Resources;
using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;

namespace OmniLocalizeJSON
{
    public partial class OmniLocalize : Form
    {
        public const String newln = "\r\n";
        public const String initialDir = "C:\\Website\\omniproject.org\\Localization";
        public const String defaultCulture = "en-US";
        public const int csvLinesToSkip = 5;

        public OmniLocalize()
        {
            InitializeComponent();
        }

        private void cultureCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://msdn2.microsoft.com/en-us/library/system.globalization.cultureinfo(VS.71).aspx");
        }

        private void OmniLocalize_Load(object sender, EventArgs e)
        {

        }

        private FileInfo getCsvFile(String culture)
        {
            if (culture == null || culture.Length==0) culture = defaultCulture;

            OpenFileDialog opd = new OpenFileDialog();
            opd.Title = "Select a file containing Excel / CSV translated data.";
            opd.InitialDirectory = initialDir;
            opd.Multiselect = false;
            opd.FileName = "OmniResourcesJSON." + culture + ".csv";
            opd.Filter = "Excel/Spreadsheet Unicode Data (CSV) | *.csv";
            if (opd.ShowDialog() != DialogResult.OK) return null;

            FileInfo f = new FileInfo(opd.FileName);
            if (!f.Exists) return null;
            return f;
        }

        private FileInfo getTextFile(String culture)
        {
            if (culture == null || culture.Length == 0) culture = defaultCulture;

            OpenFileDialog opd = new OpenFileDialog();
            if (culture != null && culture.Length > 0 && !culture.Equals(defaultCulture))
                opd.Title = "Select a file containing localization text in another language.";
            else opd.Title = "Select a file containing DEFAULT ("+defaultCulture+") localization text.";
            opd.InitialDirectory = initialDir;
            opd.Multiselect = false;
            opd.FileName = culture + ".txt";
            opd.Filter = "Text Files (TXT) | *.txt";
            if (opd.ShowDialog() != DialogResult.OK) return null;

            FileInfo f = new FileInfo(opd.FileName);
            if (!f.Exists) return null;
            return f;
        }

        private FileInfo getTextFileForSave(String culture)
        {
            if (culture == null) culture = defaultCulture;

            SaveFileDialog opd = new SaveFileDialog();
            opd.Title = "Select a filename to save to.";
            opd.InitialDirectory = initialDir;
            opd.FileName = culture + ".txt";
            opd.Filter = "Text Files (TXT) | *.txt";
            if (opd.ShowDialog() != DialogResult.OK) return null;

            FileInfo f = new FileInfo(opd.FileName);
            return f;
        }

        private Dictionary<String, String> getRsrcDictionaryFromJSON(FileInfo file, bool trimWhitespace)
        {
            String filename = file.Name;

            Dictionary<String, String> rsrcHT = new Dictionary<String, String>();

            StreamReader streamReader = new StreamReader(file.FullName);
            String readStr = streamReader.ReadToEnd();
            streamReader.Close();
            StringReader sr = new StringReader(readStr);
            JsonReader jr = new JsonReader(sr);

            while (jr.Read())
            {
                if (jr.TokenType == JsonToken.StartObject)
                    continue;
                if (jr.TokenType == JsonToken.EndObject || jr.TokenType == JsonToken.EndArray)
                    break;
                if (jr.TokenType == JsonToken.PropertyName)
                {
                    String key = (String)jr.Value;
                    jr.Read();
                    String val = "";
                    if (jr.ValueType.Name.ToLower().Equals("string"))
                    {
                        val = (String)jr.Value;
                        if (trimWhitespace)
                            val = val.Trim();

                        if (!rsrcHT.ContainsKey(key))
                            rsrcHT.Add(key, val);
                    }
                    else
                    {
                        outputTB.Text += "ERROR: Parse error. (Value not String), but " + jr.ValueType.Name.ToLower() + newln;
                        break;
                    }
                    //outputTB.Text += key + " : " + val + newln;
                    //Console.WriteLine(key + " : " + val);
                }
                else
                {
                    outputTB.Text += "ERROR: Parse error. Not a property. " + jr.TokenType.ToString() + newln;
                    break;
                }
            }
            jr.Close();
            sr.Close();

            return rsrcHT;
        }

        private void resxToCsvButton_Click(object sender, EventArgs e)
        {
            bool trimWhitespace = trimWhitespaceCB.Checked;
            
            outputTB.Text = "";

            FileInfo fileDefault = getTextFile(null);
            FileInfo fileOther;
            Dictionary<String, String> rsrcDefHT = new Dictionary<String, String>();
            Dictionary<String, String> rsrcOtherHT = new Dictionary<String, String>();
            Dictionary<String, String> rsrcHT = new Dictionary<String, String>();

            if (cultureCodeTB.Text != null && cultureCodeTB.Text.Length > 0 && !cultureCodeTB.Text.Equals(defaultCulture))
                fileOther = getTextFile(cultureCodeTB.Text.Trim());
            else fileOther = fileDefault;

            if (fileOther == null) return;
            if (fileDefault == null) return;


            rsrcDefHT = getRsrcDictionaryFromJSON(fileDefault, trimWhitespace);
            if (fileOther == fileDefault)
                rsrcOtherHT = rsrcDefHT;
            else
                rsrcOtherHT = getRsrcDictionaryFromJSON(fileOther, trimWhitespace);
            
            // Merge languages and remove duplicates
            foreach (KeyValuePair<String, String> kv in rsrcDefHT)
            {
                // If it doesn't already contain this English text
                if (!rsrcHT.ContainsKey(kv.Value))
                {
                    String val;
                    if (!rsrcOtherHT.ContainsKey(kv.Key))
                    {
                        // Shouldn't happen, both resource files should have exactly the
                        // same resources
                        // But if not, English one should be more up to date
                        // So add the English resource to the other file as untranslated
                        // i.e. translated text = english text
                        val = kv.Value;
                    }
                    else val = rsrcOtherHT[kv.Key];
                    rsrcHT.Add(kv.Value, val);
                }
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = initialDir;
            sfd.Title = "Destination for Excel / CSV file";
            sfd.Filter = "Excel/Spreadsheet Unicode Data (CSV) | *.csv";
            sfd.FileName = "OmniResourcesJSON." + ((cultureCodeTB.Text == null)? "" : cultureCodeTB.Text);
            sfd.FileName += (cultureCodeTB.Text != null && cultureCodeTB.Text.Length > 0) ? ".csv" : "csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream stream = sfd.OpenFile();
                if (stream != null)
                {
                    // Note: Delimiter is Tab, not Comma
                    StreamWriter sw = new StreamWriter(stream, Encoding.Unicode);
                    // Header & Information
                    // # Rows should == csvLinesToSkip
                    sw.Write("Note: Only translate the second column. Adapt any non-text characters\r\n");
                    sw.Write("as necessary, so the text string makes sense.\r\n");
                    sw.Write("--------------------------------------------------------------\t");
                      sw.Write("--------------------------------------------------------------\r\n");
                    sw.Write("English Text\tTranslated Text\r\n");
                    sw.Write("--------------------------------------------------------------\t");
                      sw.Write("--------------------------------------------------------------\r\n");
                    // Data
                    foreach (KeyValuePair<String, String> kv in rsrcHT)
                    {
                        String key = kv.Key;
                        // Doublequote value if it contains delimiters or quotes
                        // Also, doublequoted values containing quotes must have their quotes doubled again
                        if (key.Contains("\t") || key.Contains("\""))
                            key = "\"" + key.Replace("\"", "\"\"") + "\"";
                        sw.Write(key);
                        sw.Write("\t");
                        String val = kv.Value;
                        // Doublequote value if it contains delimiters or quotes
                        // Also, doublequoted values containing quotes must have their quotes doubled again
                        if (val.Contains("\t") || val.Contains("\""))
                            val = "\"" + val.Replace("\"", "\"\"") + "\"";
                        sw.Write(val);
                        sw.Write("\r\n");
                    }
                    sw.Flush();
                    sw.Close();
                }
            }

            outputTB.Text += "Operation Complete.";
        }

        private void csvToResxButton_Click(object sender, EventArgs e)
        {
            bool trimWhitespace = trimWhitespaceCB.Checked;

            FileInfo file = getCsvFile(cultureCodeTB.Text);
            if (file == null) return;

            Dictionary<String, String> defToOtherHT = new Dictionary<String, String>();

            outputTB.Text = "";

            Stream s = file.OpenRead();
            if (s == null) return;
            
            CSVReader cr = new CSVReader(s);
            String[] temp;
            for (int i = 0; i < csvLinesToSkip; i++)
            {
                temp = cr.GetCSVLine();
            }
            String[] line;
            do
            {
                line = cr.GetCSVLine();
                if(line == null) break;
                if(line.Length < 2) continue;

                if(!defToOtherHT.ContainsKey(line[0]))
                    defToOtherHT.Add(line[0], line[1]);
            } while(line != null);
            cr.Dispose();

            FileInfo defaultFile = getTextFile(null);
            FileInfo otherFile;
            /*if (cultureCodeTB.Text == null || cultureCodeTB.Text.Length == 0)
            {
                outputTB.Text += "ERROR: Must enter a culture code." + newln;
                return;
            }*/
            otherFile = getTextFileForSave(cultureCodeTB.Text);
            if (otherFile == null) return;

            Dictionary<String, String> rsrcDefHT = getRsrcDictionaryFromJSON(defaultFile, trimWhitespace);
            if (defaultFile.FullName.ToLower().Equals(otherFile.FullName.ToLower()))
            {
                outputTB.Text += "ERROR: Cannot overwrite default localization file, it's manually filled in." + newln;
                return;
            }
            Dictionary<String, String> rsrcOtherHT;
            Dictionary<String, String> rsrcOtherFinalHT = new Dictionary<String,String>();

            if (otherFile.Exists) // Use existing entries too
                rsrcOtherHT = getRsrcDictionaryFromJSON(otherFile, trimWhitespace);
            else
                rsrcOtherHT = new Dictionary<String, String>();

            // Default resources -> other resources
            foreach (KeyValuePair<String, String> kv in rsrcDefHT)
            {
                if(!rsrcOtherHT.ContainsKey(kv.Key))
                    rsrcOtherHT.Add(kv.Key, kv.Value);
            }
            //rsrcOtherHT will contain output resources
            foreach (KeyValuePair<String, String> kv in rsrcOtherHT)
            {
                rsrcOtherFinalHT.Add(kv.Key, kv.Value);

                // Need to find a translation for all of these
                if (!rsrcDefHT.ContainsKey(kv.Key)) // shouldn't happen
                {
                    outputTB.Text += "Warning: Other lang contains key [" + kv.Key + "] while default lang does not." + newln;
                    // No default lang translation
                    // Then other lang's file already had a translation, so leave it
                    continue;
                }
                String defLangText = rsrcDefHT[kv.Key];
                // Find translation match
                if (defToOtherHT.ContainsKey(defLangText)) // Exact match
                {
                    rsrcOtherFinalHT[kv.Key] = defToOtherHT[defLangText];
                    continue;
                }
                else if(defToOtherHT.ContainsKey(defLangText.Trim()))
                {
                    // This text was whitespace trimmed
                    // Re-add the whitespace
                    // NOTE: Not exact across all languages, but close enough for this
                    String begWhitespace, endWhitespace;
                    String trimmed = defLangText.Trim();
                    int i = defLangText.IndexOf(trimmed);
                    begWhitespace = defLangText.Remove(i);
                    endWhitespace = defLangText.Substring(i + trimmed.Length);
                    rsrcOtherFinalHT[kv.Key] = begWhitespace + defToOtherHT[defLangText] + endWhitespace;
                    continue;
                }
                outputTB.Text += "ERROR: No translated match for text: " + defLangText + newln;
            }

            // Write JSON
            StringWriter sw = new StringWriter();
            JsonWriter writer = new JsonWriter(sw);
            writer.Formatting = Newtonsoft.Json.Formatting.Indented;
            writer.WriteStartObject();
            foreach (KeyValuePair<String, String> kv in rsrcOtherFinalHT)
            {
                writer.WritePropertyName(kv.Key);
                writer.WriteValue(kv.Value);
            }
            writer.WriteEndObject();
            writer.Flush();
            String text = sw.GetStringBuilder().ToString();

            StreamWriter streamWriter = new StreamWriter(otherFile.FullName);
            streamWriter.Write(text);
            streamWriter.Flush();
            streamWriter.Dispose();

            outputTB.Text += "Operation Complete.";
        }
    }
}