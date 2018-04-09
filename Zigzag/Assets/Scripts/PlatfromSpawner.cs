using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromSpawner : MonoBehaviour {

	public GameObject platform;
	public GameObject diamond;
	public GameObject platformWithObstacleBig;
	public GameObject platformWithObstacleSmallLeft;
	public GameObject platformWithObstacleSmallRight;

	Vector3 lastPos;
	float size;
	public bool gameOver = false;
	public GameObject cube;
	private bool prevPlatformHasObstacle;
	int obstacleVariable;

	// Use this for initialization
	void Start () {
		
		lastPos = GameObject.Find ("PlatformBegin").transform.position;
		size = platform.transform.localScale.x;

		for (int i = 0; i < 20; i++) 
		{
			SpawnPlatforms();
		}
	}


	public void StartSpawning(){
		
		InvokeRepeating ("SpawnPlatforms", 2f, 0.2f);
	}


	// Update is called once per frame
	void Update () {
		
		if (GameManager.instance.gameOver == true)
		{
			CancelInvoke ("SpawnPlatforms");
		}	
	}

	//Spawn nowej platformy w osi X
	void SpawnX(bool spawnObst){
		
		Vector3 pos = lastPos;
		pos.x += size;
		lastPos = pos;

		spawnCubeBackground (lastPos.x,lastPos.z,"x");

		if (spawnObst) 
		{
			if(obstacleVariable > 90 && obstacleVariable < 94)
				Instantiate (platformWithObstacleBig, pos, Quaternion.AngleAxis(90,Vector3.up));
			else if (obstacleVariable > 93 && obstacleVariable < 97)
				Instantiate (platformWithObstacleSmallLeft, pos, Quaternion.AngleAxis(90,Vector3.up));
			else if (obstacleVariable > 96 && obstacleVariable < 101)
				Instantiate (platformWithObstacleSmallLeft, pos, Quaternion.AngleAxis(90,Vector3.up));		
		}
		else 
			Instantiate(platform,pos,Quaternion.identity); 
	}

	//Spawn nowej platformy w osi Z
	void SpawnZ(bool spawnObst){
		
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;

		spawnCubeBackground (lastPos.x,lastPos.z,"z");

		//Tworzenie platformy z przeszkodą lub bez
		if (spawnObst) 
		{
			if(obstacleVariable > 90 && obstacleVariable < 94)
				Instantiate (platformWithObstacleBig, pos, Quaternion.identity);
			else if (obstacleVariable > 93 && obstacleVariable < 97)
				Instantiate (platformWithObstacleSmallLeft, pos, Quaternion.identity);
			else if (obstacleVariable > 96 && obstacleVariable < 101)
				Instantiate (platformWithObstacleSmallLeft, pos, Quaternion.identity);		
		}
		else 
			Instantiate(platform,pos,Quaternion.identity); 
	}

	void SpawnPlatforms()
		{
		bool spawnObstacle = false;

		if (gameOver) 
			{
			return;
			}

		obstacleVariable = Random.Range (0, 100);

		if (obstacleVariable >= 90 & !prevPlatformHasObstacle) 
		{
			spawnObstacle = true;
			prevPlatformHasObstacle = true;
		} 
		else
			prevPlatformHasObstacle = false;

		int rand = Random.Range (0, 7);

		if (rand < 3) 
		{
			SpawnX (spawnObstacle);

			if(!spawnObstacle)
				SpawnDiamond ();	
		} 
		else 
		{
			SpawnZ (spawnObstacle);

			if(!spawnObstacle)
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

	void spawnCubeBackground(float platformPosX, float platformPosZ, string direction){
		float posX=0;
		float posZ=0;
		if (direction == "x") {
			posX = Random.Range (platformPosX - 10, platformPosX + 10);
			posZ = platformPosZ;
		}
		if (direction == "z") {
			posX = platformPosX;
			posZ = Random.Range (platformPosZ - 10, platformPosZ + 10);
		}

		Instantiate (cube, new Vector3 (posX, -5, posZ), Quaternion.identity);

	}




}
