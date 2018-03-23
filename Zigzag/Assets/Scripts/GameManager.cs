using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool gameOver = false;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		UImanager.instance.GameStart ();
		ScoreManager.instance.startScore ();
		GameObject.Find ("PlatformSpawner").GetComponent<PlatfromSpawner> ().StartSpawning ();

	}

	public void GameOver (){
		UImanager.instance.GameOver ();
		ScoreManager.instance.stopScore ();
		gameOver = true; 

	}

}

