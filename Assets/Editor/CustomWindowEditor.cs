using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.SceneManagement;
using System.IO;

public class CustomWindowEditor : EditorWindow {


	string bugName, description;
	GameObject bugObject;

	[MenuItem("Tools/BugReporter")]
	public static void ShowWindow(){
		EditorWindow.GetWindow (typeof(CustomWindowEditor));
	}

	public static EditorWindow GetWindow(){
		return EditorWindow.GetWindow (typeof(CustomWindowEditor));
	}

	public CustomWindowEditor(){
		this.titleContent = new GUIContent ("Bug Reporter");
	}

	void OnGUI(){
		GUILayout.BeginVertical();
		GUILayout.Space (10);
		GUI.skin.label.fontSize = 24;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUILayout.Label ("Bug Reporter");
		GUI.skin.label.fontSize = 12;
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUILayout.Space (20);
		bugName = EditorGUILayout.TextField ("Bug Name", bugName);
		GUILayout.Label ("Scene :" + EditorSceneManager.GetActiveScene().name);
		GUILayout.Space (10);
		GUILayout.Label ("Time" + System.DateTime.Now.ToString());
		GUILayout.Space (10);
		bugObject = (GameObject)EditorGUILayout.ObjectField ("Buggy Game Object", bugObject, typeof(GameObject), true);
		GUILayout.Space (10);
		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Description",GUILayout.MaxWidth(75));
		description = EditorGUILayout.TextArea (description, GUILayout.MaxHeight(75));
		GUILayout.EndHorizontal ();

		if (GUILayout.Button ("Save Bug")) {
			SaveBug ();
		}
		if(GUILayout.Button("Screenshot")){
			ScreenShot ();
			
		}
		GUILayout.EndVertical ();
	}

	void ScreenShot(){
		SaveBug ();
		Application.CaptureScreenshot ("Assets/BugReports/" + bugName + "/" + bugName + "_ScreenShot.png");
	}

	void SaveBug(){
		if (!Directory.Exists ("Assets/BugReports/" + bugName)) {
			Directory.CreateDirectory("Assets/BugReports/"+bugName);
		}
		StreamWriter sw = new StreamWriter ("Assets/BugReports/" + bugName + "/" + bugName + ".txt");
		sw.WriteLine (bugName);
		sw.WriteLine (System.DateTime.Now.ToString ());
		sw.WriteLine (EditorSceneManager.GetActiveScene ().name);
		sw.WriteLine (description);
		sw.Close ();
	}
		
}
