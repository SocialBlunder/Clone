using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	Animator myAnimator;

	public bool walkingLeft = true;
	public float moveSpeed = 22.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (walkingLeft) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		} else {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}

	}

	void OnTriggerEnter2D (Collider2D collider){

		if (collider.gameObject.CompareTag ("RobotTrigger")) {
			myAnimator = GetComponent<Animator> ();

			if (walkingLeft) {
				myAnimator.CrossFade ("WalkingRight", 0.2f);

				walkingLeft = false;
			} else {
				myAnimator.CrossFade ("WalkingLeft", 0.2f);
			
				walkingLeft = true;
			}
		}
	}
}
