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
	[DllImport("__Internal")]
	private static extern void WakeUpSession();
	[DllImport("__Internal")]
	private static extern int IsLoggedIn();
	[DllImport("__Internal")]
	private static extern void CopyStringToClipboard(string content);
	[DllImport("__Internal")]
	private static extern string CopyStringFromClipboard();
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

	public static bool _IsLoggedIn()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		return IsLoggedIn () != 0;
		#endif
		return false;
	}

	public static void _WakeUpSession()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		WakeUpSession ();
		#endif
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

	public static void _CopyStringToClipboard(string content)
	{
		#if UNITY_IOS && !UNITY_EDITOR
		CopyStringToClipboard (content);
		#endif
	}

	public static string _CopyStringFromClipboard()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		return CopyStringFromClipboard ();
		#endif
		return string.Empty;
	}
}
