using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Gdy kula opuszcza collider
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Ball") {
			
			//Wywpołanie funkcji z opóźnieniem
			Invoke ("FallDown", 0.5f);


		}
		
	}

	//Aktywuje użycie grawitacji na dany blok
	void FallDown(){


		GetComponentInParent<Rigidbody> ().useGravity = true;
		GetComponentInParent<Rigidbody> ().isKinematic = false;

		//niszczenie obiektu
		Destroy (transform.parent.gameObject, 2f);
	}
}
