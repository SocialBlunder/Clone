using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Application.LoadLevel(name);
	}

	public void QuitRequest(string name) {
		Application.Quit();
	}
}
