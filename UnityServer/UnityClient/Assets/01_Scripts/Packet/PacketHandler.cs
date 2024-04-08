﻿using DummyClient.Session;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DummyClient
{
    class PacketHandler {
        // 어떤 세션에서 조립된 패킷인지, 어떤 내용의 패킷인지
        public static void PlayerInfoReqHandler(PacketSession session, IPacket p)
        {
            PlayerInfoReq packet = p as PlayerInfoReq;
            ServerSession serverSession = session as ServerSession; 
            if(packet.playerId == 1)
			{
                Debug.Log(packet.name);

                GameObject go = GameObject.Find("Player");
                if(go == null)
                    Debug.Log("Player Not Found");
                else 
                    Debug.Log("Player Found");
                //Console.WriteLine($"Client PlayerInfoReq: {packet.playerId} {packet.name}");    // 화면 출력
			}
        }
    }
}
