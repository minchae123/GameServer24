using DummyClient;
using DummyClient.Session;
using ServerCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    // DummyClient 역할
    
    // 세션 1개만 사용 예정이므로, SessionManager 미사용
    ServerSession _session = new ServerSession();

    public void Send(ArraySegment<byte> sendBuff)
	{
        _session.Send(sendBuff);
	}

    void Start()
    { 
        // DNS
        IPHostEntry iphost = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ipAddr = iphost.AddressList[1];
        IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777); // IP주소, 포트번호 입력

        Connector connector = new Connector();
        connector.Connect(endPoint, () => { return _session; }, 1);

        //StartCoroutine(CoSendPacket());

    }

    void Update()
    {
        List<IPacket> list = PacketQueue.Instance.PopAll();
        foreach(IPacket packet  in list)
		{
            PacketManager.Instance.HandlePacket(_session, packet);
		}
            
        //IPacket packet =  PacketQueue.Instance.Pop();
        //if(packet != null)
		//{
        //    PacketManager.Instance.HandlePacket(_session, packet);
		//}
    }

    IEnumerator CoSendPacket()
	{
        while(true)
		{
            yield return new WaitForSeconds(3);
            //PlayerInfoReq packet = new PlayerInfoReq();
            //packet.name = "Alsco";
            //ArraySegment<byte> segment = packet.Write();

            //_session.Send(segment);
		}
	}

}
