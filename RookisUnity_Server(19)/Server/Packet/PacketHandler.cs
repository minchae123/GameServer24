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
    }
}
