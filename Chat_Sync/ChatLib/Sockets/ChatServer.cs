using ChatLib.Events;
using ChatLib.Handlers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib.Models.Sockets
{
	public class ChatServer : ChatBase
	{
		private readonly TcpListener listener;

		public override event EventHandler<ChatEventArgs>? Connected;
		public override event EventHandler<ChatEventArgs>? Disconnected;
		public override event EventHandler<ChatEventArgs>? Received;

		public ChatServer(IPAddress iPAddress, int port) : base(iPAddress, port)
		{
			listener = new TcpListener(IPAddress, port);
		}

		public async Task StartAsync()
		{
			if (IsRunning)
				return;

			try
			{
				listener.Start();
				IsRunning = true;
				Debug.Print("서버 시작");

				while (true)
				{
					TcpClient client = await listener.AcceptTcpClientAsync();
					Debug.Print($"클라 연결 수락 : {client.Client.Handle}");

					ClientHandler clientHandler = new ClientHandler(client);
					clientHandler.Connected += Connected;
					clientHandler.Disconnected += Disconnected;
					clientHandler.Received += Received;

					_ = clientHandler.HandleClientAsync();
				}
			}
			catch (Exception ex)
			{
				Debug.Print($"서버 시작 중 오류 발생 : {ex.Message}");
				IsRunning = false;
			}
		}

		public void Stop()
		{
			IsRunning = false;
			listener.Stop ();
			Debug.Print("서버 정지");
		}
	}
}
