using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text health;
	public Text charge;
	public int hp;
	public int mp;
	public int move;
	public Button[] bottons;
	public Text lastmove;
	// Use this for initialization
	void Start () {
		hp = 5;
		mp = 0;
		update (true);
		lastmove.text = "";
	}

	public void triggerMove(int i){
		move = i;
	}

	public void update(bool isPlayer2){
		/*
		 * 1 = attack
		 * 2 = defend
		 * 3 = charge
		 * 4 = super attack
		 */
		string letter = "";
		switch (move) {
		default:
			break;
		case(1):
			letter = "A";
			break;
		case(2):
			letter = "D";
			break;
		case(3):
			letter = "C";
			break;
		case(4):
			letter = "S";
			break;
		}
		if (isPlayer2) {
			lastmove.text = lastmove.text + letter;
		} else {
			lastmove.text = letter + lastmove.text;
		}

		move = 3;
		if (bottons.Length == 4) {
			if (mp < 1)
				bottons [0].enabled = false;
			else
				bottons [0].enabled = true;
			if (mp < 3)
				bottons [3].enabled = false;
			else
				bottons [3].enabled = true;
		}
		if (hp <= 0)
			hp = 0;
		if (mp >= 3)
			mp = 3;
		health.text = "Health: " + hp;
		charge.text = "Charge: " + mp;
	}
}
