﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class VKInfo {
	public static string AppID = "6257405";
	public static string SecureKey = "Mnq5qUxqKL9fAlMCiotT";
	public static string ServiceToken = "9a09b88b9a09b88b9a09b88bd99a56c27699a099a09b88bc000ad86163e6492aa16354e";

	public static string URLScheme_Name_iOS { get { return "vk" + AppID; } }
	public static string URLScheme_Scheme_iOS { get { return "vk" + AppID; } }

	public static VKAccessToken AccessToken;

	public static Dictionary<string, VKAuthorizationState> StringToAuthorizationState = new Dictionary<string, VKAuthorizationState> ()
	{
		{"VKAuthorizationUnknown", VKAuthorizationState.VKAuthorizationUnknown},
		{"VKAuthorizationInitialized", VKAuthorizationState.VKAuthorizationInitialized},
		{"VKAuthorizationPending", VKAuthorizationState.VKAuthorizationPending},
		{"VKAuthorizationExternal", VKAuthorizationState.VKAuthorizationExternal},
		{"VKAuthorizationSafariInApp", VKAuthorizationState.VKAuthorizationSafariInApp},
		{"VKAuthorizationWebview", VKAuthorizationState.VKAuthorizationWebview},
		{"VKAuthorizationAuthorized", VKAuthorizationState.VKAuthorizationAuthorized},
		{"VKAuthorizationError", VKAuthorizationState.VKAuthorizationError},
	};

	public static Dictionary<string, VKLoginState> StringToLoginState = new Dictionary<string, VKLoginState>()
	{
		{"Unknown", VKLoginState.Unknown},
		{"Pending", VKLoginState.Pending},
		{"LoggedOut", VKLoginState.LoggedOut},
		{"LoggedIn", VKLoginState.LoggedIn},
	};
}

public struct VKAuthorizationResult
{
	public string state;
	public string user;
	public string token;
}

public struct VKUser
{
	public string id;
	public string nickname;
	public string first_name;
	public string last_name;
	public string screen_name;
	public string bdate;
	public string sex;
	public string status;
}

public struct VKAccessToken
{
	public string userId;
	public string accessToken;
	public string secret;
	public string created;
	public string expiresIn;
	public string httpsRequired;
}

public struct VKAccessTokenUpdate
{
	public string oldToken;
	public string newToken;
}

public enum VKAuthorizationState
{
	VKAuthorizationUnknown,
	VKAuthorizationInitialized,
	VKAuthorizationPending,
	VKAuthorizationExternal,
	VKAuthorizationSafariInApp,
	VKAuthorizationWebview,
	VKAuthorizationAuthorized,
	VKAuthorizationError,
}

public struct VKError
{
	public string captchaSid;
	public string captchaImg;
	public string errorCode;
	public string errorText;
	public string errorMessage;
	public string errorReason;
	public string redirectUri;
	public string debugDescription;
}

public enum VKLoginState
{
	Unknown,
	Pending,
	LoggedOut,
	LoggedIn,
}