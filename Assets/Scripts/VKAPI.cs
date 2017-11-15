using System;
using System.Runtime.InteropServices;

public static class VKAPI
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

	public static bool _InitializeWithAppID (string appID)
	{
		#if UNITY_IOS && !UNITY_EDITOR
		return InitializeWithAppID (appID) != 0;
		#endif
		return false;
	}
	public static bool _Initailized()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		return Initialized () != 0;
		#endif
		return false;
	}
	public static void _Authorize()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		Authorize ();
		#endif
	}
	public static void _ForceLogout()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		ForceLogout ();
		#endif
	}


}
