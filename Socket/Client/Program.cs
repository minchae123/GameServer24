using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client;

internal class Program
{
	static void Main(string[] args)
	{
		using (Socket clinetSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
		{
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("26.8.160.191"), 20000);
			clinetSocket.Connect(endPoint);

			while (true)
			{
				string str = Console.ReadLine();
				if (str == "exit")
					return;

				byte[] buffer = Encoding.UTF8.GetBytes(str);
				clinetSocket.Send(buffer);

				byte[] rbuffer = new byte[256];
				int byteRead = clinetSocket.Receive(rbuffer);

				if (byteRead < 1)
				{
					Console.WriteLine("서버 연결 종료");
					return;
				}

				str = Encoding.UTF8.GetString(rbuffer);
				Console.WriteLine("받음 : " + str);
			}
		}
	}
}