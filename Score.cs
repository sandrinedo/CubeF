using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Movement myScript;
	private float myCurrSpeed;
	public float myScore = 0;
	public Text myTextScore;

	// Use this for initialization
	void Start () {
		myTextScore.text = "0";
		myCurrSpeed = myScript.TargetSpeed;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Movement.inPlay) {
			myScore += myCurrSpeed *  Time.deltaTime;
			int myInt = (int) myScore;
			string myString = myInt.ToString();
			myTextScore.text = myString;
			//Debug.Log ((int) myScore);
		}
	

	}
}
