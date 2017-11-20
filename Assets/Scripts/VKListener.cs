using System.Collections;
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

	#region iOS
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
	if (string.IsNullOrEmpty (parameter))
	{
	return;
	}
	VKAccessTokenUpdate update = JsonUtility.FromJson<VKAccessTokenUpdate> (parameter);
	if (string.IsNullOrEmpty (update.newToken)) {
	VKInfo.AccessToken = new VKAccessToken();
	}
	else
	{
	VKInfo.AccessToken = JsonUtility.FromJson<VKAccessToken> (update.newToken);
	}
	GUI.LogCredentials ();
	}

	public void vkSdkTokenHasExpired(string parameter)
	{
	GUI.Log ("vkSdkTokenHasExpired: " + parameter);
	}

	public void vkSdkWakeUpSessionComplete(string parameter)
	{
	GUI.Log ("vkSdkWakeUpSessionComplete: " + parameter);
	VKAuthorizationState state = VKInfo.StringToAuthorizationState[parameter];
	if (state == VKAuthorizationState.VKAuthorizationAuthorized)
	{
	GUI.DisplayGUI (GUI.LoggedInGUI);
	}
	}

	public void vkSdkShouldPresentViewController()
	{
	GUI.Log ("vkSdkShouldPresentViewController");
	}

	public void vkSdkNeedCaptchaEnter(string parameter)
	{
	GUI.Log ("vkSdkNeedCaptchaEnter: " + parameter);
	VKError vkError = JsonUtility.FromJson<VKError> (parameter);
	}

	public void vkSdkWillDismissViewController()
	{
	GUI.Log ("vkSdkWillDismissViewController");
	}

	public void vkSdkDidDismissViewController()
	{
	GUI.Log ("vkSdkDidDismissViewController");
	}
	#endregion

	#region Android
	public void onVKAccessTokenChanged(string parameter)
	{
	GUI.Log ("onVKAccessTokenChanged: " + parameter);
	if (string.IsNullOrEmpty (parameter))
	{
	return;
	}
	VKAccessTokenUpdate update = JsonUtility.FromJson<VKAccessTokenUpdate> (parameter);
	if (string.IsNullOrEmpty (update.newToken)) {
	VKInfo.AccessToken = new VKAccessToken();
	}
	else
	{
	VKInfo.AccessToken = JsonUtility.FromJson<VKAccessToken> (update.newToken);
	}
	GUI.LogCredentials ();
	}

	public void onActivityResult(string parameter)
	{
	GUI.Log ("onActivityResult: " + parameter);
	VKAccessToken accessToken = JsonUtility.FromJson<VKAccessToken> (parameter);
	}

	public void onActivityError(string parameter)
	{
	GUI.Log ("onActivityError: " + parameter);
	VKError error = JsonUtility.FromJson<VKError> (parameter);
	}

	public void onWakeUpSessionResult(string parameter)
	{
	GUI.Log ("onWakeUpSessionResult: " + parameter);
	VKLoginState loginState = VKInfo.StringToLoginState[parameter];
	}

	public void onWakeUpSessionError(string parameter)
	{
	GUI.Log ("onWakeUpSessionError: " + parameter);
	VKError error = JsonUtility.FromJson<VKError> (parameter);
	}
	#endregion
}
