using UnityEngine;
using System.Collections;

public class ShootAtom : MonoBehaviour {

	private bool walkingRight = true;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		GameObject sprite = GameObject.Find ("Sprite");
		walkingRight = sprite.GetComponent<Movements>().walkingDirection;
	}
	
	// Update is called once per frame
	void Update () {
		if (walkingRight) {
			transform.position += Vector3.right;
		} else if (!walkingRight) {
			transform.position += Vector3.left;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){

		GameObject uI = GameObject.Find("UI");

		if (collision.gameObject.CompareTag ("Robot") ||
		    collision.gameObject.CompareTag ("SmallEnemy")){

			uI.transform.gameObject.GetComponent<UI>().AddToScore(200);

			Destroy (collision.gameObject);
		}

		Vector3 explosionPos = new Vector3 (collision.transform.position.x, collision.transform.position.y, 0.0f);

		Instantiate (explosion, explosionPos, Quaternion.identity);

		Destroy (gameObject);
	}
}
