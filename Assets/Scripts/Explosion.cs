using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private float timeParam = 0;
	private float countDown = 1.0f;
	public AudioClip shootExplosion;

	// Use this for initialization
	void Start () {
		audio.clip = shootExplosion;
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeParam <= 1) {
			timeParam += Time.deltaTime * 1.0f;
			
			float explosionNewScale = Mathf.Lerp(1, 5, timeParam);
			
			transform.localScale = new Vector3 (explosionNewScale, explosionNewScale, 0);
		}

		countDown -= Time.deltaTime;
		
		if (countDown <= 0f) {
			Destroy (gameObject);
		}
	}
}
