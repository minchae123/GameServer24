using ChatLib.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib.Models.Sockets
{
	public abstract class ChatBase : ChatEventBase
	{
		private bool isRunning;

		protected readonly IPAddress IPAddress;
		protected readonly int Port;

		public event Action<bool>? RunningStateChanged;

		public ChatBase(IPAddress iPAddress, int port)
		{
			IPAddress = iPAddress;
			Port = port;
		}

		public bool IsRunning
		{
			get => isRunning;
			set
			{
				if(isRunning != value)
				{
					isRunning = value;
					RunningStateChanged?.Invoke(IsRunning);
				}
			}
		}
	}
}
