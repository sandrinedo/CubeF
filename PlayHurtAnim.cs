using UnityEngine;
using System.Collections;

public class PlayHurtAnim : MonoBehaviour {
	private Animator myAnim;

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
	}
	

	void OnTriggerEnter(Collider collision){
		if (collision.gameObject.tag == "Obstacle") {
			myAnim.SetBool("hurt", true);

		}


	}

	void Update(){
		if (myAnim.GetCurrentAnimatorStateInfo(0).IsName("HurtAnim"))
		{
			myAnim.SetBool("hurt", false);
			// Avoid any reload.
		}
	}
}
