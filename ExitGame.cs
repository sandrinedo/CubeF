using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour {
	public CanvasGroup popUpCanvas;


	public void PopWindow(){
		popUpCanvas.gameObject.SetActive (true);
	}

	public void Exit(){
		Application.Quit();
	}

	public void UnpopWindow(){
		popUpCanvas.gameObject.SetActive (false);
	}

	void Update(){

		if (!PauseGame.gamepaused) {
			popUpCanvas.gameObject.SetActive(false);
		}

	}
}
