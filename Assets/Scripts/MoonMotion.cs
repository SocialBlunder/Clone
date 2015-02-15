using UnityEngine;
using System.Collections;

public class MoonMotion : MonoBehaviour {

	public GameObject person;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (person.transform.position.x+38f, this.transform.position.y, this.transform.position.z);
	}
}
