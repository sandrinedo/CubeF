using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CountLives : MonoBehaviour {
	private int hitPoint = 0;
	//This line allows you to set a min and max acceptable value in the inspector
	[Range(0, 10)]
	public int startLife = 3;
	public static bool dead = false;
	// If you want to use images for hit points
//	private Image[] imgLife;
//	public Image imgPrefab;
//	public Transform canvas;

	//Use this if you want 3d models for HP
	public GameObject shipUI;
	private GameObject[] ships;
	public Transform HealthCam;
	// Use this for initialization
	void Start () {
		dead = false;
		//UI images
		//imgLife = new Image[startLife];
		ships = new GameObject[startLife];

		for (int i = 0; i < startLife; i++) {
			// Images for HP
//			Image obj = (Image)Instantiate(imgPrefab);
//			imgLife[i] = obj;
//			imgLife[i].transform.SetParent(canvas);
//			Vector2 pos = new Vector2(x, -25);
//			float x =-50*i -25;
//			imgLife[i].rectTransform.anchoredPosition = pos;
			
			GameObject shipobj = (GameObject) Instantiate(shipUI);
			ships[i] = shipobj;
			ships[i].transform.SetParent(HealthCam);
			float xShip = -i + 7;
			Vector3 posShip = new Vector3(xShip, 4.2f, 4f);
			ships[i].transform.localPosition = posShip; 
			Debug.Log(ships[i].transform.localPosition);
		}
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider collision){
		if (collision.gameObject.tag == "Obstacle") {
			hitPoint ++;
			//Animator anim = ships[startLife - hitPoint].GetComponent<Animator>();
			//anim.SetBool("hurt", true);
			ships[startLife - hitPoint].SetActive(false);
			//imgLife[startLife - hitPoint].enabled = false;
	//		Debug.Log (hitPoint);
		}
	}

	public void Update(){
		if(hitPoint >= startLife){
			dead = true;
//			Debug.Log (dead);
		}
	}
}
