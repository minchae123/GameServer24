﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib.Events
{
	public abstract class ChatEventBase
	{
		public abstract event EventHandler<ChatEventArgs>? Connected;
		public abstract event EventHandler<ChatEventArgs>? Disconnected;
		public abstract event EventHandler<ChatEventArgs>? Received;
	}
}
