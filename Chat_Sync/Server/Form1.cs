using System.Net.Sockets;
using System.Net;
using System.Text;
using ChatLib.Models;
using ChatLib;
using ChatLib.Models.Sockets;
using ChatLib.Handlers;
using ChatLib.Events;

namespace Server
{
	public partial class Server : Form
	{
		private ChatServer server;
		private ClientRoomManager roomManager;

		private ChatHub CreateNewStatChatHub(ChatHub hub, ChatState state)
		{
			return new ChatHub
			{
				RoomId = hub.RoomId,
				UserName = hub.UserName,
				State = hub.State
			};
		}

		private void AddClientMessageList(ChatHub hub)
		{
			string message = hub.State switch
			{
				ChatState.Connect => $"立加 {hub}",
				ChatState.Disonnect => $"立加 辆丰 {hub}",
				_ => $"{hub} : {hub.Message}"
			};
			lbxMsg.Items.Add(message);
		}

		private void Connected(object? sender, ChatEventArgs e)
		{
			var hub = CreateNewStatChatHub(e.Hub, ChatState.Connect);

			roomManager.Add(e.ClientHander);
			roomManager.SendToMyRoom(hub);

			lbxClients.Items.Add(e.Hub);
			AddClientMessageList(hub);
		}

		private void Disconnected(object? sender, ChatEventArgs e)
		{
			var hub = CreateNewStatChatHub(e.Hub, ChatState.Disonnect);;

			roomManager.Remove(e.ClientHander);
			roomManager.SendToMyRoom(hub);

			lbxClients.Items.Remove(e.Hub);
			AddClientMessageList(hub);
		}

		private void Received(object? sender, ChatEventArgs e)
		{
			roomManager.SendToMyRoom(e.Hub);

			AddClientMessageList(e.Hub);
		}

		private void RunningStateChanged(bool isRunning)
		{
			btnStart.Enabled = !isRunning;
			BtnStop.Enabled = isRunning;
		}

		private void BtnStop_Click(object sender, EventArgs e)
		{
			server.Stop();
		}


		public Server()
		{
			InitializeComponent();
			roomManager = new ClientRoomManager();
			server = new ChatServer(IPAddress.Parse("127.0.0.1"),8080);
			server.Connected += Connected;
			server.Disconnected += Disconnected;
			server.Received += Received;
			server.RunningStateChanged += RunningStateChanged;

			btnStart.Click += btnStart_Click;
			BtnStop.Click += BtnStop_Click;
		}

		private TcpListener listener;

		private void btnStart_Click(object sender, EventArgs e)
		{
			_ = server.StartAsync();
		}

		/*private async void btnListen_Click(object sender, EventArgs e)
		{
			listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
			listener.Start(); // 辑滚 角青

			while (true)
			{
				TcpClient client = await listener.AcceptTcpClientAsync();
				_ = HandleClient(client);

			}
		}

		private async Task HandleClient(TcpClient client)
		{
			NetworkStream stream = client.GetStream();

			byte[] sizebuffer = new byte[4];
			int read;
			while (true)
			{
				read = await stream.ReadAsync(sizebuffer, 0, sizebuffer.Length);
				if(read == 0)
					break;
				int size = BitConverter.ToInt32(sizebuffer);

				byte[] buffer = new byte[size];
				read = await stream.ReadAsync(buffer, 0, buffer.Length);
				if(read == 0)
					break;
				string message = Encoding.UTF8.GetString(buffer, 0, read);
				var hub = ChatHub.Parse(message);
				lbxMsg.Items.Add($"UserId : {hub.UserId}, RoomId : {hub.RoomId}, UserName  {hub.UserName}, Message : {hub.Message}");

				var messageBuffer = Encoding.UTF8.GetBytes($"Server : {message}");
				stream.Write(messageBuffer);
			}
		}*/


	}
}