using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Text timer;
	public float time;
	public PlayerController player1, player2;
	private static float TIME_MAX = 3.0f;

	// Use this for initialization
	void Start () {
		time = TIME_MAX;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		timer.text = "" + (int)time;
		if (time <= 0) {
			battle ();
			postBattle ();
		}
	}

	public void battle(){
		/*
		 * 1 = attack
		 * 2 = defend
		 * 3 = charge
		 * 4 = super attack
		 */
		//calculate mp lost
		if (player1.move == 1)
			player1.mp -= 1;
		else if (player1.move == 4)
			player1.mp -= 3;
		
		if (player2.move == 1)
			player2.mp -= 1;
		else if (player2.move == 4)
			player2.mp -= 3;

		//calculate hp lost and mp gained
		if (player1.move == 1 && player2.move == 3) {
			player2.hp -= 1;
		} else if (player1.move == 3 && player2.move == 1) {
			player1.hp -= 1;
		} else if (player1.move == 4 && player2.move != 4) {
			player2.hp -= 5;
		} else if (player1.move != 4 && player2.move == 4) {
			player1.hp -= 5;
		}else {
			if (player1.move == 3) {
				player1.mp += 1;
			}
			if (player2.move == 3) {
				player2.mp += 1;
			}
		}
	}

	void postBattle(){
		player1.update (false);
		player2.update (true);
		if (player1.hp == 0) {
			SceneManager.LoadScene ("Defeat",LoadSceneMode.Single);
		} else if (player2.hp == 0) {
			SceneManager.LoadScene ("Victory",LoadSceneMode.Single);
		} else {
			time = TIME_MAX;
		}
	}
}
