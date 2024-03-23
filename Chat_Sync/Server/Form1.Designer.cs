namespace Server
{
	partial class Server
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
			this.btnStart = new System.Windows.Forms.Button();
			this.lbxMsg = new System.Windows.Forms.ListBox();
			this.BtnStop = new System.Windows.Forms.Button();
			this.lbxClients = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 29);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(130, 49);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "서버시작";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// lbxMsg
			// 
			this.lbxMsg.FormattingEnabled = true;
			this.lbxMsg.ItemHeight = 20;
			this.lbxMsg.Location = new System.Drawing.Point(298, 118);
			this.lbxMsg.Name = "lbxMsg";
			this.lbxMsg.Size = new System.Drawing.Size(589, 424);
			this.lbxMsg.TabIndex = 1;
			// 
			// BtnStop
			// 
			this.BtnStop.Location = new System.Drawing.Point(157, 29);
			this.BtnStop.Name = "BtnStop";
			this.BtnStop.Size = new System.Drawing.Size(130, 49);
			this.BtnStop.TabIndex = 2;
			this.BtnStop.Text = "서버 중지";
			this.BtnStop.UseVisualStyleBackColor = true;
			this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
			// 
			// lbxClients
			// 
			this.lbxClients.FormattingEnabled = true;
			this.lbxClients.ItemHeight = 20;
			this.lbxClients.Location = new System.Drawing.Point(28, 118);
			this.lbxClients.Name = "lbxClients";
			this.lbxClients.Size = new System.Drawing.Size(246, 424);
			this.lbxClients.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 95);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 20);
			this.label1.TabIndex = 4;
			this.label1.Text = "Connected Clients";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(298, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "Messaages";
			// 
			// Server
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(899, 559);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbxClients);
			this.Controls.Add(this.BtnStop);
			this.Controls.Add(this.lbxMsg);
			this.Controls.Add(this.btnStart);
			this.Name = "Server";
			this.Text = "ServerForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button btnStart;
		private ListBox lbxMsg;
		private Button BtnStop;
		private ListBox lbxClients;
		private Label label1;
		private Label label2;
	}
}