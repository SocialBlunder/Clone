using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movements : MonoBehaviour {
	private bool isOnGround = true;
	private float moveSpeed = 40.0f;
	private int walkingIndex = 0;

	public Sprite[] walkingSprites;
	public Text numOfAtomsText;
	public int numOfAtoms = 0;
	public AudioClip atomGet;
	public AudioClip jump;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 jumpPos = new Vector3 (0f, 130f, 0f);

		WalkingCycle (walkingIndex);
		
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && (isOnGround)) {
			this.rigidbody2D.velocity = jumpPos;
			audio.clip = jump;
			audio.Play();
		}
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
			walkingIndex = 3;
			WalkingCycle(walkingIndex);
			walkingIndex = 2;
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
			walkingIndex = 1;
			WalkingCycle(walkingIndex);
			walkingIndex = 0;
		}
	}

	void WalkingCycle (int walkInd) {
		this.GetComponent<SpriteRenderer>().sprite = walkingSprites[walkInd];
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		isOnGround = true;

		if (collision.gameObject.CompareTag ("Atom")) {
			audio.clip = atomGet;
			audio.loop = false;
			audio.Play();

			numOfAtoms += 1;
			numOfAtomsText.text = numOfAtoms.ToString ();
		}
	}
	
	void OnCollisionExit2D(Collision2D collision) {
		isOnGround = false;
	}
}
