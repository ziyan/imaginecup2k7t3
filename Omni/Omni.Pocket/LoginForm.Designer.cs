namespace Omni.Pocket
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.loginTabPage = new System.Windows.Forms.TabPage();
            this.exitButton = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.regUsernameLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.loginTabPage.SuspendLayout();
            this.autoTransTabPage.SuspendLayout();
            this.registerTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.exitMenuItem);
            this.menuItem1.Text = "&File";
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
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(240, 268);
            this.tabControl.TabIndex = 0;
            // 
            // loginTabPage
            // 
            this.loginTabPage.Controls.Add(this.exitButton);
            this.loginTabPage.Controls.Add(this.usernameTextBox);
            this.loginTabPage.Controls.Add(this.registerButton);
            this.loginTabPage.Controls.Add(this.loginButton);
            this.loginTabPage.Controls.Add(this.passwordLabel);
            this.loginTabPage.Controls.Add(this.usernameLabel);
            this.loginTabPage.Controls.Add(this.passwordTextBox);
            this.loginTabPage.Location = new System.Drawing.Point(0, 0);
            this.loginTabPage.Name = "loginTabPage";
            this.loginTabPage.Size = new System.Drawing.Size(240, 245);
            this.loginTabPage.Text = "Login";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(162, 213);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(72, 20);
            this.exitButton.TabIndex = 14;
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(83, 154);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(150, 21);
            this.usernameTextBox.TabIndex = 13;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(84, 213);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(72, 20);
            this.registerButton.TabIndex = 12;
            this.registerButton.Text = "Register";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(6, 213);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(72, 20);
            this.loginButton.TabIndex = 11;
            this.loginButton.Text = "Login";
            // 
            // passwordLabel
            // 
            this.passwordLabel.Location = new System.Drawing.Point(7, 182);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(71, 20);
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.Location = new System.Drawing.Point(7, 155);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(71, 20);
            this.usernameLabel.Text = "Username:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(83, 181);
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
            this.resultTextBox.Size = new System.Drawing.Size(225, 92);
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
            this.resultLabel.Location = new System.Drawing.Point(8, 125);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(55, 20);
            this.resultLabel.Text = "Result:";
            // 
            // originalLabel
            // 
            this.originalLabel.Location = new System.Drawing.Point(8, 4);
            this.originalLabel.Name = "originalLabel";
            this.originalLabel.Size = new System.Drawing.Size(55, 20);
            this.originalLabel.Text = "Original:";
            // 
            // registerTabPage
            // 
            this.registerTabPage.AutoScroll = true;
            this.registerTabPage.Controls.Add(this.textBox6);
            this.registerTabPage.Controls.Add(this.textBox5);
            this.registerTabPage.Controls.Add(this.textBox4);
            this.registerTabPage.Controls.Add(this.textBox3);
            this.registerTabPage.Controls.Add(this.textBox2);
            this.registerTabPage.Controls.Add(this.textBox1);
            this.registerTabPage.Controls.Add(this.label5);
            this.registerTabPage.Controls.Add(this.label4);
            this.registerTabPage.Controls.Add(this.label3);
            this.registerTabPage.Controls.Add(this.label2);
            this.registerTabPage.Controls.Add(this.label1);
            this.registerTabPage.Controls.Add(this.regUsernameLabel);
            this.registerTabPage.Location = new System.Drawing.Point(0, 0);
            this.registerTabPage.Name = "registerTabPage";
            this.registerTabPage.Size = new System.Drawing.Size(240, 245);
            this.registerTabPage.Text = "Register";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.Text = "Password: ";
            // 
            // regUsernameLabel
            // 
            this.regUsernameLabel.Location = new System.Drawing.Point(7, 5);
            this.regUsernameLabel.Name = "regUsernameLabel";
            this.regUsernameLabel.Size = new System.Drawing.Size(68, 20);
            this.regUsernameLabel.Text = "Username:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(81, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(152, 21);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "textBox1";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(81, 57);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(152, 21);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "textBox1";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(81, 84);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(152, 21);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "textBox1";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(81, 111);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(152, 21);
            this.textBox5.TabIndex = 2;
            this.textBox5.Text = "textBox1";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(81, 138);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(152, 73);
            this.textBox6.TabIndex = 2;
            this.textBox6.Text = "textBox1";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.Text = "Name:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.Text = "E-mail:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.Text = "Description:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "LoginForm";
            this.Text = "Omni";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.tabControl.ResumeLayout(false);
            this.loginTabPage.ResumeLayout(false);
            this.autoTransTabPage.ResumeLayout(false);
            this.registerTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem exitMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage loginTabPage;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button registerButton;
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label regUsernameLabel;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

