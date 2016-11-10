using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Enemy))]
public class HandleInspector : Editor {

	Enemy handleObject;

	void OnEnable(){
		handleObject = (Enemy)target;
	}

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();
	}

	void OnSceneGUI(){
		Handles.Label (handleObject.transform.position + new Vector3(0,1f,0), " Game Obejct "+handleObject.name);
		handleObject.radius = Handles.RadiusHandle (Quaternion.identity, handleObject.transform.position, handleObject.radius);
		handleObject.speed = Handles.ScaleValueHandle (handleObject.speed, handleObject.transform.position, Quaternion.identity, handleObject.speed, Handles.ArrowCap, 0.5f);

		for (int i = 0; i < handleObject.points.Length; i++) {
			handleObject.points[i] = Handles.PositionHandle (handleObject.points [i], handleObject.pointsRotation [i]);
		}
		Handles.color = Color.blue;
		for (int i = 0; i < handleObject.points.Length; i++) {
			Handles.DrawLine (handleObject.points [i], handleObject.points[(int)Mathf.Repeat(i+1,handleObject.points.Length)]);
		}

		for (int i = 0; i < handleObject.pointsRotation.Length; i++) {
			handleObject.pointsRotation [i] = Handles.RotationHandle (handleObject.pointsRotation [i],handleObject.points[i]);
		}

		Handles.BeginGUI ();
		GUILayout.BeginVertical ();
		GUILayout.BeginArea (new Rect(20,20,50,500));
		if(GUILayout.Button("Edit",GUILayout.MinHeight(50))){
			
		}
		if(GUILayout.Button("Add",GUILayout.MinHeight(50))){

		}
		if(GUILayout.Button("Delete",GUILayout.MinHeight(50))){

		}
		if(GUILayout.Button("Trash",GUILayout.MinHeight(50))){

		}
		if(GUILayout.Button("Other",GUILayout.MinHeight(50))){

		
		}
		GUILayout.EndArea ();
		GUILayout.EndVertical ();
		Handles.EndGUI ();

	}
}
