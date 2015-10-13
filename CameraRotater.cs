using UnityEngine;
using System.Collections;

public class CameraRotater : MonoBehaviour {
	public float rotationAngle = 5f;
	private float angleZ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Movement.inPlay) {
			angleZ = Input.GetAxis ("Horizontal") * rotationAngle;
		} else {
			angleZ = 0f;
		}

		if (Input.GetAxis ("Horizontal") != 0) {
			Quaternion target = Quaternion.AngleAxis (angleZ, Vector3.forward);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, target, 0.2f);
		}else{
			Quaternion resetAngle = Quaternion.identity;
			transform.localRotation = Quaternion.Slerp (transform.localRotation, resetAngle, 0.05f);
		}
	
	}
}
