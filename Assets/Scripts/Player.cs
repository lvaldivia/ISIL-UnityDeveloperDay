using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public enum State{
		IDDLE,RUNNING, JUMPING, ATTACKING
	}

	public string name;
	[Multiline]
	public string description;

	[Range(0,100)]
	public float healht;
	[Range(0,100)]
	public int damage;

	[HideInInspector]
	public int id;

	[Header("Weapon")]
	public string weaponName;
	public float weaponDamage;

	[Tooltip("Current state for the player")]
	public State state;



	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
