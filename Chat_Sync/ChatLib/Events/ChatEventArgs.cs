using ChatLib.Handlers;
using ChatLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib.Events
{
	public class ChatEventArgs : EventArgs
	{
		public ChatEventArgs(ClientHandler clientHandler, ChatHub hub)
		{
			ClientHander = clientHandler;
			Hub = hub;
		}

		public ClientHandler ClientHander { get;}
		public ChatHub Hub { get;}
	}
}
