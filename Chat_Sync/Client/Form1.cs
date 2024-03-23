using System.Net.Sockets;
using System.Net;
using System.Text;
using ChatLib;
using ChatLib.Models;

namespace Client
{
	public partial class Client : Form
	{
		public Client()
		{
			InitializeComponent();
		}

		private TcpClient client;

		private async void btnConnect_Click(object sender, EventArgs e)
		{
			client = new TcpClient();
			await client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 8080);
			_ = HandleClient(client);
		}

		private async void btnSend_Click(object sender, EventArgs e)
		{
			NetworkStream stream = client.GetStream();
			string text = tbMsg.Text;

			ChatHub hub = new ChatHub
			{
				UserId = 1,
				RoomId = 2,
				UserName = "alsco",
				Message = text,
			};

			var messageBuffer = Encoding.UTF8.GetBytes(hub.ToJsonString());
			var messageLengthBuffer = BitConverter.GetBytes(messageBuffer.Length);

			await stream.WriteAsync(messageLengthBuffer);
			await stream.WriteAsync(messageBuffer);

			/*byte[] buffer = new byte[1024];
			int read = stream.Read(buffer, 0, buffer.Length);

			string message = Encoding.UTF8.GetString(buffer, 0, read);
			MessageBox.Show(message);*/
		}

		private async Task HandleClient(TcpClient client)
		{
			NetworkStream stream = client.GetStream();

			byte[] buffer = new byte[1024];
			int read;
			while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
			{
				string message = Encoding.UTF8.GetString(buffer, 0, read);
				listBox1.Items.Add(message);
			}
		}
	}
}