using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ServerCore;

namespace SServer
{
	class GameSession : Session
	{
		public override void OnConnected(EndPoint endPoint)
		{
			Console.WriteLine($"OnConnected : {endPoint}");
		}
		public override void OnRecv(ArraySegment<byte> buffer)
		{
			string recvData = Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count);
			Console.WriteLine($"From Client : {recvData}");

		}
		public override void OnSend(int numOfBytes)
		{
			Console.WriteLine($"OnSend : {numOfBytes}");

		}
		public override void OnDisconnected(EndPoint endPoint)
		{
			Console.WriteLine($"OnDisconnected : {endPoint}");

		}

	}

	class Program
	{
		static Listener _listener = new Listener();

		static void Main(string[] args)
		{
			// DNS
			IPHostEntry iphost = Dns.GetHostEntry(Dns.GetHostName());
			IPAddress ipAddr = iphost.AddressList[1];
			IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777); // IP주소, 포트번호 입력

			_listener.init(endPoint, () => { return new GameSession(); });
			Console.WriteLine("Listening...(영업중이야)");

			while (true)
			{
				//프로그램 종료 막기 위해 while
			}
		}
	}
}
