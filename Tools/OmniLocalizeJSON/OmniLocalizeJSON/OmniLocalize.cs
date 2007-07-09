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

namespace OmniLocalize
{
    public partial class OmniLocalize : Form
    {
        public const String newln = "\r\n";
        public const String initialDir = "C:\\Website\\omniproject.org\\Localization";
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

        /*
         * If culture==null, then use English
         */
        private FileInfo getTextFile(String culture)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (culture != null && culture.Length > 0)
                fbd.Description = "Select the directory containing other localization text.";
            else fbd.Description = "Select the directory containing English localization text.";
            fbd.SelectedPath = initialDir;
            if (fbd.ShowDialog() != DialogResult.OK) return null;


            DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
            if (culture == null || culture.Length == 0)
                culture = "en-US";
            String pattern = culture + "\\.txt";
            FileInfo[] filesAll = dir.GetFiles();
            FileInfo file = null;
            for (int i = 0; i < filesAll.Length; i++)
            {
                FileInfo fi = filesAll[i];
                String name = fi.Name;
                String rplc = Regex.Replace(name, pattern, "");
                if (rplc.Equals(""))
                    file = fi;
            }
            if(file == null)
                outputTB.Text += "ERROR: Couldn't find file." + newln;

            return file;
        }

        private void resxToCsvButton_Click(object sender, EventArgs e)
        {
            outputTB.Text = "";

            FileInfo fileDefault = getTextFile(null);
            FileInfo fileOther;
            Dictionary<String, String> rsrcDefHT = new Dictionary<String, String>();
            Dictionary<String, String> rsrcOtherHT = new Dictionary<String, String>();
            Dictionary<String, String> rsrcHT = new Dictionary<String, String>();

            if (cultureCodeTB.Text != null && cultureCodeTB.Text.Length > 0)
                fileOther = getTextFile(cultureCodeTB.Text.Trim());
            else fileOther = fileDefault;

            if (fileOther == null) return;
            if (fileDefault == null) return;

            OmniLocalize.ActiveForm.UseWaitCursor = true;
            OmniLocalize.ActiveForm.Enabled = false;

            
            {
                String filename = fileDefault.Name;
                FileInfo file = fileDefault;

                StreamReader streamReader = new StreamReader(file.FullName);
                String readStr = streamReader.ReadToEnd();
                streamReader.Close();
                StringReader sr = new StringReader(readStr);
                JsonReader jr = new JsonReader(sr); 

                while (jr.Read())
                {
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
                            val = val.Trim();

                            if (!rsrcDefHT.ContainsKey(key))
                                rsrcDefHT.Add(key, val);
                        }
                        else
                        {
                            outputTB.Text += "ERROR: Parse error." + newln;
                            break;
                        }
                        //outputTB.Text += key + " : " + val + newln;
                        //Console.WriteLine(key + " : " + val);
                    }
                }
                jr.Close();
                sr.Close();
            }

            
            if (fileOther == fileDefault)
                rsrcOtherHT = rsrcDefHT;
            else
            {
                String filename = fileOther.Name;
                FileInfo file = fileOther;

                StreamReader streamReader = new StreamReader(file.FullName);
                String readStr = streamReader.ReadToEnd();
                streamReader.Close();
                StringReader sr = new StringReader(readStr);
                JsonReader jr = new JsonReader(sr);

                while (jr.Read())
                {
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
                            val = val.Trim();

                            if (!rsrcOtherHT.ContainsKey(key))
                                rsrcOtherHT.Add(key, val);
                        }
                        else
                        {
                            outputTB.Text += "ERROR: Parse error." + newln;
                            break;
                        }
                        //outputTB.Text += key + " : " + val + newln;
                        //Console.WriteLine(key + " : " + val);
                    }
                }
                jr.Close();
                sr.Close();
            }
            
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
            sfd.FileName = "OmniResourcesJSON." + cultureCodeTB.Text;
            sfd.FileName += (cultureCodeTB.Text != null && cultureCodeTB.Text.Length > 0) ? ".csv" : "csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream stream = sfd.OpenFile();
                if (stream != null)
                {
                    StreamWriter sw = new StreamWriter(stream, Encoding.Unicode);
                    // Header & Information
                    // # Rows should == csvLinesToSkip
                    sw.Write("Note: Only translate the second column. Adapt any non-text characters\r\n");
                    sw.Write("as necessary, so the text string makes sense.\r\n");
                    sw.Write("--------------------------------------------------------------\r\n");
                    sw.Write("English Text\tTranslated Text\r\n");
                    sw.Write("--------------------------------------------------------------\r\n");
                    // Data
                    foreach (KeyValuePair<String, String> kv in rsrcHT)
                    {
                        sw.Write(kv.Key);
                        sw.Write("\t");
                        String val = kv.Value;
                        // Doublequote value if it contains delimiters or quotes
                        // Also, doublequoted values containing quotes must have their quotes doubled again
                        if (val.Contains("\t") || val.Contains("\""))
                            val = "\"" + val.Replace("\"", "\"\"") + "\"";
                        sw.Write(val);
                        sw.Write("\r\n");
                    }
                    sw.Close();
                }
            }

            OmniLocalize.ActiveForm.UseWaitCursor = false;
            OmniLocalize.ActiveForm.Enabled = true;
            outputTB.Text += "Operation Complete.";
        }

        private void csvToResxButton_Click(object sender, EventArgs e)
        {
            outputTB.Text = "Not Implemented.";
        }
    }
}