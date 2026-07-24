namespace CardViewer.Views
{
    partial class Alert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alert));
            buttonOK = new Button();
            labelAlertMessage = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom;
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(178, 117);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(70, 23);
            buttonOK.TabIndex = 0;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // labelAlertMessage
            // 
            labelAlertMessage.AutoSize = true;
            labelAlertMessage.Location = new Point(12, 9);
            labelAlertMessage.Name = "labelAlertMessage";
            labelAlertMessage.Size = new Size(107, 15);
            labelAlertMessage.TabIndex = 1;
            labelAlertMessage.Text = "Alert message here";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(labelAlertMessage);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(427, 111);
            panel1.TabIndex = 2;
            // 
            // Alert
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(427, 152);
            Controls.Add(buttonOK);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Alert";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alert";
            TopMost = true;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOK;
        private Label labelAlertMessage;
        private Panel panel1;
    }
}