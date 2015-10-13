using UnityEngine;
using System.Collections;

public class ChangeAlpha : MonoBehaviour {
	private MeshRenderer mrend;
	private float distance;
	private GameObject ship;
	private Color color;
	private float timer;
	private float clampedTimer;
	private bool fadeIn;
	// Use this for initialization
	void Start () {

		mrend = GetComponent<MeshRenderer>();
		//ship = GameObject.FindGameObjectWithTag ("Player");
		color = mrend.material.color;
	}
	void OnDisable(){
		color.a = 0f;
		mrend.material.color = color;
		timer = 0f;
		fadeIn = false;
		//Debug.Log ("OnDisable "+timer);
	}

	void OnEnable(){
		//color.a = 0f;
	//	Debug.Log (color.a);
		fadeIn = true;
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (color.a);
		//distance = Vector3.Distance (transform.position, ship.transform.position);
		if (fadeIn) {


			timer += Time.deltaTime;
			clampedTimer = timer / 0.5f;
			color.a = Mathf.Lerp (0f, 1f, clampedTimer);
			mrend.material.color = color;

		}

	//	Debug.Log (color.a);
	}
}
