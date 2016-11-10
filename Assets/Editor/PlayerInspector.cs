using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(PlayerCustomInspector))]
public class PlayerInspector : Editor {

	PlayerCustomInspector player;
	bool showWeapons;
	PlayerCustomInspector.State op;
	EditorWindow editorWindow;
	void OnEnable(){
		player = (PlayerCustomInspector)target;
	}

	public override void OnInspectorGUI ()
	{
		EditorGUILayout.BeginVertical ();
		EditorGUILayout.LabelField ("Primer label "+player.id);
		player.name = EditorGUILayout.TextField ("Personaje", player.name);
		player.description = EditorGUILayout.TextArea (player.description, GUILayout.MinHeight (70));
		if (player.healht < 20) {
			GUI.color = Color.red;
		} else if(player.healht>80) {
			GUI.color = Color.green;
		}
		Rect progressRect = GUILayoutUtility.GetRect (50, 50);
		EditorGUI.ProgressBar (progressRect,player.healht / 100f, "Health");
		EditorGUILayout.LabelField ("Health "+player.healht);
		//player.healht = EditorGUILayout.FloatField ("Health", player.healht);
		GUI.color = Color.white;
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		player.damage = EditorGUILayout.IntSlider ("Damage",player.damage, 10, 20);

		if (player.damage < 12) {
			EditorGUILayout.HelpBox ("Muy poco", MessageType.Warning);
		}
		if (player.damage > 18) {
			EditorGUILayout.HelpBox ("Muy poco", MessageType.Info);
		}
			

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		showWeapons = EditorGUILayout.Foldout (showWeapons,"Weapons");
		if(showWeapons){
			player.weapon1Damage = EditorGUILayout.FloatField ("Weapon Damage 1", player.weapon1Damage);
			player.weapon2Damage = EditorGUILayout.FloatField ("Weapon Damage 2", player.weapon2Damage);	
		}

		EditorGUILayout.LabelField ("Powers");
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField ("Stamina", GUILayout.MinWidth (50));
		player.stamina = EditorGUILayout.FloatField (player.stamina);
		EditorGUILayout.LabelField ("Mana", GUILayout.MinWidth (50));
		player.mana = EditorGUILayout.FloatField (player.mana);
		EditorGUILayout.LabelField ("Alcohol", GUILayout.MinWidth (50));
		player.alcohol = EditorGUILayout.FloatField (player.alcohol);
		EditorGUILayout.EndHorizontal ();

		player.alive = EditorGUILayout.Toggle ("Alife", player.alive);


		op = (PlayerCustomInspector.State)EditorGUILayout.EnumPopup ("State ", op);
		player.state = op;
		if (GUILayout.Button ("Change Name")) {
			player.ChangeName ();
		}
		if(GUILayout.Button("Report Bug")){
			editorWindow = CustomWindowEditor.GetWindow ();
		}
		if(GUILayout.Button("Close")){
			editorWindow.Close ();
		}
		EditorGUILayout.EndVertical ();
		player.healht += 2f;
		if (player.healht > 100) {
			player.healht = 0;
		}
	}
}
