using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromSpawner : MonoBehaviour {

	public GameObject platform;
	public GameObject diamond;
	Vector3 lastPos;
	float size;
	public bool gameOver = false;

	// Use this for initialization
	void Start () {
		lastPos = platform.transform.position;
		size = platform.transform.localScale.x;

		for (int i = 0; i < 20; i++) {
			SpawnPlatforms();
		}
	}


	public void StartSpawning(){
		InvokeRepeating ("SpawnPlatforms", 2f, 0.2f);
	}
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver == true) {
			CancelInvoke ("SpawnPlatforms");
		}	
	}

	//Spawn nowej platformy w osi X
	void SpawnX(){
		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;

		//Tworzenie nowej platformy
		Instantiate(platform,pos,Quaternion.identity);

	}

	//Spawn nowej platformy w osi Z
	void SpawnZ(){
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;

		//Tworzenie nowej platformy
		Instantiate(platform,pos,Quaternion.identity);
	}

	void SpawnPlatforms(){
		if (gameOver) {
			return;
		}

		int rand = Random.Range (0, 7);
		if (rand < 3) {
			SpawnX ();
			SpawnDiamond ();
		} else {
			SpawnZ ();
			SpawnDiamond ();
		}
	}

	void SpawnDiamond(){
		int rand = Random.Range (0, 4);
		Vector3 diamondPos = lastPos;
		diamondPos.y += 1;
		if (rand < 1) {
			Instantiate (diamond, diamondPos, diamond.transform.rotation);
		}
	}




}
