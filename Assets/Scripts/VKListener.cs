﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VKListener : MonoBehaviour {

	public VKDemoSceneGUI GUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void vkSdkAccessAuthorizationFinishedWithResult(string parameter)
	{
		GUI.Log ("vkSdkAccessAuthorizationFinishedWithResult: " + parameter);
		VKAuthorizationResult result = JsonUtility.FromJson<VKAuthorizationResult> (parameter);
		if (VKInfo.StringToAuthorizationState [result.state] == VKAuthorizationState.VKAuthorizationAuthorized)
		{
			GUI.DisplayGUI (GUI.LoggedInGUI);
		}
	}

	public void vkSdkUserAuthorizationFailed(string parameter)
	{
		GUI.Log ("vkSdkUserAuthorizationFailed: " + parameter);
	}

	public void vkSdkAuthorizationStateUpdatedWithResult(string parameter)
	{
		GUI.Log ("vkSdkAuthorizationStateUpdatedWithResult: " + parameter);
	}

	public void vkSdkAccessTokenUpdated(string parameter)
	{
		GUI.Log ("vkSdkAccessTokenUpdated: " + parameter);
	}

	public void vkSdkTokenHasExpired(string parameter)
	{
		GUI.Log ("vkSdkTokenHasExpired: " + parameter);
	}
}