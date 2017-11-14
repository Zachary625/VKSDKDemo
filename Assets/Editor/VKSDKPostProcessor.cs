using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.Callbacks;
using UnityEditor.XCodeEditor;
using UnityEditor.iOS.Xcode;

public class VKSDKPostProcessor {

	#if UNITY_EDITOR
	[PostProcessBuild(1000)]
	public static void OnPostProcessBuild( BuildTarget target, string pathToBuiltProject )
	{
		if (target != BuildTarget.iOS) {
			Debug.LogWarning("Target is not iPhone. VKSDKPostProcessor will not run");
			return;
		}
	}
#endif
}

