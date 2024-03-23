using ChatLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib.Handlers
{
	public class ClientRoomManager
	{
		private Dictionary<int, List<ClientHandler>> roomHandlerDict = new();

		public void Add(ClientHandler clientHandler)
		{
			int roomId = clientHandler.InitialData!.RoomId;

			if(roomHandlerDict.TryGetValue(roomId, out _))
			{
				roomHandlerDict[roomId].Add(clientHandler);
			}
			else
			{
				roomHandlerDict[roomId] = new List<ClientHandler>() { clientHandler};
			}
		}

		public void Remove(ClientHandler clientHandler)
		{
			int roomId = clientHandler.InitialData!.RoomId;

			if (roomHandlerDict.TryGetValue(roomId, out List<ClientHandler>? roomHandlers))
			{
				roomHandlerDict[roomId] = roomHandlers.FindAll(handler => !handler.Equals(clientHandler));
			}
		}

		public void SendToMyRoom(ChatHub hub)
		{
			if(roomHandlerDict.TryGetValue(hub.RoomId, out List<ClientHandler>? roomHandlers))
			{
				roomHandlers.ForEach(handler => handler.Send(hub));
			}
		}
	}
}
