using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {

	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public Text score;
	public Text highScore1;
	public Text highScore2;
	public GameObject tapText;
	public static UImanager instance;
	public Text scoreWhilePlay;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}


	// Use this for initialization
	void Start () {
		scoreWhilePlay.enabled = false;
		if (PlayerPrefs.HasKey ("highScore")) {
			highScore2.text = PlayerPrefs.GetInt ("highScore").ToString ();
		} else {
			highScore2.text = "0";
		}

	}

	public void GameStart(){
		
		zigzagPanel.GetComponent<Animator> ().Play ("panelUp");
		tapText.GetComponent<Animator> ().Play ("textDown");
		scoreWhilePlay.enabled = true;
		scoreWhilePlay.text=PlayerPrefs.GetInt ("score").ToString ();
		//tapText.SetActive (false);

	
	}

	public void GameOver(){
		gameOverPanel.SetActive (true);
		score.text = PlayerPrefs.GetInt ("score").ToString();
		highScore1.text = PlayerPrefs.GetInt ("highScore").ToString();
	}

	public void Reset (){
		SceneManager.LoadScene (0);
	}
	
	// Update is called once per frame
	void Update () {
		scoreWhilePlay.text=PlayerPrefs.GetInt ("score").ToString ();
	}
}
