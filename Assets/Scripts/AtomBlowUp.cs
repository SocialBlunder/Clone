using UnityEngine;
using System.Collections;

public class AtomBlowUp : MonoBehaviour {

	public AudioClip sound;
	
	private float timeParam = 0;

	void Start () {
		audio.clip = sound;
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeParam <= 1) {
			timeParam += Time.deltaTime * 0.5f;
			
			float atomNewScale = Mathf.Lerp(1, 2, timeParam);
			
			transform.localScale = new Vector3 (atomNewScale, atomNewScale, 0);
		}
	}
	

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy (gameObject);
	}
	
}