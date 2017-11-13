using UnityEngine;
using System.Collections;

public static class VKInfo {
	public static int AppID = 6257405;
	public static string SecureKey = "Mnq5qUxqKL9fAlMCiotT";
	public static string ServiceToken = "9a09b88b9a09b88b9a09b88bd99a56c27699a099a09b88bc000ad86163e6492aa16354e";

	public static string URLScheme_Name_iOS { get { return "vk" + AppID; } }
	public static string URLScheme_Scheme_iOS { get { return "vk" + AppID; } }
}
