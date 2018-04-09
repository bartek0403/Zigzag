﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegasScript : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(SwipeManager.instance.OnSwipe(SwipeDirection.Up))
		{
			animator.SetTrigger("jump");
		}
	}
}