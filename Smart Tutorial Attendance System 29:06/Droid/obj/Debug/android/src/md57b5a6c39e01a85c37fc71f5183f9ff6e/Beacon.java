package md57b5a6c39e01a85c37fc71f5183f9ff6e;


public class Beacon
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"";
		mono.android.Runtime.register ("GUC_Attendance.Droid.Beacon, GUC Attendance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Beacon.class, __md_methods);
	}


	public Beacon () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Beacon.class)
			mono.android.TypeManager.Activate ("GUC_Attendance.Droid.Beacon, GUC Attendance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
