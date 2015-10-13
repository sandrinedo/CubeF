using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
	public float TargetSpeed = 20f;
	public float mySpeed;
	private float turn;
	public float rotationSpeed = 0.5f;
	public static bool inPlay = false;
	float rVelocity = 0.0f;
	private float currSpeed;
	private float timer = 0f;
	private float clampedTimer;
	public float duration = 4f;
	private int antiSpam;
	//"Press Jump to start label
	public Text startLabel; 
	// Use this for initialization
	void Start () {
		antiSpam = 0;
		inPlay = false;
		startLabel.gameObject.SetActive (true); 
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space) && antiSpam == 0) {
			antiSpam ++;
			inPlay = true;
			startLabel.gameObject.SetActive(false);
		}

		if (inPlay) {
			mySpeed = Mathf.SmoothDamp (0, TargetSpeed, ref rVelocity, 0.85f);
			currSpeed = mySpeed;
		} 

		if (CountLives.dead) {
			inPlay = false;
			timer += Time.deltaTime;
			clampedTimer = timer/duration;
			mySpeed = Mathf.Lerp (currSpeed, 0f, clampedTimer);

		}
	

	}

	// Update is called once per frame
	void FixedUpdate () {
		
		//Solution #1
		if (inPlay) {
			turn = Input.GetAxis ("Horizontal");
			transform.Rotate (0f, turn, 0f);
		} else {
			turn = 0f;
		}
		
		//Solution #2
		//		turn = Input.GetAxis ("Horizontal")* rotationSpeed;
		//		turn *= Time.deltaTime;
		//		transform.Rotate (0f, turn, 0f);
		
	
		
		transform.Translate (0f, 0f, mySpeed*Time.timeScale);
		//Debug.Log (mySpeed);
		
	}
}
