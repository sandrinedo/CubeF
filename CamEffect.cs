using UnityEngine;
using System.Collections;

public class CamEffect : MonoBehaviour {
	public float effectDuration = 4f;
	private float origFOV;
	public float targetFOV;
	private bool startEffect = false;
	private float timer = 0f;
	private float clampedTimer;
	// Use this for initialization
	void Start () {
		origFOV = Camera.main.fieldOfView;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Obstacle") {
			startEffect = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (startEffect) {
			timer += Time.deltaTime;
			clampedTimer = timer / effectDuration;
			Camera.main.fieldOfView = Mathf.Lerp(targetFOV, origFOV, clampedTimer);
			if(timer > effectDuration){
				startEffect = false;
				timer =0f;
			}
		}
	}
}
