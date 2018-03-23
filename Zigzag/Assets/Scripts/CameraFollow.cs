using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


	public GameObject ball;
	Vector3 offset;
	public float lerpRate=0.5f;
	public bool gameOver = false;
	private Vector3 velo = Vector3.zero;


	// Use this for initialization
	void Start () {
		offset = ball.transform.position - transform.position;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!gameOver) {
			Follow ();
		}
	}

	void Follow (){
		Vector3 pos = transform.position;
		Vector3 targetPos = ball.transform.position - offset;
		//pos = Vector3.Lerp (pos, targetPos, lerpRate * Time.deltaTime);
		pos = Vector3.SmoothDamp (pos, targetPos, ref velo,lerpRate*Time.deltaTime);
		transform.position = pos;
	}
}
