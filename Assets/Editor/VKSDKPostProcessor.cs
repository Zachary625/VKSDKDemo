using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.Callbacks;
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
		ManipulateInfoPList (pathToBuiltProject);
		ManipulateEmbedFramework (pathToBuiltProject);

	}

	private static void ManipulateInfoPList (string builtXCodeProjectPath)
	{
		string infoPListFilePath = builtXCodeProjectPath + "/Info.plist";
		PlistDocument infoPList = new PlistDocument ();
		infoPList.ReadFromFile (infoPListFilePath);

		PlistElementDict dictionary = infoPList.root.AsDict ();
		PlistElementArray lsApplicationQueriesSchemes = dictionary.CreateArray ("LSApplicationQueriesSchemes");
		lsApplicationQueriesSchemes.AddString ("vk");
		lsApplicationQueriesSchemes.AddString ("vk-share");
		lsApplicationQueriesSchemes.AddString ("vkauthorize");

		infoPList.WriteToFile (infoPListFilePath);
	}

	private static void ManipulateEmbedFramework(string builtXCodeProjectPath)
	{
		string pbxProjFilePath = builtXCodeProjectPath + "/Unity-iPhone.xcodeproj/project.pbxproj";
		string relativeDirectoryToFramework = "../VKontakte/";
		string frameworkName = "VKSdkFramework.framework";
		PBXProject project = new PBXProject ();
		project.ReadFromFile (pbxProjFilePath);
		string buildTarget = project.TargetGuidByName ("Unity-iPhone");

//		string frameworkPath = project.FindFileGuidByRealPath ("../../../VKSDKDemo/Assets/Editor/XUPorter/Mods/../../../../VKontakte/VkSdkFramework.framework");

		string completeDirectory = Application.dataPath + "/" + relativeDirectoryToFramework;
		string completePath = completeDirectory + frameworkName;
		string frameworkPath = project.AddFile(completePath, "VKontakte/" + frameworkName, PBXSourceTree.Source);
		project.AddFileToBuild(buildTarget, frameworkPath);

		string embedPhase = project.AddCopyFilesBuildPhase (buildTarget, "Embed Frameworks", "", "10");
		project.AddFileToBuildSection (buildTarget, embedPhase, frameworkPath);

		//project.AddBuildProperty (buildTarget, "FRAMEWORK_SEARCH_PATHS", "$(SRCROOT)/" + relativeDirectoryToFramework);
		project.AddBuildProperty (buildTarget, "FRAMEWORK_SEARCH_PATHS", completeDirectory);
		project.WriteToFile (pbxProjFilePath);
	}

#endif
}

