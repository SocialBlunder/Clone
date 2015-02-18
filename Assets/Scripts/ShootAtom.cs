using UnityEngine;
using System.Collections;

public class ShootAtom : MonoBehaviour {

	private bool walkingRight = true;

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

		GameObject audioClips = GameObject.Find("AudioClips");
		GameObject uI = GameObject.Find("UI");

		if (collision.gameObject.CompareTag ("Robot") ||
		    collision.gameObject.CompareTag ("SmallEnemy")){

			audioClips.transform.gameObject.GetComponent<AudioClips>().ShootExplosion();
			uI.transform.gameObject.GetComponent<UI>().AddToScore(200);

			Destroy (collision.gameObject);
		}

		audioClips.transform.gameObject.GetComponent<AudioClips>().ShootExplosion();
		Destroy (gameObject);
	}
}
