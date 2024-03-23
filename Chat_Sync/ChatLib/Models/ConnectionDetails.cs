using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLib.Models
{
	public class ConnectionDetails
	{
		public int UserId { get; set; }
		public string UserName { get; set; } = string.Empty;
		public int RoomId { get; set; }

		public override string ToString()
		{
			return $"RoomID : {RoomId}, UserName : {UserName}";
		}
	}
}
