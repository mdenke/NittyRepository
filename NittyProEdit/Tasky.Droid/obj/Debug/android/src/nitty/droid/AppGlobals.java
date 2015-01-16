package nitty.droid;


public class AppGlobals
	extends mono.android.app.Application
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
	}


	public AppGlobals () throws java.lang.Throwable
	{
		super ();
	}

	public AppGlobals (int p0) throws java.lang.Throwable
	{
		super ();
	}

	public void onCreate ()
	{
		mono.android.Runtime.register ("Nitty.Droid.AppGlobals, Tasky.Android, Version=1.0.5494.31895, Culture=neutral, PublicKeyToken=null", AppGlobals.class, __md_methods);
		super.onCreate ();
	}

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
