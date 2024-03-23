namespace Client
{
	partial class Client
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
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.tbMsg = new System.Windows.Forms.TextBox();
			this.nudRoomId = new System.Windows.Forms.NumericUpDown();
			this.btnQuit = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbName = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.nudRoomId)).BeginInit();
			this.SuspendLayout();
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(529, 60);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(121, 73);
			this.btnConnect.TabIndex = 0;
			this.btnConnect.Text = "연결";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(334, 113);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(105, 44);
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "메세지 전송";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 20;
			this.listBox1.Location = new System.Drawing.Point(12, 212);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(848, 364);
			this.listBox1.TabIndex = 2;
			// 
			// tbMsg
			// 
			this.tbMsg.Location = new System.Drawing.Point(141, 113);
			this.tbMsg.Name = "tbMsg";
			this.tbMsg.Size = new System.Drawing.Size(157, 27);
			this.tbMsg.TabIndex = 3;
			// 
			// nudRoomId
			// 
			this.nudRoomId.Location = new System.Drawing.Point(150, 39);
			this.nudRoomId.Name = "nudRoomId";
			this.nudRoomId.Size = new System.Drawing.Size(56, 27);
			this.nudRoomId.TabIndex = 4;
			// 
			// btnQuit
			// 
			this.btnQuit.Location = new System.Drawing.Point(672, 62);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(115, 71);
			this.btnQuit.TabIndex = 5;
			this.btnQuit.Text = "종료";
			this.btnQuit.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(40, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Room ID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(40, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 20);
			this.label2.TabIndex = 7;
			this.label2.Text = "Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(40, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 20);
			this.label3.TabIndex = 8;
			this.label3.Text = "Messages";
			// 
			// tbName
			// 
			this.tbName.Location = new System.Drawing.Point(141, 76);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(157, 27);
			this.tbName.TabIndex = 9;
			// 
			// Client
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(872, 588);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnQuit);
			this.Controls.Add(this.nudRoomId);
			this.Controls.Add(this.tbMsg);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.btnConnect);
			this.Name = "Client";
			this.Text = "ClientForm";
			((System.ComponentModel.ISupportInitialize)(this.nudRoomId)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button btnConnect;
		private Button btnSend;
		private ListBox listBox1;
		private TextBox tbMsg;
		private NumericUpDown nudRoomId;
		private Button btnQuit;
		private Label label1;
		private Label label2;
		private Label label3;
		private TextBox tbName;
	}
}