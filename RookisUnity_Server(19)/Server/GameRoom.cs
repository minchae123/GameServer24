using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Session;

namespace Server
{
    class GameRoom
    {
        List<ClientSession> _sessions = new List<ClientSession>();
        object _lock = new object();

        public void Enter(ClientSession session)
        {
            lock(_lock)
            {
                _sessions.Add(session);
                session.Room = this;
            }

        }

        public void Leave(ClientSession session)
        {
            lock (_lock)
            {
                _sessions.Remove(session);
            }
        }

        public void BroadCast(ClientSession session, long id, string chat) 
        { 
            PlayerInfoReq packet = new PlayerInfoReq();
            packet.playerId = session.SessionId;
            packet.name = $"i am {packet.playerId} and {chat}";
            ArraySegment<byte> segment = packet.Write();

            lock(_lock) // 
            {
                foreach(ClientSession s in _sessions)
                {
                    s.Send(segment);    // 리스트에 들어있는 모든 클라에 전송
                }
            }
        }
    }
}
