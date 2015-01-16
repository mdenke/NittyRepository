package nitty.droid;


public class MyApp
	extends mono.android.app.Application
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
	}


	public MyApp () throws java.lang.Throwable
	{
		super ();
	}

	public MyApp (int p0) throws java.lang.Throwable
	{
		super ();
	}

	public void onCreate ()
	{
		mono.android.Runtime.register ("Nitty.Droid.MyApp, Tasky.Android, Version=1.0.5494.30833, Culture=neutral, PublicKeyToken=null", MyApp.class, __md_methods);
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
