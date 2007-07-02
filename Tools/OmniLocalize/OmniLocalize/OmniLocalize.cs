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

namespace OmniLocalize
{
    public partial class OmniLocalize : Form
    {
        public const String newln = "\r\n";
        public const String initialDir = "C:\\Website\\omniproject.org\\App_LocalResources";
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
         * If culture==null, then use the default resx files
         */
        private Dictionary<String, FileInfo> getResxFiles(String culture)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (culture != null && culture.Length > 0)
                fbd.Description = "Select the directory containing other language .resx files.";
            else fbd.Description = "Select the directory containing English .resx files.";
            fbd.SelectedPath = initialDir;
            if (fbd.ShowDialog() != DialogResult.OK) return null;

            DirectoryInfo dir = new DirectoryInfo(fbd.SelectedPath);
            String pattern = "*.as?x.resx";
            if (culture != null && culture.Length > 0)
                pattern = "*.as?x." + culture.Trim() + ".resx";
            FileInfo[] files = dir.GetFiles(pattern);
            outputTB.Text += files.Length + " resource files found." + newln;

            Dictionary<String, FileInfo> fileHT = new Dictionary<String, FileInfo>();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo f = files[i];
                String name = f.Name;
                String filename = Regex.Replace(name, ".as\\wx.*resx", "");
                //outputTB.Text += filename + newln;

                if (fileHT.ContainsKey(filename))
                {
                    outputTB.Text += "ERROR: Duplicate files : " + filename + newln;
                    break;
                }
                fileHT.Add(filename, files[i]);
            }

            return fileHT;
        }

        private void resxToCsvButton_Click(object sender, EventArgs e)
        {
            outputTB.Text = "";

            Dictionary<String, FileInfo> fileDefaultHT = getResxFiles(null);
            Dictionary<String, FileInfo> fileHT;
            Dictionary<String, String> rsrcDefHT = new Dictionary<String, String>();
            Dictionary<String, String> rsrcOtherHT = new Dictionary<String, String>();
            Dictionary<String, String> rsrcHT = new Dictionary<String, String>();

            if (cultureCodeTB.Text != null && cultureCodeTB.Text.Length > 0)
                fileHT = getResxFiles(cultureCodeTB.Text);
            else fileHT = fileDefaultHT;

            if (fileHT == null) return;
            if (fileDefaultHT == null) return;

            OmniLocalize.ActiveForm.UseWaitCursor = true;
            OmniLocalize.ActiveForm.Enabled = false;

            foreach (KeyValuePair<String, FileInfo> kv in fileDefaultHT)
            {
                String filename = kv.Key;
                FileInfo file = kv.Value;

                ProcessStartInfo ps = new ProcessStartInfo();
                ps.WindowStyle = ProcessWindowStyle.Hidden;
                ps.FileName = "resgen.exe";
                ps.Arguments = "\"" + file.FullName + "\" temp.resources";
                Process.Start(ps);
                while (!File.Exists("temp.resources"))
                {
                    System.Threading.Thread.Sleep(100);
                }

                ResourceReader rr = new ResourceReader("temp.resources");
                foreach (DictionaryEntry de in rr)
                {
                    if (!rsrcDefHT.ContainsKey((String)de.Key))
                        rsrcDefHT.Add((String)de.Key, (String)de.Value);
                    //outputTB.Text += "VALID: [" + (String)de.Key + "] [" + (String)de.Value + "]" + newln;
                }
                rr.Close();
                File.Delete("temp.resources");
                while (File.Exists("temp.resources"))
                {
                    System.Threading.Thread.Sleep(100);
                }
            }

            if (fileHT == fileDefaultHT)
                rsrcOtherHT = rsrcDefHT;
            else
            {
                foreach (KeyValuePair<String, FileInfo> kv in fileHT)
                {
                    String filename = kv.Key;
                    FileInfo file = kv.Value;

                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.FileName = "resgen.exe";
                    ps.Arguments = "\"" + file.FullName + "\" temp.resources";
                    Process.Start(ps);
                    while (!File.Exists("temp.resources"))
                    {
                        System.Threading.Thread.Sleep(100);
                    }

                    ResourceReader rr = new ResourceReader("temp.resources");
                    foreach (DictionaryEntry de in rr)
                    {
                        if (!rsrcOtherHT.ContainsKey((String)de.Key))
                            rsrcOtherHT.Add((String)de.Key, (String)de.Value);
                        //outputTB.Text += "VALID: [" + (String)de.Key + "] [" + (String)de.Value + "]" + newln;
                    }
                    rr.Close();
                    File.Delete("temp.resources");
                    while (File.Exists("temp.resources"))
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
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
            sfd.FileName = "OmniResources." + cultureCodeTB.Text;
            sfd.FileName += (cultureCodeTB.Text != null && cultureCodeTB.Text.Length > 0) ? ".csv" : "csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream stream = sfd.OpenFile();
                if (stream != null)
                {
                    StreamWriter sw = new StreamWriter(stream, Encoding.Unicode);
                    // Header & Information
                    // # Rows should == csvLinesToSkip
                    sw.Write("Note: Only translate the second column. Leave any non-text characters\r\n");
                    sw.Write("such as numbers, -, *, ({0}) intact in the translated text.\r\n");
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
            outputTB.Text = "Operation Complete.";
        }

        private void csvToResxButton_Click(object sender, EventArgs e)
        {
            outputTB.Text = "Not Implemented.";
        }
    }
}