using UnityEngine;
using System.Collections;

public class SolarOrb : MonoBehaviour {

    bool isFinished = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isFinished = true;
        }
    }

    void OnGUI()
    {
        if (isFinished)
        {
            Time.timeScale = 0.1f;

            if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2, 500, 50), "You found the Solar Artifact!"))
            {
                
                GameObject.FindGameObjectWithTag("GameManager").SendMessage("ReachedGoal", SendMessageOptions.DontRequireReceiver);
            }
        }


    }
}
