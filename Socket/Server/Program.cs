using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server;

internal class Program
{
	static void Main(string[] args)
	{
		using(Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
		{
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("26.8.160.191"), 20000);

			serverSocket.Bind(endPoint);

			serverSocket.Listen(20);

			using(Socket clinetSocket = serverSocket.Accept())
			{
				Console.WriteLine(clinetSocket.RemoteEndPoint);

				while(true)
				{
					byte[] buffer = new byte[256];
					int totalByte = clinetSocket.Receive(buffer);

					if (totalByte < 1)
					{
						Console.WriteLine("클라이언트의 연결 종료");
						return;
					}

					string str = Encoding.UTF8.GetString(buffer);
					Console.WriteLine(str);

					clinetSocket.Send(buffer);
				}
			}
		}
	}
}