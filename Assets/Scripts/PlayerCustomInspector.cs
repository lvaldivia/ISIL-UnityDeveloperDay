using UnityEngine;
using System.Collections;

public class PlayerCustomInspector : MonoBehaviour {

	public enum State{
		IDDLE,RUNNING, JUMPING, ATTACKING
	}

	public string name;
	public string description;

	public float healht;
	public int damage;

	public int id;
	public float weapon1Damage,weapon2Damage;

	public float mana, stamina, alcohol;

	public State state;

	public bool alive;

	void Start () {
	
	}

	public void ChangeName(){
		name = Random.Range (10, 105)+"";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
