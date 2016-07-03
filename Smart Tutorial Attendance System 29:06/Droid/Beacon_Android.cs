using System;
using Xamarin.Forms;
using System.Net.Sockets;
using GUC_Attendance.Droid;
using System.Net;
using System.Diagnostics;
using GUC_Attendance.Models;
using System.Collections.Generic;
using Java.IO;

[assembly: Dependency (typeof(Beacon_Android))]


namespace GUC_Attendance.Droid
{
	public class Beacon_Android: IBeacon
	{
		public void CreateBeacon ()
		{
			Beacon b = new Beacon ();
		}
	}
}





