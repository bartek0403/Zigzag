using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {


	private float lastPosX;
	private float lastPosY;
	private float lastPosZ;
	private Collider coll;
	int offsetX=0;
	int offsetZ =0;

	public static  CubeSpawner instance;

	public GameObject cube;


	public Camera camera;



	void Awake(){
		if (instance == null) {
			instance = this;
		}
		coll = GetComponent<BoxCollider>();

	}

	void spawnCubesAhead(){
		
		for (int i = 0; i < 6; i++) {
			spawnCubeAhead ();
		}

	}

	public void SpawnInitialCubes(){
			for (int i = 0; i < 20; i++) {
				spawnInitialCube ();
			}

			offsetX=12;
			offsetZ = 15;

			for (int i = 0; i < 20; i++) {
				spawnInitialCube ();
			}
	}

	void spawnInitialCube(){
		float posX =  Random.Range (camera.transform.position.x+6 + offsetX, camera.transform.position.x + 20 + offsetX);
		float posZ =  Random.Range (camera.transform.position.z + 5 + offsetZ, camera.transform.position.z + 20 + offsetZ);
		Instantiate (cube, new Vector3 (posX, -5, posZ), Quaternion.identity);
	}

	void spawnCubeAhead(){
		float posX =  Random.Range (camera.transform.position.x+12, camera.transform.position.x + 25);
		float posZ =  Random.Range (camera.transform.position.z + 15, camera.transform.position.z + 30);
		Instantiate (cube, new Vector3 (posX, -5, posZ), Quaternion.identity);
	}

	public void StartSpawningAhead(){
		InvokeRepeating ("spawnCubesAhead", 0,1f);	
	}

	public void StopSpawning(){
		CancelInvoke ("spawnCubesAhead");
	}

	// Update is called once per frame
	void Update () {
		float posZ=camera.transform.position.z;
		float posX = camera.transform.position.x;
		coll.transform.position = new Vector3(camera.transform.position.x,coll.transform.position.y,camera.transform.position.z);
	}

	void OnTriggerEnter(Collider col){
		Destroy (col.gameObject);
	}

}
