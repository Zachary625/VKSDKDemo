using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class VKDemoSceneGUI : MonoBehaviour {

	public Text LogText;
	public GameObject LoggedOutGUI; // logged out gui
	public GameObject LoggedInGUI; // logged in gui
	// public GameObject SocialGUI; // social gui(friends etc.)

	void Awake() 
	{
	}

	// Use this for initialization
	void Start () {
		_ButtonCallbacks.Add ("ButtonLogin", OnLoginButtonClick);
		_ButtonCallbacks.Add ("ButtonLogout", OnLogoutButtonClick);

		PrepareButtons (LoggedOutGUI);
		PrepareButtons (LoggedInGUI);

		DisplayGUI (LoggedOutGUI);

		LogClear ();
		Log ("VKDemoSceneGUI.Start()");

		bool initResult = VKAPI.I.InitializeWithAppID (VKInfo.AppID);
		Log (string.Format("InitializeWithAppID({0}): {1}, Initialized(): {2}", VKInfo.AppID, initResult, VKAPI.I.Initailized()));
	}

	private void PrepareButtons(GameObject root)
	{
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
		Log (string.Format("<color=lime>{0}</color>", text));
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

	private void OnLoginButtonClick()
	{
		VKAPI.I.Authorize ();
	}

	private void OnLogoutButtonClick()
	{
		VKAPI.I.ForceLogout ();
	}

	public void DisplayGUI(GameObject go)
	{
		LoggedInGUI.SetActive (LoggedInGUI == go);
		LoggedOutGUI.SetActive (LoggedOutGUI == go);
	}


}
