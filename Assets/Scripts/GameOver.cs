using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public LevelManager levelManager;
	public UI uI;
	
	void OnTriggerEnter2D (Collider2D collider){
		uI.RemoveLife();
		if (GameStart.numOfLives <= 0) {		
			levelManager.LoadLevel ("GameOver");
			GameStart.numOfLives = 3;
		} else {
			levelManager.LoadLevel ("Game");
		}
	}
}
