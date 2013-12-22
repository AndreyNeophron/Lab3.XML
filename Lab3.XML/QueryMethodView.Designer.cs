namespace Lab3.XML
{
    partial class QueryMethodView
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
            this.queryMethodInvite = new System.Windows.Forms.Label();
            this.linqMethodButton = new System.Windows.Forms.Button();
            this.xPathMethodButton = new System.Windows.Forms.Button();
            this.simpleMethodButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // queryMethodInvite
            // 
            this.queryMethodInvite.AutoSize = true;
            this.queryMethodInvite.Location = new System.Drawing.Point(12, 9);
            this.queryMethodInvite.Name = "queryMethodInvite";
            this.queryMethodInvite.Size = new System.Drawing.Size(123, 13);
            this.queryMethodInvite.TabIndex = 0;
            this.queryMethodInvite.Text = "Оберіть спосіб пошуку:";
            // 
            // linqMethodButton
            // 
            this.linqMethodButton.Location = new System.Drawing.Point(12, 41);
            this.linqMethodButton.Name = "linqMethodButton";
            this.linqMethodButton.Size = new System.Drawing.Size(75, 23);
            this.linqMethodButton.TabIndex = 1;
            this.linqMethodButton.Text = "Linq";
            this.linqMethodButton.UseVisualStyleBackColor = true;
            this.linqMethodButton.Click += new System.EventHandler(this.linqMethodButton_Click);
            // 
            // xPathMethodButton
            // 
            this.xPathMethodButton.Location = new System.Drawing.Point(93, 41);
            this.xPathMethodButton.Name = "xPathMethodButton";
            this.xPathMethodButton.Size = new System.Drawing.Size(75, 23);
            this.xPathMethodButton.TabIndex = 2;
            this.xPathMethodButton.Text = "XPath";
            this.xPathMethodButton.UseVisualStyleBackColor = true;
            this.xPathMethodButton.Click += new System.EventHandler(this.xPathMethodButton_Click);
            // 
            // simpleMethodButton
            // 
            this.simpleMethodButton.Location = new System.Drawing.Point(174, 41);
            this.simpleMethodButton.Name = "simpleMethodButton";
            this.simpleMethodButton.Size = new System.Drawing.Size(75, 23);
            this.simpleMethodButton.TabIndex = 3;
            this.simpleMethodButton.Text = "Simple";
            this.simpleMethodButton.UseVisualStyleBackColor = true;
            this.simpleMethodButton.Click += new System.EventHandler(this.simpleMethodButton_Click);
            // 
            // QueryMethodView
            // 
            this.AcceptButton = this.linqMethodButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 76);
            this.Controls.Add(this.simpleMethodButton);
            this.Controls.Add(this.xPathMethodButton);
            this.Controls.Add(this.linqMethodButton);
            this.Controls.Add(this.queryMethodInvite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QueryMethodView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Спосіб пошуку";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label queryMethodInvite;
        private System.Windows.Forms.Button linqMethodButton;
        private System.Windows.Forms.Button xPathMethodButton;
        private System.Windows.Forms.Button simpleMethodButton;
    }
}