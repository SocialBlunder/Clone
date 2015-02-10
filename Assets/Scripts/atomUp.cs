using UnityEngine;
using System.Collections;

public class AtomUp : MonoBehaviour {

	public Sprite newSprite;
	public GameObject newAtom;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		Vector3 atomPos = new Vector3 (transform.position.x, transform.position.y + 12f, 0f);

		GetComponent<SpriteRenderer>().sprite = newSprite;
		GameObject.Instantiate (newAtom, atomPos, Quaternion.identity);

		collider2D.enabled = false;
	}
}
