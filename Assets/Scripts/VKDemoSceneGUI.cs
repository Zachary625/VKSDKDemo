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

		_LogClear ();
		_Log ("VKDemoSceneGUI.Start()");
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

	private void _LogInfo(string text)
	{
		_Log (string.Format("<color=lime>{0}</color>", text));
	}

	private void _LogError(string text)
	{
		_Log (string.Format("<color=red>{0}</color>", text));
	}

	private void _LogWarning(string text)
	{
		_Log (string.Format("<color=yellow>{0}</color>", text));
	}

	private void _LogClear()
	{
		LogText.text = string.Empty;
	}

	private void _Log(string text)
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
			_LogError ("Unknow button " + key);
		}
	}

	private void OnLoginButtonClick()
	{
		DisplayGUI (LoggedInGUI);
	}

	private void OnLogoutButtonClick()
	{
		DisplayGUI(LoggedOutGUI);
	}

	private void DisplayGUI(GameObject go)
	{
		LoggedInGUI.SetActive (LoggedInGUI == go);
		LoggedOutGUI.SetActive (LoggedOutGUI == go);
	}


}
