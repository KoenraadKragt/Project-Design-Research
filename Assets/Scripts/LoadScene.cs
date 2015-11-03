using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	void LoadRoomV1(){
		Application.LoadLevel(1);
	}

	void LoadRoomV2(){
		Application.LoadLevel(2);
	}

	void LoadRoomV3(){
		Application.LoadLevel(3);
	}

	void QuitGame(){
		Application.Quit ();
	}
}
