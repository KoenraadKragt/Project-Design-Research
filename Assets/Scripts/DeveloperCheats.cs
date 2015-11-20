using UnityEngine;
using System.Collections;

public class DeveloperCheats : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Application.LoadLevel(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Application.LoadLevel(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Application.LoadLevel(4);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Application.LoadLevel(5);
        }
    }
}
