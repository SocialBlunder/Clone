using UnityEngine;
using System.Collections;

public class AtomBlowUp : MonoBehaviour {

	public AudioClip sound1;
	public AudioClip sound2;
	
	//private float scaleSpeed = 20f;
	private float finalScale = 25f;
	private float timer = 0.0f;
	// Use this for initialization
	void Start () {
		this.audio.clip = sound1;
		this.audio.loop = true;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	void OnCollisionEnter2D(Collision2D collision) {
		this.particleSystem.startSize = 5;
		this.particleSystem.loop = false;
		this.particleSystem.startColor = new Color32(128,128,128,255);
		this.GetComponent<SpriteRenderer>().color = new Color32(128,128,128,255);
		this.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(3,3,0);
		this.audio.clip = sound2;
		this.audio.loop = false;
		audio.Play();
	}
	
}