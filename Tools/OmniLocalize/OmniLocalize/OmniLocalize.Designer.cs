namespace OmniLocalize
{
    partial class OmniLocalize
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.cultureCodeLink = new System.Windows.Forms.LinkLabel();
            this.cultureCodeTB = new System.Windows.Forms.TextBox();
            this.resxToCsvButton = new System.Windows.Forms.Button();
            this.csvToResxButton = new System.Windows.Forms.Button();
            this.outputTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cultureCodeLink
            // 
            this.cultureCodeLink.AutoSize = true;
            this.cultureCodeLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cultureCodeLink.Location = new System.Drawing.Point(26, 20);
            this.cultureCodeLink.Name = "cultureCodeLink";
            this.cultureCodeLink.Size = new System.Drawing.Size(88, 16);
            this.cultureCodeLink.TabIndex = 0;
            this.cultureCodeLink.TabStop = true;
            this.cultureCodeLink.Text = "Culture Code:";
            this.cultureCodeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cultureCodeLink_LinkClicked);
            // 
            // cultureCodeTB
            // 
            this.cultureCodeTB.Location = new System.Drawing.Point(120, 19);
            this.cultureCodeTB.Name = "cultureCodeTB";
            this.cultureCodeTB.Size = new System.Drawing.Size(144, 20);
            this.cultureCodeTB.TabIndex = 1;
            // 
            // resxToCsvButton
            // 
            this.resxToCsvButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resxToCsvButton.Location = new System.Drawing.Point(30, 52);
            this.resxToCsvButton.Name = "resxToCsvButton";
            this.resxToCsvButton.Size = new System.Drawing.Size(242, 39);
            this.resxToCsvButton.TabIndex = 2;
            this.resxToCsvButton.Text = "Resource Files to CSV (Excel)";
            this.resxToCsvButton.UseVisualStyleBackColor = true;
            this.resxToCsvButton.Click += new System.EventHandler(this.resxToCsvButton_Click);
            // 
            // csvToResxButton
            // 
            this.csvToResxButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvToResxButton.Location = new System.Drawing.Point(33, 106);
            this.csvToResxButton.Name = "csvToResxButton";
            this.csvToResxButton.Size = new System.Drawing.Size(238, 44);
            this.csvToResxButton.TabIndex = 3;
            this.csvToResxButton.Text = "CSV (Excel) to Resource Files";
            this.csvToResxButton.UseVisualStyleBackColor = true;
            this.csvToResxButton.Click += new System.EventHandler(this.csvToResxButton_Click);
            // 
            // outputTB
            // 
            this.outputTB.Location = new System.Drawing.Point(33, 188);
            this.outputTB.Multiline = true;
            this.outputTB.Name = "outputTB";
            this.outputTB.ReadOnly = true;
            this.outputTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTB.Size = new System.Drawing.Size(238, 102);
            this.outputTB.TabIndex = 4;
            // 
            // OmniLocalize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 321);
            this.Controls.Add(this.outputTB);
            this.Controls.Add(this.csvToResxButton);
            this.Controls.Add(this.resxToCsvButton);
            this.Controls.Add(this.cultureCodeTB);
            this.Controls.Add(this.cultureCodeLink);
            this.Name = "OmniLocalize";
            this.Text = "Omni Localizer";
            this.Load += new System.EventHandler(this.OmniLocalize_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel cultureCodeLink;
        private System.Windows.Forms.TextBox cultureCodeTB;
        private System.Windows.Forms.Button resxToCsvButton;
        private System.Windows.Forms.Button csvToResxButton;
        private System.Windows.Forms.TextBox outputTB;
    }
}

