using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class VKDemoSceneGUI : MonoBehaviour {

	public Text LogText;
	public Text CredentialText;
	public GameObject IdentificationGUI = null;
	public GameObject LoggedOutGUI = null; // logged out gui
	public GameObject LoggedInGUI = null; // logged in gui
	// public GameObject SocialGUI; // social gui(friends etc.)

	void Awake() 
	{
	}

	// Use this for initialization
	void Start () {
		_ButtonCallbacks.Add ("ButtonWakeUpSession", OnWakeUpButtonClick);
		_ButtonCallbacks.Add ("ButtonIsLoggedIn", OnIsLoggedInButtonClick);
		_ButtonCallbacks.Add ("ButtonLogin", OnLoginButtonClick);
		_ButtonCallbacks.Add ("ButtonLogout", OnLogoutButtonClick);
		_ButtonCallbacks.Add ("ButtonCopyCredential", OnCopyCredentialButtonClick);

		PrepareButtons (IdentificationGUI);
		PrepareButtons (LoggedOutGUI);
		PrepareButtons (LoggedInGUI);

		DisplayGUI (LoggedOutGUI);

		LogClear ();
		Log ("VKDemoSceneGUI.Start()");

		bool initResult = VKSDK.Init (VKInfo.AppID);
		Log (string.Format(
			"InitializeWithAppID({0}): {1}\nInitialized(): {2}\nLogged in: {3}", VKInfo.AppID, initResult, VKSDK.IsInited(), VKSDK.LoggedIn()));
	}

	private void PrepareButtons(GameObject root)
	{
		if (root == null) {
			return;	
		}
		foreach (Button childButton in root.GetComponentsInChildren<Button>(true)) {
			Button clickedButton = childButton;
			childButton.onClick.AddListener(delegate
				{
					ButtonCallbackHub(clickedButton);
				}
			);
		}
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LogInfo(string text)
	{
		Log (string.Format("<color=green>{0}</color>", text));
	}

	public void LogError(string text)
	{
		Log (string.Format("<color=red>{0}</color>", text));
	}

	public void LogWarning(string text)
	{
		Log (string.Format("<color=yellow>{0}</color>", text));
	}

	public void LogClear()
	{
		LogText.text = string.Empty;
	}

	public void Log(string text)
	{
		LogText.text += ("\n" + text);
	}

	private delegate void ButtonCallback();
	private Dictionary<string, ButtonCallback> _ButtonCallbacks = new Dictionary<string, ButtonCallback> ();

	private void ButtonCallbackHub(Button button)
	{
		string key = button.name;
		if (_ButtonCallbacks.ContainsKey (key)) {
			_ButtonCallbacks[key]();
		} else {
			LogError ("Unknow button " + key);
		}
	}

	private void OnWakeUpButtonClick()
	{
		VKSDK.Relogin ();
	}

	private void OnIsLoggedInButtonClick()
	{
		LogInfo ("IsLoggedIn: " + VKSDK.LoggedIn());
	}
	private void OnLoginButtonClick()
	{
		VKSDK.Login ();
	}

	private void OnLogoutButtonClick()
	{
		VKSDK.Logout ();
		DisplayGUI (LoggedOutGUI);
	}

	private void OnCopyCredentialButtonClick()
	{
		LogCredentials ();
	}

	public void DisplayGUI(GameObject go)
	{
		if (LoggedInGUI != null)
		{
			LoggedInGUI.SetActive (LoggedInGUI == go);
		}
		if (LoggedOutGUI != null)
		{
			LoggedOutGUI.SetActive (LoggedOutGUI == go);
		}
	}

	public void LogCredentials()
	{
		string json = JsonUtility.ToJson (VKInfo.AccessToken);
		LogInfo (json);
		VKSDK.WriteStringToClipboard (json);
	}

}
