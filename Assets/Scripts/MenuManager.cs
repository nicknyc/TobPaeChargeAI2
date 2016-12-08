using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void triggerMenuBehavior(int i){
		switch (i) {
		default:
		case 0:
			SceneManager.LoadScene ("Playing");
			break;
		case 1:
			Application.Quit ();
			break;
		}
	}
}
