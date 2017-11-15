using System;
using System.Runtime.InteropServices;

public class VKAPI
{
	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern int InitializeWithAppID (string appID);
	[DllImport("__Internal")]
	private static extern int Initialized ();
	[DllImport("__Internal")]
	private static extern void Authorize ();
	[DllImport("__Internal")]
	private static extern int ForceLogout ();
	#endif
	private static VKAPI _I = new VKAPI();
	public static VKAPI I
	{
		get { return _I; }
	}

	public bool InitializeWithAppID (string appID)
	{
		#if UNITY_IOS && !UNITY_EDITOR
		return VKAPI.InitializeWithAppID (appID) != 0;
		#endif
		return false;
	}
	public bool Initailized()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		return VKAPI.Initialized ();
		#endif
		return false;
	}
	public void Authorize()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		VKAPI.Authorize ();
		#endif
	}
	public void ForceLogout()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		VKAPI.ForceLogout ();
		#endif
	}


}
