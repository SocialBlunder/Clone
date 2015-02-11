using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D collider){
		levelManager.LoadLevel ("GameOver");
	}
}
