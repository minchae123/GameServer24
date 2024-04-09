using ServerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	public class PacketManager
	{
		#region 싱글톤
		// 패킷매니저는 수정할 일없으므로 싱글톤으로 간편히 유지
		static PacketManager _instance = new PacketManager();
		public static PacketManager Instance { get { return _instance; } }
		#endregion

		PacketManager()
		{
			Register();
		}


		Dictionary<ushort, Func<PacketSession, ArraySegment<byte>, IPacket>> _makeFunc = new Dictionary<ushort, Func<PacketSession, ArraySegment<byte>, IPacket>>();
		Dictionary<ushort, Action<PacketSession, IPacket>> _handler	= new Dictionary<ushort, Action<PacketSession, IPacket>>();

		public void Register()
		{   // 멀티스레드 개입 차단 필요
			_onRecv.Add((ushort)PacketID.C_LeaveGame, MakePacket<C_LeaveGame>); // 패킷 생성 등록
			_handler.Add((ushort)PacketID.C_LeaveGame, PacketHandler.C_LevaeGameHandler);
			_onRecv.Add((ushort)PacketID.C_Move, MakePacket<C_Move>); // 패킷 생성 등록
			_handler.Add((ushort)PacketID.C_Move, PacketHandler.C_MoveHandler);
		}

		public void OnRecvPacket(PacketSession session, ArraySegment<byte> buffer)
		{
			ushort count = 0;

			ushort size = BitConverter.ToUInt16(buffer.Array, buffer.Offset);
			count += 2;
			ushort id = BitConverter.ToUInt16(buffer.Array, buffer.Offset + count);
			count += 2;    // id값을 가지고 switch 대신 딕셔너리에서 값을 찾고 등록된 핸들러에서 해당 작업 Invoke

			Action<PacketSession, ArraySegment<byte>> action = null;
			if (_onRecv.TryGetValue(id, out action))
				action.Invoke(session, buffer); // ..._onRecv.Add((ushort)Packet..., MakePacket

		}
		// 제한 : IPacket 장착, new 가능
		T MakePacket<T>(PacketSession session, ArraySegment<byte> buffer) where T : IPacket, new()
		{
			T packet = new T();     // 패킷 만들기
			packet.Read(buffer);    // 들어온 패킷 읽기
			return packet;
		}

		public void HandlePacket(PacketSession session, IPacket packet)
		{
			Action<PacketSession, IPacket> action = null;   // 핸들러 호출
			if (_handler.TryGetValue(packet.Protocol, out action))
			{
				action(session, packet);
			}
		}
	}
}
