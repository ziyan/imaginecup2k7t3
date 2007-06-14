using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Omni.Pocket
{
    public partial class OmniForm : Form
    {
        public OmniForm()
        {
            InitializeComponent();
            webService.Initialize();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            resetTabPages(true);
        }

        private void OmniForm_Load(object sender, EventArgs e)
        {
            resetTabPages(false);
        }

        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            resetTabPages(false);
        }

        private void resetTabPages(bool isLoggedIn)
        {
            if (isLoggedIn)
            {
                tabControl.TabPages.Clear();
                tabControl.TabPages.Add(autoTransTabPage);
                tabControl.TabPages.Add(messagesTabPage);
                tabControl.TabPages.Add(profileTabPage);
                logoutMenuItem.Enabled = true;
            }
            else
            {
                tabControl.TabPages.Clear();
                tabControl.TabPages.Add(loginTabPage);
                tabControl.TabPages.Add(autoTransTabPage);
                tabControl.TabPages.Add(registerTabPage);
                logoutMenuItem.Enabled = false;
            }
        }
    }
}