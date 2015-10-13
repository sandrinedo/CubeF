using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class restartGame : MonoBehaviour {
	public Button restartButton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (CountLives.dead) {
			restartButton.gameObject.SetActive (true);
		} else {
			restartButton.gameObject.SetActive(false);
		}
	}

	public void relaunch(){
		Application.LoadLevel (0);
	}
}
