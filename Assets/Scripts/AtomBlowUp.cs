using UnityEngine;
using System.Collections;

public class AtomBlowUp : MonoBehaviour {
	
	private float timeParam = 0;

	void Start () {
		GameObject audioTemp = GameObject.Find ("AudioClips");

		AudioClip atomUp = audioTemp.GetComponent<AudioClips>().atomUp;

		audio.clip = atomUp;
		audio.loop = true;
		audio.Play ();
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

		if (!collision.gameObject.CompareTag ("SmallEnemy")) {
		
			Destroy (gameObject);
		}
	}
	
}