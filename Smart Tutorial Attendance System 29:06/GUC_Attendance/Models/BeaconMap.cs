using System;
using SQLite.Net.Attributes;

namespace GUC_Attendance.Models
{
	[Table("BeaconMap")]
	public class BeaconMap
	{

		public string id { get; set; }

		[PrimaryKey, AutoIncrement]
		public int uuid { get; set; }

		public string mac_address { get; set; }

		public string beacon_room { get; set; }

		public BeaconMap()
		{

		}

	}

}

