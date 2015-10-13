using UnityEngine;
using System.Collections;

public class CubeDestroy : MonoBehaviour {
	public GameObject destroyParticles;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider obj){

		if (obj.gameObject.tag == "Player") {
			Instantiate(destroyParticles, transform.position, Quaternion.identity); 
			Destroy (gameObject);
		}
	}
}
