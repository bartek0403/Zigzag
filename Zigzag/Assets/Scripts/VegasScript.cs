using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegasScript : MonoBehaviour {

	private Animator animator;
	private Rigidbody rb;
	private float speed = 6;
	bool gameOver = false;
	public GameObject particle;
	private bool selected = false;


	void Awake(){
		
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
		
		animator = GetComponent<Animator>();
		transform.Rotate (Vector3.up, 90);
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			//Jeśli kula wyjdzie za krawędź - spada
			if (!Physics.Raycast (transform.position, Vector3.down, 5f) && transform.position.y < 1.35) {

				onGameOver ();
			}

			//Zmiana kierunku przy kliknięciu
			if (SwipeManager.instance.OnSwipe (SwipeDirection.Tap) && !gameOver) {
				SwitchDirection ();	
			}

			if (SwipeManager.instance.OnSwipe (SwipeDirection.Up) && !gameOver && Physics.Raycast (transform.position, Vector3.down, 2f)) {
				rb.AddForce (Vector3.up * 6, ForceMode.Impulse);
				animator.SetTrigger ("jump");
			}
		}
	}

	//Zmiana kierunku 
	void SwitchDirection(){

		if (rb.velocity.z > 0) {

			rb.velocity = new Vector3 (speed, 0, 0);
			transform.Rotate (Vector3.up, 90);

		} else if (rb.velocity.x > 0) {

			rb.velocity = new Vector3 (0, 0, speed);
			transform.Rotate (Vector3.up, -90);
		}
	}

	void OnTriggerEnter(Collider col){

		Debug.Log (col.gameObject.tag);

		if (col.gameObject.tag == "Diamond") {

			//Uwuchomienie efektu wizualnego podczas niszczenia diamentu
			GameObject part = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			ScoreManager.instance.DiamondCollision ();
			Destroy (part, 1f);
		}
	}

	void OnCollisionEnter(Collision col) {

		if (col.gameObject.tag == "Obstacle"){

			onGameOver ();
		}
	}

	public void OnStart(){
		selected = true;
		rb.velocity = new Vector3 (speed, 0, 0);
	}

	private void onGameOver(){

		gameOver = true;
		rb.velocity = new Vector3 (0, -5f, 0);
		GameManager.instance.GameOver();

	}

}
