package md5b1f72f21486fac351793985de14c6334;


public class BookViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("RecyclerView_Xamarin.Droid.BookViewHolder, RecyclerView_Xamarin.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BookViewHolder.class, __md_methods);
	}


	public BookViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == BookViewHolder.class)
			mono.android.TypeManager.Activate ("RecyclerView_Xamarin.Droid.BookViewHolder, RecyclerView_Xamarin.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
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
