using UnityEngine;
using System.Collections;

public class CloudsMove : MonoBehaviour {

	public float speedParam = 2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float deltaDistance = speedParam*Time.deltaTime;
		this.transform.position = new Vector3 (this.transform.position.x - deltaDistance, this.transform.position.y, this.transform.position.z);
	}
}
