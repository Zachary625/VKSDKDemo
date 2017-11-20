using System;
using System.Runtime.InteropServices;
using UnityEngine;

public static class VKSDK
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

	#if UNITY_ANDROID && !UNITY_EDITOR
	private static AndroidJavaClass _VKAPI_Android;
	private static AndroidJavaClass VKAPI_Android
	{
		get {
			if(_VKAPI_Android == null)
			{
				_VKAPI_Android = new AndroidJavaClass ("com.zachary625.vkdemo.vkapi.VKontakteApi");
			}
			return _VKAPI_Android;
		}
	}
	#endif


	public static bool Init (string appID)
	{
		#if UNITY_IOS && !UNITY_EDITOR
		return InitializeWithAppID (appID) != 0;
		#elif UNITY_ANDROID && !UNITY_EDITOR
		return true;
		#endif
		return false;
	}
	public static bool IsInited()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		return Initialized () != 0;
		#elif UNITY_ANDROID && !UNITY_EDITOR
		return true;
		#endif
		return false;
	}

	public static bool LoggedIn()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		return IsLoggedIn () != 0;
		#elif UNITY_ANDROID && !UNITY_EDITOR
		return VKAPI_Android.CallStatic<bool>("IsLoggedIn");
		#endif
		return false;
	}

	public static void Relogin()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		WakeUpSession ();
		#elif UNITY_ANDROID && !UNITY_EDITOR
		VKAPI_Android.CallStatic("WakeUpSession");
		#endif
	}
	public static void Login()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		Authorize ();
		#elif UNITY_ANDROID && !UNITY_EDITOR
		VKAPI_Android.CallStatic("Login", ToJava(new string[0]));
		#endif
	}
	public static void Logout()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		ForceLogout ();
		#elif UNITY_ANDROID && !UNITY_EDITOR
		VKAPI_Android.CallStatic("Logout");
		#endif
	}

	public static void WriteStringToClipboard(string content)
	{
		#if UNITY_IOS && !UNITY_EDITOR
		CopyStringToClipboard (content);
		#elif UNITY_ANDROID && !UNITY_EDITOR
		VKAPI_Android.CallStatic("CopyStringToClipboard", "vkdemo", content);
		#endif
	}

	public static string ReadStringFromClipboard()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		return CopyStringFromClipboard ();
		#elif UNITY_ANDROID && !UNITY_EDITOR
		return VKAPI_Android.CallStatic<string>("CopyStringFromClipboard");
		#endif
		return string.Empty;
	}

	#if UNITY_ANDROID && !UNITY_EDITOR
	private static AndroidJavaObject ToJava(string[] strings)
	{
		if(strings == null)
		{
			return null;
		}
		AndroidJavaClass javaArrayClass = new AndroidJavaClass ("java.lang.reflect.Array");
		AndroidJavaObject javaStringArrayInstance = javaArrayClass.CallStatic<AndroidJavaObject> ("newInstance", new AndroidJavaClass ("java.lang.String"), strings.Length);
		for (int i = 0; i < strings.Length; i++) {
			javaArrayClass.CallStatic ("set", javaStringArrayInstance, i, new AndroidJavaObject ("java.lang.String", strings [i]));
		}
		return javaStringArrayInstance;
	}
	#endif
}
