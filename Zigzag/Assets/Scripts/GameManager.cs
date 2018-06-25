using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool gameOver = false;
	private bool started = false;
	public Camera camera;

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
		
		/*if (Input.GetMouseButtonUp (0) && !started) {
		
			started = true;
			StartGame ();

		} */

		if(Input.GetKeyUp(KeyCode.Escape)){

			Application.Quit();
		}

	}

	public void StartGame(string character){
		
		UImanager.instance.GameStart ();
		ScoreManager.instance.startScore ();
		GameObject.Find ("PlatformSpawner").GetComponent<PlatfromSpawner> ().StartSpawning ();

		if(character == "Ball")
			GameObject.Find ("Ball").GetComponent<BallScript> ().OnStart ();
		else 
			GameObject.Find ("bigvegas").GetComponent<VegasScript> ().OnStart ();
		CameraFollow.instance.OnStart (character);

	}

	public void GameOver (){
		
		UImanager.instance.GameOver ();
		ScoreManager.instance.stopScore ();
		gameOver = true; 

		Camera.main.GetComponent<CameraFollow> ().GameOver = true;
		GameObject.Find ("PlatformSpawner").GetComponent<PlatfromSpawner> ().GameOver = true;
		//GameManager.instance.GameOver ();

	}

}

