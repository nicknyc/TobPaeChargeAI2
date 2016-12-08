using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnnouncerController : MonoBehaviour {

	public Text t;
	private float time;
	void Start () {
		t.text = " ";
		time = 1.0f;
	}

	public void show (string input) {
		t.text = input;
		int temp = (int)(80 / (time - Time.deltaTime + 1.0f));
		do {
			temp = (int)(80 / (time - Time.deltaTime + 1.0f));
			t.fontSize = temp;
		} while(temp < 80);
		t.text = " ";
	}
}
