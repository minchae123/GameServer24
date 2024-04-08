using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerCore
{
	public abstract class Session
	{
		Socket _socket;
		int disconnected = 0;

		Queue<byte[]> _sendQueue = new Queue<byte[]>();
		bool _isPending = false;
		SocketAsyncEventArgs sendArgs = new SocketAsyncEventArgs();
		SocketAsyncEventArgs _recvArgs = new SocketAsyncEventArgs();
		List<ArraySegment<byte>> pendingList = new List<ArraySegment<byte>>();

		public abstract void OnConnected(EndPoint endPoint);
		public abstract void OnRecv(ArraySegment<byte> buffer);
		public abstract void OnSend(int numOfBytes);
		public abstract void OnDisconnected(EndPoint endPoint);

		object _lock = new object();

		public void Init(Socket socket)
		{
			_socket = socket;
			_recvArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnRecvCompletd);
			_recvArgs.SetBuffer(new byte[1024], 0, 1024);

			sendArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnSendCompleted);
			//RegisterSend();

			RegisterRecv(); // 1. 수신대기
		}

		#region 데이터 수신
		void RegisterRecv()
		{
			bool isPending = _socket.ReceiveAsync(_recvArgs);
			if (isPending == false)
			{
				OnRecvCompletd(null, _recvArgs); // 2. 수신 완료 (3단 구조)
			}
		}

		private void OnRecvCompletd(object sender, SocketAsyncEventArgs args)
		{
			if (args.BytesTransferred > 0 && args.SocketError == SocketError.Success)
			{
				try
				{
					string recvData = Encoding.UTF8.GetString(args.Buffer, args.Offset, args.BytesTransferred);
					Console.WriteLine($"From Client : {recvData}");

					RegisterRecv(); // 3. 수신 완료 후, 다시 수신 대기(3단구조_
				}
				catch (Exception e)
				{
					Console.WriteLine($"OnReceiveCompleted Failed {e}");
				}
			}
			else
			{
				Disconnect();
			}
		}
		#endregion

		#region 데이터 송신
		public void Send(byte[] sendBuff)
		{
			lock (_lock)
			{
				_sendQueue.Enqueue(sendBuff);
				if (pendingList.Count == 0)
					RegisterSend();
			}
		}

		void RegisterSend()
		{
			while (_sendQueue.Count > 0)
			{
				byte[] buff = _sendQueue.Dequeue();
				pendingList.Add(new ArraySegment<byte>(buff, 0, buff.Length));
			}
			sendArgs.BufferList = pendingList;

			bool isPending = _socket.SendAsync(sendArgs);
			if (isPending == false)
				OnSendCompleted(null, sendArgs);
		}

		void OnSendCompleted(object send, SocketAsyncEventArgs args)
		{
			lock(_lock)
			{
				if (args.BytesTransferred > 0 && args.SocketError == SocketError.Success)
				{
					try
					{
						sendArgs.BufferList = null;
						pendingList.Clear();

						Console.WriteLine($"Transferred bytes {sendArgs.BytesTransferred}");

						if(_sendQueue.Count > 0)
							RegisterSend();
					}
					catch (Exception e)
					{
						Console.WriteLine($"OnSendCompleted {e}");
					}
				}
				else
				{
					Disconnect();
				}
			}
		}

		public void Disconnect()
		{
			if (Interlocked.Exchange(ref disconnected, 1) == 1)
				return;

			_socket.Shutdown(SocketShutdown.Both);
			_socket.Close();
		}
		#endregion
	}
}
