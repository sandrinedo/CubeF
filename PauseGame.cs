using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {
	public static bool gamepaused = false; 
	public CanvasGroup pausedCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P) && !gamepaused) {	
			Time.timeScale = 0;
			gamepaused = true;
		
		//	Debug.Log ("The game is paused");
		} else if (Input.GetKeyDown (KeyCode.P) && gamepaused) {
			Time.timeScale  = 1;
			gamepaused = false;
		//	Debug.Log("unpaused");
		}


		pausedCanvas.gameObject.SetActive (gamepaused);
	}
}
