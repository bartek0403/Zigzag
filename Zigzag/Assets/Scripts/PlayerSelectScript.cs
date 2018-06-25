using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectScript : MonoBehaviour {
	
	public string character { get; set; }
	public static PlayerSelectScript instance;


	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		character = null;
	}

	public void OnBallSelect () {
		
		Debug.Log ("Selected Ball");
		character = "Ball";	
		GameManager.instance.StartGame (character);
	}

	public void OnVegasSelect () {

		Debug.Log ("Selected Vegas");
		character = "Vegas";
		GameManager.instance.StartGame (character);
	}
}
