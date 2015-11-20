using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	void LoadRoomV1(){
		Application.LoadLevel(1);
	}

	void QuitGame(){
		Application.Quit ();
	}
}
