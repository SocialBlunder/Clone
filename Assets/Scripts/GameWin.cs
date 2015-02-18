using UnityEngine;
using System.Collections;

public class GameWin : MonoBehaviour {

	public LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D collider){
		if (!collider.gameObject.CompareTag ("ShootAtom")) {
			levelManager.LoadLevel ("GameWin");
		}
	}
}
