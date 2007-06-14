namespace Omni.Pocket
{
    partial class OmniForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.fileMenuItem = new System.Windows.Forms.MenuItem();
            this.logoutMenuItem = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.loginTabPage = new System.Windows.Forms.TabPage();
            this.langComboBox = new System.Windows.Forms.ComboBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.langLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.autoTransTabPage = new System.Windows.Forms.TabPage();
            this.translateButton = new System.Windows.Forms.Button();
            this.directionComboBox = new System.Windows.Forms.ComboBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.originalTextBox = new System.Windows.Forms.TextBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.originalLabel = new System.Windows.Forms.Label();
            this.registerTabPage = new System.Windows.Forms.TabPage();
            this.regButton = new System.Windows.Forms.Button();
            this.regCaptchaTextBox = new System.Windows.Forms.TextBox();
            this.regCaptchaBox = new System.Windows.Forms.PictureBox();
            this.regDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.regEmailTextBox = new System.Windows.Forms.TextBox();
            this.regNameTextBox = new System.Windows.Forms.TextBox();
            this.regConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.regPasswordTextBox = new System.Windows.Forms.TextBox();
            this.regUsernameTextBox = new System.Windows.Forms.TextBox();
            this.regCaptchaLabel = new System.Windows.Forms.Label();
            this.regDescriptionLabel = new System.Windows.Forms.Label();
            this.regEmailLabel = new System.Windows.Forms.Label();
            this.regNameLabel = new System.Windows.Forms.Label();
            this.regConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.regPasswordLabel = new System.Windows.Forms.Label();
            this.regUsernameLabel = new System.Windows.Forms.Label();
            this.profileTabPage = new System.Windows.Forms.TabPage();
            this.proReloadButton = new System.Windows.Forms.Button();
            this.proSaveButton = new System.Windows.Forms.Button();
            this.proDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.proEmailTextBox = new System.Windows.Forms.TextBox();
            this.proNameTextBox = new System.Windows.Forms.TextBox();
            this.proConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.proPasswordTextBox = new System.Windows.Forms.TextBox();
            this.proUsernameTextBox = new System.Windows.Forms.TextBox();
            this.proDescriptionLabel = new System.Windows.Forms.Label();
            this.proEmailLabel = new System.Windows.Forms.Label();
            this.proNameLabel = new System.Windows.Forms.Label();
            this.proPasswordLabel = new System.Windows.Forms.Label();
            this.proUsernameLabel = new System.Windows.Forms.Label();
            this.messagesTabPage = new System.Windows.Forms.TabPage();
            this.messageTabControl = new System.Windows.Forms.TabControl();
            this.inboxTabPage = new System.Windows.Forms.TabPage();
            this.replyButton = new System.Windows.Forms.Button();
            this.inboxListBox = new System.Windows.Forms.ListBox();
            this.inboxTextBox = new System.Windows.Forms.TextBox();
            this.sentTabPage = new System.Windows.Forms.TabPage();
            this.sentListBox = new System.Windows.Forms.ListBox();
            this.sentTextBox = new System.Windows.Forms.TextBox();
            this.newMessageTabPage = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.bodyTextBox = new System.Windows.Forms.TextBox();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toComboBox = new System.Windows.Forms.ComboBox();
            this.webService = new Omni.Pocket.org.omniproject.WebService();
            this.tabControl.SuspendLayout();
            this.loginTabPage.SuspendLayout();
            this.autoTransTabPage.SuspendLayout();
            this.registerTabPage.SuspendLayout();
            this.profileTabPage.SuspendLayout();
            this.messagesTabPage.SuspendLayout();
            this.messageTabControl.SuspendLayout();
            this.inboxTabPage.SuspendLayout();
            this.sentTabPage.SuspendLayout();
            this.newMessageTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.fileMenuItem);
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.MenuItems.Add(this.logoutMenuItem);
            this.fileMenuItem.MenuItems.Add(this.exitMenuItem);
            this.fileMenuItem.Text = "&File";
            // 
            // logoutMenuItem
            // 
            this.logoutMenuItem.Enabled = false;
            this.logoutMenuItem.Text = "&Logout";
            this.logoutMenuItem.Click += new System.EventHandler(this.logoutMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Text = "&Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.loginTabPage);
            this.tabControl.Controls.Add(this.autoTransTabPage);
            this.tabControl.Controls.Add(this.registerTabPage);
            this.tabControl.Controls.Add(this.profileTabPage);
            this.tabControl.Controls.Add(this.messagesTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 268);
            this.tabControl.TabIndex = 0;
            // 
            // loginTabPage
            // 
            this.loginTabPage.Controls.Add(this.langComboBox);
            this.loginTabPage.Controls.Add(this.usernameTextBox);
            this.loginTabPage.Controls.Add(this.loginButton);
            this.loginTabPage.Controls.Add(this.passwordLabel);
            this.loginTabPage.Controls.Add(this.langLabel);
            this.loginTabPage.Controls.Add(this.usernameLabel);
            this.loginTabPage.Controls.Add(this.passwordTextBox);
            this.loginTabPage.Location = new System.Drawing.Point(0, 0);
            this.loginTabPage.Name = "loginTabPage";
            this.loginTabPage.Size = new System.Drawing.Size(240, 245);
            this.loginTabPage.Text = "Login";
            // 
            // langComboBox
            // 
            this.langComboBox.Location = new System.Drawing.Point(83, 134);
            this.langComboBox.Name = "langComboBox";
            this.langComboBox.Size = new System.Drawing.Size(150, 22);
            this.langComboBox.TabIndex = 18;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(83, 162);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(150, 21);
            this.usernameTextBox.TabIndex = 13;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(161, 216);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(72, 20);
            this.loginButton.TabIndex = 11;
            this.loginButton.Text = "Login";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Location = new System.Drawing.Point(7, 190);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(71, 20);
            this.passwordLabel.Text = "Password:";
            // 
            // langLabel
            // 
            this.langLabel.Location = new System.Drawing.Point(7, 136);
            this.langLabel.Name = "langLabel";
            this.langLabel.Size = new System.Drawing.Size(71, 20);
            this.langLabel.Text = "Language:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Location = new System.Drawing.Point(7, 163);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(71, 20);
            this.usernameLabel.Text = "Username:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(83, 189);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(150, 21);
            this.passwordTextBox.TabIndex = 10;
            // 
            // autoTransTabPage
            // 
            this.autoTransTabPage.Controls.Add(this.translateButton);
            this.autoTransTabPage.Controls.Add(this.directionComboBox);
            this.autoTransTabPage.Controls.Add(this.resultTextBox);
            this.autoTransTabPage.Controls.Add(this.originalTextBox);
            this.autoTransTabPage.Controls.Add(this.resultLabel);
            this.autoTransTabPage.Controls.Add(this.originalLabel);
            this.autoTransTabPage.Location = new System.Drawing.Point(0, 0);
            this.autoTransTabPage.Name = "autoTransTabPage";
            this.autoTransTabPage.Size = new System.Drawing.Size(232, 242);
            this.autoTransTabPage.Text = "Automatic Translation";
            // 
            // translateButton
            // 
            this.translateButton.Location = new System.Drawing.Point(161, 124);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(72, 20);
            this.translateButton.TabIndex = 3;
            this.translateButton.Text = "Translate";
            // 
            // directionComboBox
            // 
            this.directionComboBox.Items.Add("U.S. English To Simplified Chinese");
            this.directionComboBox.Items.Add("Simplified Chinese To U.S. English");
            this.directionComboBox.Location = new System.Drawing.Point(8, 96);
            this.directionComboBox.Name = "directionComboBox";
            this.directionComboBox.Size = new System.Drawing.Size(226, 22);
            this.directionComboBox.TabIndex = 2;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(8, 150);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(225, 82);
            this.resultTextBox.TabIndex = 1;
            // 
            // originalTextBox
            // 
            this.originalTextBox.Location = new System.Drawing.Point(8, 27);
            this.originalTextBox.Multiline = true;
            this.originalTextBox.Name = "originalTextBox";
            this.originalTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.originalTextBox.Size = new System.Drawing.Size(225, 63);
            this.originalTextBox.TabIndex = 1;
            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(8, 124);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(147, 20);
            this.resultLabel.Text = "Result:";
            // 
            // originalLabel
            // 
            this.originalLabel.Location = new System.Drawing.Point(8, 4);
            this.originalLabel.Name = "originalLabel";
            this.originalLabel.Size = new System.Drawing.Size(225, 20);
            this.originalLabel.Text = "Original:";
            // 
            // registerTabPage
            // 
            this.registerTabPage.Controls.Add(this.regButton);
            this.registerTabPage.Controls.Add(this.regCaptchaTextBox);
            this.registerTabPage.Controls.Add(this.regCaptchaBox);
            this.registerTabPage.Controls.Add(this.regDescriptionTextBox);
            this.registerTabPage.Controls.Add(this.regEmailTextBox);
            this.registerTabPage.Controls.Add(this.regNameTextBox);
            this.registerTabPage.Controls.Add(this.regConfirmPasswordTextBox);
            this.registerTabPage.Controls.Add(this.regPasswordTextBox);
            this.registerTabPage.Controls.Add(this.regUsernameTextBox);
            this.registerTabPage.Controls.Add(this.regCaptchaLabel);
            this.registerTabPage.Controls.Add(this.regDescriptionLabel);
            this.registerTabPage.Controls.Add(this.regEmailLabel);
            this.registerTabPage.Controls.Add(this.regNameLabel);
            this.registerTabPage.Controls.Add(this.regConfirmPasswordLabel);
            this.registerTabPage.Controls.Add(this.regPasswordLabel);
            this.registerTabPage.Controls.Add(this.regUsernameLabel);
            this.registerTabPage.Location = new System.Drawing.Point(0, 0);
            this.registerTabPage.Name = "registerTabPage";
            this.registerTabPage.Size = new System.Drawing.Size(232, 242);
            this.registerTabPage.Text = "Register";
            // 
            // regButton
            // 
            this.regButton.Location = new System.Drawing.Point(161, 218);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(72, 20);
            this.regButton.TabIndex = 13;
            this.regButton.Text = "Register";
            // 
            // regCaptchaTextBox
            // 
            this.regCaptchaTextBox.Location = new System.Drawing.Point(7, 191);
            this.regCaptchaTextBox.MaxLength = 5;
            this.regCaptchaTextBox.Name = "regCaptchaTextBox";
            this.regCaptchaTextBox.Size = new System.Drawing.Size(68, 21);
            this.regCaptchaTextBox.TabIndex = 11;
            // 
            // regCaptchaBox
            // 
            this.regCaptchaBox.Location = new System.Drawing.Point(81, 155);
            this.regCaptchaBox.Name = "regCaptchaBox";
            this.regCaptchaBox.Size = new System.Drawing.Size(152, 57);
            // 
            // regDescriptionTextBox
            // 
            this.regDescriptionTextBox.Location = new System.Drawing.Point(81, 111);
            this.regDescriptionTextBox.Multiline = true;
            this.regDescriptionTextBox.Name = "regDescriptionTextBox";
            this.regDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.regDescriptionTextBox.Size = new System.Drawing.Size(152, 38);
            this.regDescriptionTextBox.TabIndex = 2;
            // 
            // regEmailTextBox
            // 
            this.regEmailTextBox.Location = new System.Drawing.Point(81, 84);
            this.regEmailTextBox.MaxLength = 255;
            this.regEmailTextBox.Name = "regEmailTextBox";
            this.regEmailTextBox.Size = new System.Drawing.Size(152, 21);
            this.regEmailTextBox.TabIndex = 2;
            // 
            // regNameTextBox
            // 
            this.regNameTextBox.Location = new System.Drawing.Point(81, 57);
            this.regNameTextBox.MaxLength = 50;
            this.regNameTextBox.Name = "regNameTextBox";
            this.regNameTextBox.Size = new System.Drawing.Size(152, 21);
            this.regNameTextBox.TabIndex = 2;
            // 
            // regConfirmPasswordTextBox
            // 
            this.regConfirmPasswordTextBox.Location = new System.Drawing.Point(158, 30);
            this.regConfirmPasswordTextBox.Name = "regConfirmPasswordTextBox";
            this.regConfirmPasswordTextBox.PasswordChar = '*';
            this.regConfirmPasswordTextBox.Size = new System.Drawing.Size(75, 21);
            this.regConfirmPasswordTextBox.TabIndex = 2;
            // 
            // regPasswordTextBox
            // 
            this.regPasswordTextBox.Location = new System.Drawing.Point(81, 30);
            this.regPasswordTextBox.Name = "regPasswordTextBox";
            this.regPasswordTextBox.PasswordChar = '*';
            this.regPasswordTextBox.Size = new System.Drawing.Size(75, 21);
            this.regPasswordTextBox.TabIndex = 2;
            // 
            // regUsernameTextBox
            // 
            this.regUsernameTextBox.Location = new System.Drawing.Point(81, 3);
            this.regUsernameTextBox.MaxLength = 50;
            this.regUsernameTextBox.Name = "regUsernameTextBox";
            this.regUsernameTextBox.Size = new System.Drawing.Size(152, 21);
            this.regUsernameTextBox.TabIndex = 2;
            // 
            // regCaptchaLabel
            // 
            this.regCaptchaLabel.Location = new System.Drawing.Point(7, 155);
            this.regCaptchaLabel.Name = "regCaptchaLabel";
            this.regCaptchaLabel.Size = new System.Drawing.Size(71, 33);
            this.regCaptchaLabel.Text = "What is in the picture?";
            // 
            // regDescriptionLabel
            // 
            this.regDescriptionLabel.Location = new System.Drawing.Point(7, 112);
            this.regDescriptionLabel.Name = "regDescriptionLabel";
            this.regDescriptionLabel.Size = new System.Drawing.Size(71, 20);
            this.regDescriptionLabel.Text = "Description:";
            // 
            // regEmailLabel
            // 
            this.regEmailLabel.Location = new System.Drawing.Point(7, 85);
            this.regEmailLabel.Name = "regEmailLabel";
            this.regEmailLabel.Size = new System.Drawing.Size(71, 20);
            this.regEmailLabel.Text = "E-mail:";
            // 
            // regNameLabel
            // 
            this.regNameLabel.Location = new System.Drawing.Point(7, 58);
            this.regNameLabel.Name = "regNameLabel";
            this.regNameLabel.Size = new System.Drawing.Size(71, 20);
            this.regNameLabel.Text = "Name:";
            // 
            // regConfirmPasswordLabel
            // 
            this.regConfirmPasswordLabel.Location = new System.Drawing.Point(7, 57);
            this.regConfirmPasswordLabel.Name = "regConfirmPasswordLabel";
            this.regConfirmPasswordLabel.Size = new System.Drawing.Size(71, 20);
            // 
            // regPasswordLabel
            // 
            this.regPasswordLabel.Location = new System.Drawing.Point(7, 31);
            this.regPasswordLabel.Name = "regPasswordLabel";
            this.regPasswordLabel.Size = new System.Drawing.Size(71, 20);
            this.regPasswordLabel.Text = "Password: ";
            // 
            // regUsernameLabel
            // 
            this.regUsernameLabel.Location = new System.Drawing.Point(7, 5);
            this.regUsernameLabel.Name = "regUsernameLabel";
            this.regUsernameLabel.Size = new System.Drawing.Size(68, 20);
            this.regUsernameLabel.Text = "Username:";
            // 
            // profileTabPage
            // 
            this.profileTabPage.Controls.Add(this.proReloadButton);
            this.profileTabPage.Controls.Add(this.proSaveButton);
            this.profileTabPage.Controls.Add(this.proDescriptionTextBox);
            this.profileTabPage.Controls.Add(this.proEmailTextBox);
            this.profileTabPage.Controls.Add(this.proNameTextBox);
            this.profileTabPage.Controls.Add(this.proConfirmPasswordTextBox);
            this.profileTabPage.Controls.Add(this.proPasswordTextBox);
            this.profileTabPage.Controls.Add(this.proUsernameTextBox);
            this.profileTabPage.Controls.Add(this.proDescriptionLabel);
            this.profileTabPage.Controls.Add(this.proEmailLabel);
            this.profileTabPage.Controls.Add(this.proNameLabel);
            this.profileTabPage.Controls.Add(this.proPasswordLabel);
            this.profileTabPage.Controls.Add(this.proUsernameLabel);
            this.profileTabPage.Location = new System.Drawing.Point(0, 0);
            this.profileTabPage.Name = "profileTabPage";
            this.profileTabPage.Size = new System.Drawing.Size(232, 242);
            this.profileTabPage.Text = "Profile";
            // 
            // proReloadButton
            // 
            this.proReloadButton.Location = new System.Drawing.Point(84, 220);
            this.proReloadButton.Name = "proReloadButton";
            this.proReloadButton.Size = new System.Drawing.Size(72, 20);
            this.proReloadButton.TabIndex = 25;
            this.proReloadButton.Text = "Reload";
            // 
            // proSaveButton
            // 
            this.proSaveButton.Location = new System.Drawing.Point(161, 220);
            this.proSaveButton.Name = "proSaveButton";
            this.proSaveButton.Size = new System.Drawing.Size(72, 20);
            this.proSaveButton.TabIndex = 25;
            this.proSaveButton.Text = "Save";
            // 
            // proDescriptionTextBox
            // 
            this.proDescriptionTextBox.Location = new System.Drawing.Point(81, 113);
            this.proDescriptionTextBox.Multiline = true;
            this.proDescriptionTextBox.Name = "proDescriptionTextBox";
            this.proDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.proDescriptionTextBox.Size = new System.Drawing.Size(152, 101);
            this.proDescriptionTextBox.TabIndex = 23;
            // 
            // proEmailTextBox
            // 
            this.proEmailTextBox.Location = new System.Drawing.Point(81, 86);
            this.proEmailTextBox.MaxLength = 255;
            this.proEmailTextBox.Name = "proEmailTextBox";
            this.proEmailTextBox.Size = new System.Drawing.Size(152, 21);
            this.proEmailTextBox.TabIndex = 24;
            // 
            // proNameTextBox
            // 
            this.proNameTextBox.Location = new System.Drawing.Point(81, 59);
            this.proNameTextBox.MaxLength = 50;
            this.proNameTextBox.Name = "proNameTextBox";
            this.proNameTextBox.Size = new System.Drawing.Size(152, 21);
            this.proNameTextBox.TabIndex = 19;
            // 
            // proConfirmPasswordTextBox
            // 
            this.proConfirmPasswordTextBox.Location = new System.Drawing.Point(158, 32);
            this.proConfirmPasswordTextBox.Name = "proConfirmPasswordTextBox";
            this.proConfirmPasswordTextBox.PasswordChar = '*';
            this.proConfirmPasswordTextBox.Size = new System.Drawing.Size(75, 21);
            this.proConfirmPasswordTextBox.TabIndex = 20;
            // 
            // proPasswordTextBox
            // 
            this.proPasswordTextBox.Location = new System.Drawing.Point(81, 32);
            this.proPasswordTextBox.Name = "proPasswordTextBox";
            this.proPasswordTextBox.PasswordChar = '*';
            this.proPasswordTextBox.Size = new System.Drawing.Size(75, 21);
            this.proPasswordTextBox.TabIndex = 21;
            // 
            // proUsernameTextBox
            // 
            this.proUsernameTextBox.Enabled = false;
            this.proUsernameTextBox.Location = new System.Drawing.Point(81, 5);
            this.proUsernameTextBox.MaxLength = 50;
            this.proUsernameTextBox.Name = "proUsernameTextBox";
            this.proUsernameTextBox.ReadOnly = true;
            this.proUsernameTextBox.Size = new System.Drawing.Size(152, 21);
            this.proUsernameTextBox.TabIndex = 22;
            // 
            // proDescriptionLabel
            // 
            this.proDescriptionLabel.Location = new System.Drawing.Point(7, 114);
            this.proDescriptionLabel.Name = "proDescriptionLabel";
            this.proDescriptionLabel.Size = new System.Drawing.Size(71, 20);
            this.proDescriptionLabel.Text = "Description:";
            // 
            // proEmailLabel
            // 
            this.proEmailLabel.Location = new System.Drawing.Point(7, 87);
            this.proEmailLabel.Name = "proEmailLabel";
            this.proEmailLabel.Size = new System.Drawing.Size(71, 20);
            this.proEmailLabel.Text = "E-mail:";
            // 
            // proNameLabel
            // 
            this.proNameLabel.Location = new System.Drawing.Point(7, 60);
            this.proNameLabel.Name = "proNameLabel";
            this.proNameLabel.Size = new System.Drawing.Size(71, 20);
            this.proNameLabel.Text = "Name:";
            // 
            // proPasswordLabel
            // 
            this.proPasswordLabel.Location = new System.Drawing.Point(7, 33);
            this.proPasswordLabel.Name = "proPasswordLabel";
            this.proPasswordLabel.Size = new System.Drawing.Size(71, 20);
            this.proPasswordLabel.Text = "Password: ";
            // 
            // proUsernameLabel
            // 
            this.proUsernameLabel.Location = new System.Drawing.Point(7, 7);
            this.proUsernameLabel.Name = "proUsernameLabel";
            this.proUsernameLabel.Size = new System.Drawing.Size(68, 20);
            this.proUsernameLabel.Text = "Username:";
            // 
            // messagesTabPage
            // 
            this.messagesTabPage.Controls.Add(this.messageTabControl);
            this.messagesTabPage.Location = new System.Drawing.Point(0, 0);
            this.messagesTabPage.Name = "messagesTabPage";
            this.messagesTabPage.Size = new System.Drawing.Size(232, 242);
            this.messagesTabPage.Text = "Messages";
            // 
            // messageTabControl
            // 
            this.messageTabControl.Controls.Add(this.inboxTabPage);
            this.messageTabControl.Controls.Add(this.sentTabPage);
            this.messageTabControl.Controls.Add(this.newMessageTabPage);
            this.messageTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageTabControl.Location = new System.Drawing.Point(0, 0);
            this.messageTabControl.Name = "messageTabControl";
            this.messageTabControl.SelectedIndex = 0;
            this.messageTabControl.Size = new System.Drawing.Size(232, 242);
            this.messageTabControl.TabIndex = 2;
            // 
            // inboxTabPage
            // 
            this.inboxTabPage.Controls.Add(this.replyButton);
            this.inboxTabPage.Controls.Add(this.inboxListBox);
            this.inboxTabPage.Controls.Add(this.inboxTextBox);
            this.inboxTabPage.Location = new System.Drawing.Point(0, 0);
            this.inboxTabPage.Name = "inboxTabPage";
            this.inboxTabPage.Size = new System.Drawing.Size(232, 219);
            this.inboxTabPage.Text = "Inbox";
            // 
            // replyButton
            // 
            this.replyButton.Enabled = false;
            this.replyButton.Location = new System.Drawing.Point(161, 190);
            this.replyButton.Name = "replyButton";
            this.replyButton.Size = new System.Drawing.Size(72, 20);
            this.replyButton.TabIndex = 3;
            this.replyButton.Text = "Reply";
            // 
            // inboxListBox
            // 
            this.inboxListBox.Items.Add("dfsa");
            this.inboxListBox.Items.Add("fdsaf");
            this.inboxListBox.Items.Add("fdsaf");
            this.inboxListBox.Location = new System.Drawing.Point(7, 7);
            this.inboxListBox.Name = "inboxListBox";
            this.inboxListBox.Size = new System.Drawing.Size(226, 86);
            this.inboxListBox.TabIndex = 2;
            // 
            // inboxTextBox
            // 
            this.inboxTextBox.Location = new System.Drawing.Point(7, 99);
            this.inboxTextBox.Multiline = true;
            this.inboxTextBox.Name = "inboxTextBox";
            this.inboxTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inboxTextBox.Size = new System.Drawing.Size(226, 85);
            this.inboxTextBox.TabIndex = 1;
            // 
            // sentTabPage
            // 
            this.sentTabPage.Controls.Add(this.sentListBox);
            this.sentTabPage.Controls.Add(this.sentTextBox);
            this.sentTabPage.Location = new System.Drawing.Point(0, 0);
            this.sentTabPage.Name = "sentTabPage";
            this.sentTabPage.Size = new System.Drawing.Size(224, 216);
            this.sentTabPage.Text = "Sent";
            // 
            // sentListBox
            // 
            this.sentListBox.Items.Add("dfsa");
            this.sentListBox.Items.Add("fdsaf");
            this.sentListBox.Items.Add("fdsaf");
            this.sentListBox.Location = new System.Drawing.Point(7, 7);
            this.sentListBox.Name = "sentListBox";
            this.sentListBox.Size = new System.Drawing.Size(226, 86);
            this.sentListBox.TabIndex = 4;
            // 
            // sentTextBox
            // 
            this.sentTextBox.Location = new System.Drawing.Point(7, 99);
            this.sentTextBox.Multiline = true;
            this.sentTextBox.Name = "sentTextBox";
            this.sentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sentTextBox.Size = new System.Drawing.Size(226, 110);
            this.sentTextBox.TabIndex = 3;
            // 
            // newMessageTabPage
            // 
            this.newMessageTabPage.Controls.Add(this.saveButton);
            this.newMessageTabPage.Controls.Add(this.sendButton);
            this.newMessageTabPage.Controls.Add(this.bodyTextBox);
            this.newMessageTabPage.Controls.Add(this.toTextBox);
            this.newMessageTabPage.Controls.Add(this.fromTextBox);
            this.newMessageTabPage.Controls.Add(this.subjectLabel);
            this.newMessageTabPage.Controls.Add(this.label1);
            this.newMessageTabPage.Controls.Add(this.toComboBox);
            this.newMessageTabPage.Location = new System.Drawing.Point(0, 0);
            this.newMessageTabPage.Name = "newMessageTabPage";
            this.newMessageTabPage.Size = new System.Drawing.Size(224, 216);
            this.newMessageTabPage.Text = "New Message";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(83, 188);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(72, 20);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(161, 188);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(72, 20);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Location = new System.Drawing.Point(7, 62);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.bodyTextBox.Size = new System.Drawing.Size(226, 120);
            this.bodyTextBox.TabIndex = 3;
            // 
            // toTextBox
            // 
            this.toTextBox.Location = new System.Drawing.Point(148, 7);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(85, 21);
            this.toTextBox.TabIndex = 2;
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(63, 35);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(170, 21);
            this.fromTextBox.TabIndex = 2;
            // 
            // subjectLabel
            // 
            this.subjectLabel.Location = new System.Drawing.Point(7, 36);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(50, 20);
            this.subjectLabel.Text = "Subject:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.Text = "To:";
            // 
            // toComboBox
            // 
            this.toComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.toComboBox.Location = new System.Drawing.Point(63, 7);
            this.toComboBox.Name = "toComboBox";
            this.toComboBox.Size = new System.Drawing.Size(79, 22);
            this.toComboBox.TabIndex = 0;
            // 
            // webService
            // 
            this.webService.AllowAutoRedirect = false;
            this.webService.ConnectionGroupName = "";
            this.webService.Credentials = null;
            this.webService.PreAuthenticate = false;
            this.webService.Proxy = null;
            this.webService.RequestEncoding = null;
            this.webService.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Default;
            this.webService.Timeout = 100000;
            this.webService.Url = "http://24.19.97.171/Service/WebService.asmx";
            this.webService.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; MS Web Services Client Protocol 2.0.50727.312)" +
                "";
            // 
            // OmniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl);
            this.KeyPreview = true;
            this.Menu = this.mainMenu;
            this.Name = "OmniForm";
            this.Text = "Omni";
            this.Load += new System.EventHandler(this.OmniForm_Load);
            this.tabControl.ResumeLayout(false);
            this.loginTabPage.ResumeLayout(false);
            this.autoTransTabPage.ResumeLayout(false);
            this.registerTabPage.ResumeLayout(false);
            this.profileTabPage.ResumeLayout(false);
            this.messagesTabPage.ResumeLayout(false);
            this.messageTabControl.ResumeLayout(false);
            this.inboxTabPage.ResumeLayout(false);
            this.sentTabPage.ResumeLayout(false);
            this.newMessageTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem fileMenuItem;
        private System.Windows.Forms.MenuItem exitMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage loginTabPage;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TabPage autoTransTabPage;
        private System.Windows.Forms.ComboBox directionComboBox;
        private System.Windows.Forms.TextBox originalTextBox;
        private System.Windows.Forms.Label originalLabel;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TabPage registerTabPage;
        private System.Windows.Forms.TextBox regUsernameTextBox;
        private System.Windows.Forms.Label regPasswordLabel;
        private System.Windows.Forms.Label regUsernameLabel;
        private System.Windows.Forms.TextBox regDescriptionTextBox;
        private System.Windows.Forms.TextBox regEmailTextBox;
        private System.Windows.Forms.TextBox regNameTextBox;
        private System.Windows.Forms.TextBox regConfirmPasswordTextBox;
        private System.Windows.Forms.TextBox regPasswordTextBox;
        private System.Windows.Forms.Label regDescriptionLabel;
        private System.Windows.Forms.Label regEmailLabel;
        private System.Windows.Forms.Label regNameLabel;
        private System.Windows.Forms.Label regConfirmPasswordLabel;
        private System.Windows.Forms.TextBox regCaptchaTextBox;
        private System.Windows.Forms.PictureBox regCaptchaBox;
        private System.Windows.Forms.Button regButton;
        private System.Windows.Forms.Label regCaptchaLabel;
        private System.Windows.Forms.ComboBox langComboBox;
        private System.Windows.Forms.Label langLabel;
        private System.Windows.Forms.TabPage profileTabPage;
        private System.Windows.Forms.Button proReloadButton;
        private System.Windows.Forms.Button proSaveButton;
        private System.Windows.Forms.TextBox proDescriptionTextBox;
        private System.Windows.Forms.TextBox proEmailTextBox;
        private System.Windows.Forms.TextBox proNameTextBox;
        private System.Windows.Forms.TextBox proConfirmPasswordTextBox;
        private System.Windows.Forms.TextBox proPasswordTextBox;
        private System.Windows.Forms.TextBox proUsernameTextBox;
        private System.Windows.Forms.Label proDescriptionLabel;
        private System.Windows.Forms.Label proEmailLabel;
        private System.Windows.Forms.Label proNameLabel;
        private System.Windows.Forms.Label proPasswordLabel;
        private System.Windows.Forms.Label proUsernameLabel;
        private System.Windows.Forms.TabPage messagesTabPage;
        private System.Windows.Forms.TabControl messageTabControl;
        private System.Windows.Forms.TabPage inboxTabPage;
        private System.Windows.Forms.Button replyButton;
        private System.Windows.Forms.ListBox inboxListBox;
        private System.Windows.Forms.TextBox inboxTextBox;
        private System.Windows.Forms.TabPage sentTabPage;
        private System.Windows.Forms.ListBox sentListBox;
        private System.Windows.Forms.TextBox sentTextBox;
        private System.Windows.Forms.TabPage newMessageTabPage;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox bodyTextBox;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox toComboBox;
        private System.Windows.Forms.MenuItem logoutMenuItem;
        private Omni.Pocket.org.omniproject.WebService webService;
    }
}

