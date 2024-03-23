using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatLib.Models 
{
	public class ChatHub : ConnectionDetails
	{
		// 역직렬화, Json 문자열을 ChatHub 형식으로 역직렬화하고, 실패시 null 반환
		public static ChatHub? Parse(string json) => JsonSerializer.Deserialize<ChatHub>(json);

		public ChatState State { get; set; }

		//public int UserId { get; set; }
		//public string UserName { get; set; } = string.Empty;
		//public int RoomId { get; set; }
		public string Message { get; set; } = string.Empty;

		// Json 스트림으로 직렬화
		public string ToJsonString() => JsonSerializer.Serialize(this);
	}
}
