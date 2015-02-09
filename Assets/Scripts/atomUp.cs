using UnityEngine;
using System.Collections;

public class atomUp : MonoBehaviour {

	public Sprite newSprite;
	public GameObject newAtom;
	
	Vector3 atomPos = new Vector3 (33.3f, 19.2f, 0f);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		this.GetComponent<SpriteRenderer>().sprite = newSprite;
		GameObject.Instantiate(newAtom);
		newAtom.transform.position = atomPos;
	}
}
