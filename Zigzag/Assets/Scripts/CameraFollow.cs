using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


	public GameObject ball;
	public GameObject vegas;
	Vector3 offset;
	public float lerpRate=0.5f;
	public bool GameOver { get; set;}
	private Vector3 velo = Vector3.zero;
	private bool started = false;
	private GameObject followObject;
	public static CameraFollow instance;


	void Awake(){
		
			if (instance == null) {
				instance = this;
			}
	}

	// Use this for initialization
	void Start () {
		offset = ball.transform.position - transform.position;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!GameOver && started) {
			Follow ();
		}
	}

	void Follow (){
		Vector3 pos = transform.position;
		Vector3 targetPos = followObject.transform.position - offset;
		//pos = Vector3.Lerp (pos, targetPos, lerpRate * Time.deltaTime);
		pos = Vector3.SmoothDamp (pos, targetPos, ref velo,lerpRate*Time.deltaTime);
		transform.position = pos;
	}

	public void OnStart (string character){

		if (character == "Ball")
			followObject = ball;
		else
			followObject = vegas;
		started = true;
	}
		
}
