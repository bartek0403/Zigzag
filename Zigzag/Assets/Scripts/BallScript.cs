using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	//nie jest publiczne, ale pole speed bedzie sie pokazywało w edytorze
	public static float speed = 8;
	bool started = false;
	bool gameOver = false;
	Vector3 arrayVector;
	bool goX = true;

	public GameObject particle;

	Rigidbody rb;

	//uruchamiana przed startem
	void Awake(){
		rb = GetComponent<Rigidbody>();
	}

	//Zmiana kierunku 
	void SwitchDirection(){
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);

		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}
		
				
	}

	//Zmiana kierunku 
	void SwitchDirection1(){
		if (goX = true ) {

			rb.AddTorque (new Vector3 (5, 0, 0));
			goX = false;



		

		} else if (goX = false) {
			rb.AddTorque (new Vector3 (0, 0, 5));
			goX = true;
		}


	}


	
	// Update is called once per frame
	void Update () {
		//jeśli nie wystartowała, a mysz jest naciśnięta - nadaj prędkość
		if (!started) {
			if (Input.GetMouseButtonDown (0)) {
				rb.velocity = new Vector3 (speed, 0, 0);
				//rb.AddTorque (new Vector3 (5, 0, 0));
				started = true;

				GameManager.instance.StartGame ();
			}
		}
		//Jeśli kula wyjdzie za krawędź - spada
		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			gameOver = true;
			rb.velocity = new Vector3 (0, -5f, 0);

			//Gdy kula spadnie, kamera przestaje podążac, nowe bloki nie są tworzone
			Camera.main.GetComponent<CameraFollow> ().gameOver = true;
			GameObject.Find ("PlatformSpawner").GetComponent<PlatfromSpawner> ().gameOver = true;

			GameManager.instance.GameOver ();

		}
		//Zmiana kierunku przy kliknięciu
		if (Input.GetMouseButtonDown (0) && !gameOver) {
			SwitchDirection ();	
		}

		if (rb.velocity.z > 0) {
			transform.Rotate(new Vector3(8,0,0),Space.World);;

		} else if (rb.velocity.x > 0) {
			transform.Rotate(new Vector3(0,0,-8),Space.World);;
		}

	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Diamond") {
			//Uwuchomienie efektu wizualnego podczas niszczenia diamentu
			GameObject part = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			ScoreManager.instance.DiamondCollision ();
			//GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().StartSpawning ();
			Destroy (part, 1f);

		}
	}
}
