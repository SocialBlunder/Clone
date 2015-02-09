using UnityEngine;
using System.Collections;

public class CameraMotion : MonoBehaviour {
	public Camera cam;
	public GameObject person;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		cam.transform.position = new Vector3 (person.transform.position.x, 0f, -10f);
	}
	
}