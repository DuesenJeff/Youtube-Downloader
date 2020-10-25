namespace Youtube_Downloader
{
    partial class Form1
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
            this.LinkLabel = new System.Windows.Forms.Label();
            this.YoutubeLinkBox = new System.Windows.Forms.TextBox();
            this.RetrieveButton = new System.Windows.Forms.Button();
            this.FormatLabel = new System.Windows.Forms.Label();
            this.FormatDropDown = new System.Windows.Forms.ComboBox();
            this.ResolutionLabel = new System.Windows.Forms.Label();
            this.ResDropDown = new System.Windows.Forms.ComboBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.VideoLocation = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // LinkLabel
            // 
            this.LinkLabel.AutoSize = true;
            this.LinkLabel.Location = new System.Drawing.Point(36, 41);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(73, 13);
            this.LinkLabel.TabIndex = 0;
            this.LinkLabel.Text = "Youtube Link:";
            // 
            // YoutubeLinkBox
            // 
            this.YoutubeLinkBox.Location = new System.Drawing.Point(39, 57);
            this.YoutubeLinkBox.Name = "YoutubeLinkBox";
            this.YoutubeLinkBox.Size = new System.Drawing.Size(423, 20);
            this.YoutubeLinkBox.TabIndex = 1;
            // 
            // RetrieveButton
            // 
            this.RetrieveButton.Location = new System.Drawing.Point(477, 57);
            this.RetrieveButton.Name = "RetrieveButton";
            this.RetrieveButton.Size = new System.Drawing.Size(114, 21);
            this.RetrieveButton.TabIndex = 2;
            this.RetrieveButton.Text = "Retrieve Link";
            this.RetrieveButton.UseVisualStyleBackColor = true;
            this.RetrieveButton.Click += new System.EventHandler(this.RetrieveButton_Click);
            // 
            // FormatLabel
            // 
            this.FormatLabel.AutoSize = true;
            this.FormatLabel.Location = new System.Drawing.Point(36, 203);
            this.FormatLabel.Name = "FormatLabel";
            this.FormatLabel.Size = new System.Drawing.Size(61, 13);
            this.FormatLabel.TabIndex = 3;
            this.FormatLabel.Text = "File Format:";
            // 
            // FormatDropDown
            // 
            this.FormatDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormatDropDown.FormattingEnabled = true;
            this.FormatDropDown.Location = new System.Drawing.Point(39, 219);
            this.FormatDropDown.Name = "FormatDropDown";
            this.FormatDropDown.Size = new System.Drawing.Size(70, 21);
            this.FormatDropDown.TabIndex = 4;
            this.FormatDropDown.SelectedIndexChanged += new System.EventHandler(this.FormatDropDown_SelectedIndexChanged);
            // 
            // ResolutionLabel
            // 
            this.ResolutionLabel.AutoSize = true;
            this.ResolutionLabel.Location = new System.Drawing.Point(36, 255);
            this.ResolutionLabel.Name = "ResolutionLabel";
            this.ResolutionLabel.Size = new System.Drawing.Size(60, 13);
            this.ResolutionLabel.TabIndex = 5;
            this.ResolutionLabel.Text = "Resolution:";
            // 
            // ResDropDown
            // 
            this.ResDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ResDropDown.FormattingEnabled = true;
            this.ResDropDown.Location = new System.Drawing.Point(39, 271);
            this.ResDropDown.Name = "ResDropDown";
            this.ResDropDown.Size = new System.Drawing.Size(121, 21);
            this.ResDropDown.TabIndex = 6;
            this.ResDropDown.SelectedIndexChanged += new System.EventHandler(this.ResDropDown_SelectedIndexChanged);
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Location = new System.Drawing.Point(36, 312);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(57, 13);
            this.FileNameLabel.TabIndex = 7;
            this.FileNameLabel.Text = "File Name:";
            // 
            // FileNameBox
            // 
            this.FileNameBox.Location = new System.Drawing.Point(39, 328);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(362, 20);
            this.FileNameBox.TabIndex = 8;
            // 
            // DownloadButton
            // 
            this.DownloadButton.Enabled = false;
            this.DownloadButton.Location = new System.Drawing.Point(39, 354);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(362, 23);
            this.DownloadButton.TabIndex = 9;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // VideoLocation
            // 
            this.VideoLocation.FileOk += new System.ComponentModel.CancelEventHandler(this.VideoLocation_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 487);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.FileNameBox);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.ResDropDown);
            this.Controls.Add(this.ResolutionLabel);
            this.Controls.Add(this.FormatDropDown);
            this.Controls.Add(this.FormatLabel);
            this.Controls.Add(this.RetrieveButton);
            this.Controls.Add(this.YoutubeLinkBox);
            this.Controls.Add(this.LinkLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LinkLabel;
        private System.Windows.Forms.TextBox YoutubeLinkBox;
        private System.Windows.Forms.Button RetrieveButton;
        private System.Windows.Forms.Label FormatLabel;
        private System.Windows.Forms.ComboBox FormatDropDown;
        private System.Windows.Forms.Label ResolutionLabel;
        private System.Windows.Forms.ComboBox ResDropDown;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.TextBox FileNameBox;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.SaveFileDialog VideoLocation;
    }
}

