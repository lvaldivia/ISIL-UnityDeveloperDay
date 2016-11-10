using UnityEngine;
using System.Collections;

public class EnemysGizmo : MonoBehaviour {

	public float radius;
	public float speed;
	public Vector3[] points;
	public Quaternion[] pointsRotation;
	void Start () {

	}
		
	void Update () {

	}

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, radius);
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (transform.position, transform.position + transform.forward * speed);

		for (int i = 0; i < points.Length; i++) {
			Gizmos.DrawSphere (points [i], 0.2f);
		}
		Gizmos.color = Color.white;

		for (int i = 0; i < points.Length; i++) {
			Gizmos.DrawLine (points [i], points[(int)Mathf.Repeat(i+1,points.Length)]);
		}
	}

	void OnDrawGizmoSelected(){
		
	}
}
