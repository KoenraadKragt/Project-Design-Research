using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    private float score;
	
	// Update is called once per frame
	void Update () {
        float movement = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y * 0.3f).magnitude;

        if (movement > 0.1)
        {
            score += Time.deltaTime * movement;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 10, 500, 50), "Score: " + score.ToString("F0"));
    }
}
