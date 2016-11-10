using UnityEngine;
using UnityEditor;
using System.Collections;

//[CustomEditor(typeof(PlayerCustomInspector))]
[CanEditMultipleObjects]
public class PlayerInspector2 : Editor {

	PlayerCustomInspector player;
	SerializedProperty name;
	SerializedProperty description;
	SerializedProperty healht;
	void OnEnable(){
		player = (PlayerCustomInspector)target;
		name = serializedObject.FindProperty ("name");
		description = serializedObject.FindProperty ("description");
		healht = serializedObject.FindProperty ("healht");
	}

	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();
		EditorGUILayout.BeginVertical ();
		EditorGUILayout.PropertyField (name);
		if (healht.floatValue < 20) {
			GUI.color = Color.red;
		}
		if (healht.floatValue > 80) {
			GUI.color = Color.green;
		}
		EditorGUILayout.PropertyField (healht);
		GUI.color = Color.white;
		EditorGUILayout.EndVertical ();
		serializedObject.ApplyModifiedProperties ();
	}
}
