using UnityEngine;
using System.Collections;

public class FloatingPlatform : MonoBehaviour {

	public bool movingLeft = true;
	public float moveSpeed = 52.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (movingLeft) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		} else {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
	
	}

	void OnTriggerEnter2D (Collider2D collider){
		
		if (collider.gameObject.CompareTag ("FloatingPlatformTrigger") ) {
			if (movingLeft) {
				movingLeft = false;
			} else {
				movingLeft = true;
			}
		}
	}
}
