using UnityEngine;
using System.Collections;

public class ParticleTrigger : MonoBehaviour {
	private ParticleSystem myEmitter;
	public GameObject cube;
	private bool disable = false;

	void Start(){
		//myEmitter.Play ();
		myEmitter = GetComponent<ParticleSystem> ();
		myEmitter.emissionRate = 0;
	}

	void Update(){
		if (cube == null) {
		//	Debug.Log ("null");
			disable = true;
			myEmitter.enableEmission = false;
		}
	}

	void OnTriggerEnter (Collider obj) {
		if (!disable) {
			myEmitter.Emit (20);
		//	Debug.Log ("particle");
		}
	}
}
