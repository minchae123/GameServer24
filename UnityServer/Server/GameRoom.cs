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
                // 신규 유저 추가
                _sessions.Add(session);
                session.Room = this;

                // 신규 유저 접속시, 기존 유저 목록 전송
                S_PlayerList players = new S_PlayerList();
                foreach(ClientSession s in _sessions)
				{
                    players.players.Add(new S_PlayerList.Player()
					{
                        isSelf = (s == session),
                        playerId = s.SessionId,
                        posX = s.PosX,
                        posY = s.PosY,
                        posZ = s.PosZ
					});
				}

                S_BroadcastEnterGame enter = new S_BroadcastEnterGame();
                enter.playerId = session.SessionId;
                enter.posX = 0;
                enter.posY = 0;
                enter.posZ = 0;
                BroadCast(enter.Write());
            }

        }

        public void Leave(ClientSession session)
        {
            _sessions.Remove(session);

            S_BroadcastLeaveGame leave = new S_BroadcastLeaveGame();
            leave.playerId = session.SessionId;
            BroadCast (leave.Write());  
        }

        public void BroadCast(ArraySegment<byte> segment) 
        { 
            ArraySegement<byte> packet = segment;

            lock(_lock) // 
            {
                foreach(ClientSession s in _sessions)
                {
                    s.Send(segment);
                }
            }
        }

        public void Move(ClientSession session, C_Move packet)
		{
            session.PosX = packet.posX;
            session.PosY = packet.posY;
            session.PosZ = packet.posZ;

            S_BroadcastMove move = new S_BroadcastMove();
            move.playerId = session.SessionId;
            move.posX = session.PosX;
            move.posY = session.PosY;
            move.posZ = session.PosZ;
            BroadCast(move.Write());
		}
    }
}
