using UnityEngine;
using System.Collections;

public class HatchMonster : MonoBehaviour {

	private float movementSpeed = 0.2f;
	private bool moveUp = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (-48.0f > transform.position.y) {
			moveUp = true;
		} 

		if (transform.position.y > 10.0f) {
			moveUp = false;
		}

		if (moveUp) {
			transform.position += Vector3.up * movementSpeed;
		}
		
		if (!moveUp) {
			transform.position += Vector3.down * movementSpeed;
		}
	}
}