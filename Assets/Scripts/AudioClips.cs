using UnityEngine;
using System.Collections;

public class AudioClips : MonoBehaviour {

	public AudioClip jump;
	public AudioClip atomGet;
	public AudioClip atomUp;
	public AudioClip robotCrush;
	public AudioClip electrocution;
	public AudioClip shootExplosion;
	
	public void Jump(){
		audio.clip = jump;
		audio.Play ();
	}

	public void AtomGet() {
		audio.clip = atomGet;
		audio.Play ();
	}

	public void RobotCrush(){
		audio.clip = robotCrush;
		audio.Play ();
	}

	public void Electrocution(){
		audio.clip = electrocution;
		audio.Play ();
	}

	public void ShootExplosion(){
		audio.clip = shootExplosion;
		audio.Play ();
	}
}
