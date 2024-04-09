using Server.Session;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server {
    class PacketHandler 
    {
        // 어떤 세션에서 조립된 패킷인지, 어떤 내용의 패킷인지
        public static void PlayerInfoReqHandler(PacketSession session, IPacket packet) 
        {
            PlayerInfoReq p = packet as PlayerInfoReq;
            ClientSession clientSession = session as ClientSession;

            if(clientSession.Room == null)  // 방이 없는 상태
            {
                return;
            }

            clientSession.Room.BroadCast(clientSession, p.playerId, p.name);
            Console.WriteLine($"Server PlayerInfoReq: {p.playerId} {p.name}");    // 화면 출력
        }

        // 클라이언트로부터 메시지 도착했을 때 동작들~

        // 클라가 떠났을 때, room에서 내쫓는 동작
        public static void C_LeaveGameHandler(PacketSession session, IPacket packet)
        {
            ClientSession clientSession = session as ClientSession;

            if (clientSession.Room == null)
                return;

            GameRoom room = clientSession.Room;
            room.Leave(clientSession);
        }
        // 클라의 이동패킷 들어오면, 화면에 이동정보 출력, room에 이동 정보 공유
        public static void C_MoveHandler(PacketSession session, IPacket packet)
        {
            C_Move movePacket = packet as C_Move;
            ClientSession clientSession = session as ClientSession;

            if (clientSession.Room == null)
                return;

            Console.WriteLine($"{movePacket.posX}, {movePacket.posY}, {movePacket.posZ}");

            GameRoom room = clientSession.Room;
            room.Move(clientSession, movePacket);
        }
    }
}
