using UnityEngine;
using System.Collections;

public class LightArea : MonoBehaviour {

    Timer riskTimer;

    void Awake()
    {

        riskTimer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            riskTimer.EnterTheLight(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        riskTimer.EnterTheLight(false);
    }
}
