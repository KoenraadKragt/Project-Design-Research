using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	void LoadRoomV1(){
        Time.timeScale = 1f;
        Application.LoadLevel(1);
	}

	void QuitGame(){
		Application.Quit ();
	}
}
