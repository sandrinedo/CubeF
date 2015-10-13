using UnityEngine;
using System.Collections;


public class ObstacleDeactivator : MonoBehaviour {
	private GameObject ship; 
	public float angleLimit;
	public float distanceLimit;

	// Use this for initialization
	void Start () {
	
	
		ship = GameObject.FindGameObjectWithTag ("Player");
	}

	
	// Update is called once per frame
	void Update () {
		Vector3 shipForward = ship.transform.forward;
		Vector3 cubeDir = transform.position - ship.transform.position  ;
		float angle = Vector3.Angle (cubeDir , shipForward);
		float distance = Vector3.Distance (ship.transform.position, transform.position);
		if (angle > angleLimit && distance > distanceLimit ) {

			gameObject.SetActive(false);
		}

	
	}
}
