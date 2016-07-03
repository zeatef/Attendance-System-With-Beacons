using System;
using Xamarin.Forms;
using System.Net.Sockets;
using GUC_Attendance.iOS;
using System.Net;
using System.Diagnostics;
using GUC_Attendance.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;


[assembly: Dependency (typeof(SocketProgramming_iOS))]


namespace GUC_Attendance.iOS
{
	public class Beacon_iOS : IBeacon
	{
		public void CreateBeacon ()
		{
			
		}

		//void OnReceive (Context context, Intent intent);

		//		void DoWork2 ();
		//
		//		void DoDiscovery2 ();
		//
		//		void RequestStop ();
		//
		//		void Run ();

		public Beacon_iOS ()
		{
		}
	}
}

