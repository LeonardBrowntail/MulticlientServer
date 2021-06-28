
namespace FinalProject
{
    partial class MainProgram
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
            this.clientConnect = new System.Windows.Forms.Button();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configIPMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.behaviourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.clientCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.destLabel = new System.Windows.Forms.Label();
            this.destIPBox = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.inputLabel = new System.Windows.Forms.Label();
            this.serverStop = new System.Windows.Forms.Button();
            this.clientDisconnect = new System.Windows.Forms.Button();
            this.serverStart = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientConnect
            // 
            this.clientConnect.Enabled = false;
            this.clientConnect.Location = new System.Drawing.Point(423, 361);
            this.clientConnect.Name = "clientConnect";
            this.clientConnect.Size = new System.Drawing.Size(115, 23);
            this.clientConnect.TabIndex = 0;
            this.clientConnect.Text = "Connect";
            this.clientConnect.UseVisualStyleBackColor = true;
            this.clientConnect.Click += new System.EventHandler(this.RunClient);
            // 
            // chatBox
            // 
            this.chatBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.chatBox.ForeColor = System.Drawing.SystemColors.Control;
            this.chatBox.Location = new System.Drawing.Point(15, 45);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(640, 267);
            this.chatBox.TabIndex = 1;
            // 
            // inputBox
            // 
            this.inputBox.Enabled = false;
            this.inputBox.Location = new System.Drawing.Point(15, 335);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(402, 100);
            this.inputBox.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configIPMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip";
            // 
            // configIPMenu
            // 
            this.configIPMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.behaviourToolStripMenuItem});
            this.configIPMenu.Name = "configIPMenu";
            this.configIPMenu.Size = new System.Drawing.Size(61, 20);
            this.configIPMenu.Text = "Options";
            // 
            // behaviourToolStripMenuItem
            // 
            this.behaviourToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverCheck,
            this.clientCheck});
            this.behaviourToolStripMenuItem.Name = "behaviourToolStripMenuItem";
            this.behaviourToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.behaviourToolStripMenuItem.Text = "Behaviour";
            // 
            // serverCheck
            // 
            this.serverCheck.Name = "serverCheck";
            this.serverCheck.Size = new System.Drawing.Size(106, 22);
            this.serverCheck.Text = "Server";
            this.serverCheck.Click += new System.EventHandler(this.select_server);
            // 
            // clientCheck
            // 
            this.clientCheck.Name = "clientCheck";
            this.clientCheck.Size = new System.Drawing.Size(106, 22);
            this.clientCheck.Text = "Client";
            this.clientCheck.Click += new System.EventHandler(this.select_client);
            // 
            // usernameBox
            // 
            this.usernameBox.Enabled = false;
            this.usernameBox.Location = new System.Drawing.Point(423, 335);
            this.usernameBox.MaxLength = 10;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(115, 20);
            this.usernameBox.TabIndex = 4;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(420, 319);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 5;
            this.usernameLabel.Text = "Username";
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.Location = new System.Drawing.Point(537, 319);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(73, 13);
            this.destLabel.TabIndex = 6;
            this.destLabel.Text = "Destination IP";
            // 
            // destIPBox
            // 
            this.destIPBox.Enabled = false;
            this.destIPBox.Location = new System.Drawing.Point(540, 335);
            this.destIPBox.MaxLength = 15;
            this.destIPBox.Name = "destIPBox";
            this.destIPBox.Size = new System.Drawing.Size(115, 20);
            this.destIPBox.TabIndex = 7;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(12, 29);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(60, 13);
            this.outputLabel.TabIndex = 10;
            this.outputLabel.Text = "Output Box";
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(15, 318);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(52, 13);
            this.inputLabel.TabIndex = 11;
            this.inputLabel.Text = "Input Box";
            // 
            // serverStop
            // 
            this.serverStop.Enabled = false;
            this.serverStop.Location = new System.Drawing.Point(540, 390);
            this.serverStop.Name = "serverStop";
            this.serverStop.Size = new System.Drawing.Size(115, 23);
            this.serverStop.TabIndex = 12;
            this.serverStop.Text = "Stop";
            this.serverStop.UseVisualStyleBackColor = true;
            this.serverStop.Click += new System.EventHandler(this.StopServer);
            // 
            // clientDisconnect
            // 
            this.clientDisconnect.Enabled = false;
            this.clientDisconnect.Location = new System.Drawing.Point(423, 390);
            this.clientDisconnect.Name = "clientDisconnect";
            this.clientDisconnect.Size = new System.Drawing.Size(115, 23);
            this.clientDisconnect.TabIndex = 13;
            this.clientDisconnect.Text = "Disconnect";
            this.clientDisconnect.UseVisualStyleBackColor = true;
            this.clientDisconnect.Click += new System.EventHandler(this.StopClient);
            // 
            // serverStart
            // 
            this.serverStart.Enabled = false;
            this.serverStart.Location = new System.Drawing.Point(540, 361);
            this.serverStart.Name = "serverStart";
            this.serverStart.Size = new System.Drawing.Size(115, 23);
            this.serverStart.TabIndex = 14;
            this.serverStart.Text = "Start";
            this.serverStart.UseVisualStyleBackColor = true;
            this.serverStart.Click += new System.EventHandler(this.RunServer);
            // 
            // sendButton
            // 
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(423, 419);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(115, 23);
            this.sendButton.TabIndex = 15;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendMessage);
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(667, 450);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.serverStart);
            this.Controls.Add(this.clientDisconnect);
            this.Controls.Add(this.serverStop);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.destIPBox);
            this.Controls.Add(this.destLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.clientConnect);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(683, 489);
            this.MinimumSize = new System.Drawing.Size(683, 489);
            this.Name = "MainProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Final Project by 4210191004 Aydin Ihsan I.N.";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clientConnect;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label destLabel;
        private System.Windows.Forms.TextBox destIPBox;
        private System.Windows.Forms.ToolStripMenuItem configIPMenu;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.ToolStripMenuItem behaviourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverCheck;
        private System.Windows.Forms.ToolStripMenuItem clientCheck;
        public System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.Button serverStop;
        private System.Windows.Forms.Button clientDisconnect;
        private System.Windows.Forms.Button serverStart;
        private System.Windows.Forms.Button sendButton;
    }
}

