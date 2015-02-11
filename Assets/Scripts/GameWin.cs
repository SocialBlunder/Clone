using UnityEngine;
using System.Collections;

public class GameWin : MonoBehaviour {

	public LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D collider){
		levelManager.LoadLevel ("GameWin");
	}
}
