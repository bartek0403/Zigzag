using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection {
	Tap = -1,
	None = 0, // 0000
	Left = 1, //0001
	Right = 2,//0010
	Up = 4,//0100
	Down = 8,//1000
}

public class SwipeManager : MonoBehaviour {

	public  static SwipeManager instance;
	public SwipeDirection Direction{ set; get;}
	private Vector3 touchPosition;
	private Vector3 deltaSwipe;
	private float swipeResistanceX = 200f;
	private float swipeResistanceY = 200f;


	private void Awake(){
		if (instance == null) 
			instance = this;
		
	}
	void Update(){
		Direction = SwipeDirection.None;
		if (Input.GetMouseButtonDown(0)){
			touchPosition = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp (0)) {
			
			deltaSwipe = touchPosition - Input.mousePosition;
			if (Mathf.Abs (deltaSwipe.x) > swipeResistanceX) {
				if (deltaSwipe.x > 0) {
					Direction |= SwipeDirection.Left;
					Debug.Log ("Swipe Left");
				} else {
					Direction |= SwipeDirection.Right;
					Debug.Log ("Swipe Right");
				}
			}
			if (Mathf.Abs (deltaSwipe.y) > swipeResistanceY) {
				if (deltaSwipe.y > 0) {
					Direction |= SwipeDirection.Down;
					Debug.Log ("Swipe Down");
				} else {
					Direction |= SwipeDirection.Up;
					Debug.Log ("Swipe Up");
				}
			} 
			if(Mathf.Abs(deltaSwipe.x) < swipeResistanceX && Mathf.Abs(deltaSwipe.y) < swipeResistanceY) {
				Direction = SwipeDirection.Tap;
				Debug.Log ("Tap");
			}
		} 

	}

	public bool OnSwipe (SwipeDirection dir){
		if (Direction == dir) {
			return true;
		} else
			return false; 
	}

}
