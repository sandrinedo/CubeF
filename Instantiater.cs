using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Instantiater : MonoBehaviour {
	public GameObject obstacle;
	public int pooledAmount =50;
	List<GameObject> obstacles;
	List<GameObject> premadeList;

	public List<GameObject> premadeObstacles;

	public Transform player;
	public float RangeX;
	public float RangeZ;
	private Vector3 spawnLocation;
	private int antiSpam;
	private float fireTimer;

	//bool for coroutines
	public bool startFire;
	public bool startFirePremade;
	// Use this for initialization
	void Start () {
		antiSpam = 0;
		obstacles = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (obstacle);
			obj.SetActive(false);
			obstacles.Add (obj);
			}

		premadeList = new List<GameObject> ();
		for (int j = 0; j < premadeObstacles.Count; j++) {
			GameObject obj2 = (GameObject)Instantiate (premadeObstacles[j]);
			obj2.SetActive(false);
			premadeList.Add(obj2);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && antiSpam == 0){
			antiSpam ++;
			StartCoroutine ("waitTwenty");
		}
		if(startFire){
			Fire ();
		}
		if(startFirePremade){
			FirePremade();
		}

	
	}

	void Fire() {
		for (int i = 0; i < pooledAmount; i++) {
			if(!obstacles[i].activeInHierarchy){
				float locX = Random.Range(-RangeX, RangeX);
				float locZ = Random.Range(25f, RangeZ);
				spawnLocation = transform.right * locX + transform.forward * locZ;
				obstacles[i].transform.rotation = player.transform.rotation;
				obstacles[i].transform.position = player.transform.TransformPoint(spawnLocation);

				fireTimer += Time.deltaTime;
				if(fireTimer >= 0.25f){
					obstacles[i].SetActive(true);
					fireTimer = 0f;
				}

			}
		}
	}

	void FirePremade(){
		int a = Random.Range (0, premadeObstacles.Count);
		spawnLocation = transform.forward * RangeZ;
		premadeList [a].transform.rotation = player.transform.rotation;
		premadeList [a].transform.position = player.transform.TransformPoint (spawnLocation);
		premadeList [a].SetActive (true);
		startFirePremade = false;
	}

	IEnumerator waitTen(){
		StopCoroutine ("waitTwenty");

		startFirePremade = true;
		yield return new WaitForSeconds (3.0F);
		startFirePremade = false;
		StartCoroutine ("waitTwenty");
	}

	IEnumerator waitTwenty(){
		StopCoroutine ("waitTen");
		startFire = true;
		yield return new WaitForSeconds (10.0f);
		startFire = false;
		StartCoroutine ("waitTen");
	}







































}
