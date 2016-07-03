
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using System.Timers;
using System.Threading;
using Android.Util;
using Acr.UserDialogs;


namespace GUC_Attendance.Droid
{
	public class Beacon:Activity
	{
		public static void main ()
		{

		}

		public Beacon ()
		{
			System.Diagnostics.Debug.WriteLine ("Reached Beacon....");
//			var newDevicesListView = FindViewById<ListView> (Resource.Id.new_devices);
//			newDevicesListView.Adapter = newDevicesArrayAdapter;
//			newDevicesListView.ItemClick += DeviceListClick;
			this.Run ();

			// Register for broadcasts when a device is discovered
			receiver = new Receiver (this);
			var filter = new IntentFilter (BluetoothDevice.ActionFound);
			RegisterReceiver (receiver, filter);

			// Register for broadcasts when discovery has finished
			filter = new IntentFilter (BluetoothAdapter.ActionDiscoveryFinished);
			RegisterReceiver (receiver, filter);

			// Get the local Bluetooth adapter
			btAdapter = BluetoothAdapter.DefaultAdapter;
		}

		// Debugging
		private const string TAG = "DeviceListActivity";
		private const bool Debug = true;
		public static Context context2;
		public static Context context3;




		// Return Intent extra
		public const string EXTRA_DEVICE_ADDRESS = "device_address";

		// Member fields
		private BluetoothAdapter btAdapter;
		private static ArrayAdapter<string> pairedDevicesArrayAdapter;
		private static ArrayAdapter<string> newDevicesArrayAdapter;
		private Receiver receiver;
		//
		//		protected override void OnCreate (Bundle savedInstanceState)
		//		{
		//			base.OnCreate (savedInstanceState);
		////			RequestWindowFeature (WindowFeatures.IndeterminateProgress);
		//			/*SetContentView (Resource.Layout.layout1);
		//			// Setup the window 
		//			context2 = this;
		//
		//			SetContentView (Resource.Layout.layout1);
		//
		//			// Set result CANCELED incase the user backs out
		//			SetResult (Result.Canceled);
		//
		//			// Initialize the button to perform device discovery			
		//			var scanButton = FindViewById<Button> (Resource.Id.ScanButton);
		//
		//
		//			/*       var myTimer = new System.Timers.Timer(1000);
		//                      myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
		//
		//                      myTimer.Interval = 1000;
		//                      myTimer.Enabled = true;
		//                      myTimer.Start();
		//          */
		//
		//
		//
		//
		//			/*
		//			var RefreshButton = FindViewById<Button> (Resource.Id.RssiButton);
		//			RefreshButton.Click += (sender, e) => {
		//				var intent = new Intent (this, typeof(Activity1));
		//				intent.SetFlags (ActivityFlags.ClearTop);
		//				StartActivity (intent);
		//
		//			};*/
		//
		////			var thread = new Thread (
		////				() => {
		////					while (true) {
		////						int now = DateTime.Now.Second;
		////
		////
		////
		////						// Toast.MakeText(this, DateTime.Now+"", ToastLength.Long).Show();
		////
		////						if (DateTime.Now.Second < 60 && DateTime.Now.Second >= now + 12 | DateTime.Now.Second > 60 && DateTime.Now.Second >= (now + 12) - 60) {
		////							//   DoDiscovery();
		////						}
		////					}
		////				});
		//
		//
		//
		//			// Initialize array adapters. One for already paired devices and
		//			// one for newly discovered devices
		////			pairedDevicesArrayAdapter = new ArrayAdapter<string> (this, Resource.Layout.device_name);
		////			newDevicesArrayAdapter = new ArrayAdapter<string> (this, Resource.Layout.device_name);
		//
		//			// Find and set up the ListView for paired devices
		//			//  var pairedListView = FindViewById<ListView>(Resource.Id.paired_devices);
		//			//  pairedListView.Adapter = pairedDevicesArrayAdapter;
		//			//  pairedListView.ItemClick += DeviceListClick;
		//
		//			// Find and set up the ListView for newly discovered devices
		//
		//
		//
		//			// Get a set of currently paired devices
		//
		//
		//		}
		//
		//
		/*   private void OnTimedEvent(object source, ElapsedEventArgs e)
             {

                Toast.MakeText(this, "Restart scanning", ToastLength.Long).Show();

                 DoDiscovery();
             }
             */
		//oufa
		public static BluetoothAdapter bluetoothAdapter = null;
		//private object mLeScanCallback;

		public void Run ()
		{

			UserDialogs.Instance.InfoToast ("Restart Scanning...");

			Discovery workerObject = new Discovery ();
			Thread workerThread = new Thread (workerObject.DoWork2);

			// Start the worker thread.
			workerThread.Start ();
			Console.WriteLine ("main thread: Starting worker thread...");

			// Loop until worker thread activates. 
			while (!workerThread.IsAlive)
				;

			// Put the main thread to sleep for 1 millisecond to 
			// allow the worker thread to do some work:
			//Thread.Sleep(1000);

			// Request that the worker thread stop itself:
			// workerObject.RequestStop();

			// DoDiscovery();
			// thread.Start();

			//  (sender as View).Visibility = ViewStates.Gone;
		}

		//oufa
		public void startScanning ()
		{
			bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
			if (!bluetoothAdapter.IsEnabled) {

			} else {


			}
		}



		protected override void OnDestroy ()
		{
			base.OnDestroy ();

			// Make sure we're not doing discovery anymore
			if (btAdapter != null) {
				btAdapter.CancelDiscovery ();
			}

			// Unregister broadcast listeners
			UnregisterReceiver (receiver);
		}

		/// <summary>
		/// Start device discover with the BluetoothAdapter
		/// </summary>
		public void DoDiscovery ()
		{
			if (Debug)
				// Log.Debug(TAG, "doDiscovery()");

				// Indicate scanning in the title
				SetProgressBarIndeterminateVisibility (true);
			// SetTitle("Scanning");

			// Turn on sub-title for new devices
			//  FindViewById<View>(Resource.Id.title_new_devices).Visibility = ViewStates.Visible;

			// If we're already discovering, stop it
			if (btAdapter.IsDiscovering) {
				btAdapter.CancelDiscovery ();
			}


			// Request discover from BluetoothAdapter
			btAdapter.StartDiscovery ();
			//  btAdapter.CancelDiscovery();

			//oufa
			//btAdapter.StartLeScan(BluetoothAdapter.ILeScanCallback);
		}


		/// <summary>
		/// The on-click listener for all devices in the ListViews
		/// </summary>
		void DeviceListClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			// Cancel discovery because it's costly and we're about to connect
			btAdapter.CancelDiscovery ();

			// Get the device MAC address, which is the last 17 chars in the View
			var info = (e.View as TextView).Text.ToString ();
			var address = info.Substring (info.Length - 17);

			// Create the result Intent and include the MAC address
			Intent intent = new Intent ();
			intent.PutExtra (EXTRA_DEVICE_ADDRESS, address);

			// Set result and finish this Activity
			SetResult (Result.Ok, intent);
			Finish ();
		}


		//oufa
		//		void BluetoothAdapter.ILeScanCallback.OnLeScan (BluetoothDevice device, int rssi, byte[] scanRecord)
		//		{
		//			throw new NotImplementedException ();
		//		}

		public class Receiver : BroadcastReceiver
		{
			Activity _chat;
			String mac_addr = "";
			short maxRssi = -10000;

			Dictionary<string, short> macToRssi = new Dictionary<string, short> ();
			Dictionary<string, int> macToCount = new Dictionary<string, int> ();

			public Receiver (Activity chat)
			{
				_chat = chat;

			}



			public override void OnReceive (Context context, Intent intent)
			{

				string action = intent.Action;

				if (MyGlobals.readingsCounter == 3) {

					foreach (KeyValuePair<string, short> pair in macToRssi) {
						string mac = pair.Key;
						int avgRssi = pair.Value / macToCount [mac];
						if (avgRssi > maxRssi) {
							maxRssi = (short)avgRssi;
							mac_addr = mac;
						}
					}
					System.Diagnostics.Debug.WriteLine ("Debug 1");

					if (macToRssi.Count != 0) {
						System.Diagnostics.Debug.WriteLine ("Debug 2");

						Toast.MakeText (context2, "The total highest Mac Address " + mac_addr + " with RSSI " + maxRssi, ToastLength.Long).Show ();
					}
					System.Diagnostics.Debug.WriteLine ("Debug 3");

					macToRssi.Clear ();
					macToCount.Clear ();
					MyGlobals.readingsCounter = 0;

				} else {

					// When discovery finds a device
					if (action == BluetoothDevice.ActionFound) {
						// Get the BluetoothDevice object from the Intent
						BluetoothDevice device = (BluetoothDevice)intent.GetParcelableExtra (BluetoothDevice.ExtraDevice);
						short rssi = intent.GetShortExtra (BluetoothDevice.ExtraRssi, short.MinValue);
						string MacAddress = device.Address;
						if (device.BondState != Bond.Bonded && MacAddress.StartsWith ("20:")) {
							if (macToRssi.ContainsKey (MacAddress)) {
								macToRssi [MacAddress] += rssi;
								macToCount [MacAddress] += 1;
							} else {
								macToRssi.Add (MacAddress, rssi);
								macToCount.Add (MacAddress, 1);
							}
						}
					} else if (action == BluetoothAdapter.ActionDiscoveryFinished) {
						_chat.SetProgressBarIndeterminateVisibility (false);
					}

				}

			}

		}

		public class Discovery
		{

			BluetoothAdapter ba = BluetoothAdapter.DefaultAdapter;
			// This method will be called when the thread is started.
			public void DoWork2 ()
			{
				while (!_shouldStop) {
					// do discovery
					MyGlobals.readingsCounter++;
					DoDiscovery2 ();
					Thread.Sleep (10000);
					Console.WriteLine ("worker thread: working...");
				}
				Console.WriteLine ("worker thread: terminating gracefully.");
			}



			public void DoDiscovery2 ()
			{
				// if (Debug)
				// Log.Debug(TAG, "doDiscovery()");

				// Indicate scanning in the title
				//   SetProgressBarIndeterminateVisibility(true);
				// SetTitle("Scanning");

				// Turn on sub-title for new devices
				//  FindViewById<View>(Resource.Id.title_new_devices).Visibility = ViewStates.Visible;

				// If we're already discovering, stop it
				if (ba.IsDiscovering) {
					ba.CancelDiscovery ();
				}


				// Request discover from BluetoothAdapter
				ba.StartDiscovery ();
				//  btAdapter.CancelDiscovery();

				//oufa
				//btAdapter.StartLeScan(BluetoothAdapter.ILeScanCallback);
			}

			public void RequestStop ()
			{
				_shouldStop = true;
			}
			// Volatile is used as hint to the compiler that this data
			// member will be accessed by multiple threads.
			private volatile bool _shouldStop;
		}

		public static class MyGlobals
		{
			public static int readingsCounter { get; set; } = 0;

		}

	}
}





