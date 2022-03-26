namespace client
{
    partial class formGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.buttonSendTextToServer = new System.Windows.Forms.Button();
            this.textBoxReceive = new System.Windows.Forms.TextBox();
            this.labelSend = new System.Windows.Forms.Label();
            this.labelReceive = new System.Windows.Forms.Label();
            this.labelServerIP = new System.Windows.Forms.Label();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(135, 136);
            this.textBoxSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(313, 23);
            this.textBoxSend.TabIndex = 0;
            // 
            // buttonSendTextToServer
            // 
            this.buttonSendTextToServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSendTextToServer.Location = new System.Drawing.Point(190, 199);
            this.buttonSendTextToServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendTextToServer.Name = "buttonSendTextToServer";
            this.buttonSendTextToServer.Size = new System.Drawing.Size(204, 22);
            this.buttonSendTextToServer.TabIndex = 1;
            this.buttonSendTextToServer.Text = "Send Text to Server";
            this.buttonSendTextToServer.UseVisualStyleBackColor = true;
            this.buttonSendTextToServer.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.Location = new System.Drawing.Point(135, 271);
            this.textBoxReceive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.Size = new System.Drawing.Size(313, 23);
            this.textBoxReceive.TabIndex = 2;
            // 
            // labelSend
            // 
            this.labelSend.AutoSize = true;
            this.labelSend.Location = new System.Drawing.Point(135, 119);
            this.labelSend.Name = "labelSend";
            this.labelSend.Size = new System.Drawing.Size(33, 15);
            this.labelSend.TabIndex = 3;
            this.labelSend.Text = "Send";
            // 
            // labelReceive
            // 
            this.labelReceive.AutoSize = true;
            this.labelReceive.Location = new System.Drawing.Point(135, 254);
            this.labelReceive.Name = "labelReceive";
            this.labelReceive.Size = new System.Drawing.Size(47, 15);
            this.labelReceive.TabIndex = 4;
            this.labelReceive.Text = "Receive";
            // 
            // labelServerIP
            // 
            this.labelServerIP.AutoSize = true;
            this.labelServerIP.Location = new System.Drawing.Point(39, 26);
            this.labelServerIP.Name = "labelServerIP";
            this.labelServerIP.Size = new System.Drawing.Size(52, 15);
            this.labelServerIP.TabIndex = 5;
            this.labelServerIP.Text = "Server IP";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(97, 23);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(167, 23);
            this.textBoxServerIP.TabIndex = 6;
            // 
            // formGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(584, 861);
            this.Controls.Add(this.textBoxServerIP);
            this.Controls.Add(this.labelServerIP);
            this.Controls.Add(this.labelReceive);
            this.Controls.Add(this.labelSend);
            this.Controls.Add(this.textBoxReceive);
            this.Controls.Add(this.buttonSendTextToServer);
            this.Controls.Add(this.textBoxSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formGame";
            this.Text = "小朋友下樓梯 Remake";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxSend;
        private Button buttonSendTextToServer;
        private TextBox textBoxReceive;
        private Label labelSend;
        private Label labelReceive;
        private Label labelServerIP;
        private TextBox textBoxServerIP;
    }
}