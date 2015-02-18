using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public UI uI;
	public GameObject shootAtom;
	public Movements movements;
	private float rightOrLeft;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Shoot(){

		if (movements.walkingDirection) {
			rightOrLeft = 8.0f;
		} else if (!movements.walkingDirection) {
			rightOrLeft = -8.0f;
		}

		Vector2 firePos = new Vector2 (transform.position.x + rightOrLeft, transform.position.y);

		if (uI.numOfAtoms > 0) {
			uI.RemoveAtom();

			Instantiate (shootAtom, firePos, Quaternion.identity);

		}
	}

}
