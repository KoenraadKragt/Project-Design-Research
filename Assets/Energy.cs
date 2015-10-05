using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

    public Light lightSuit;
    public float rangeDecrease = 0.5f;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        float movement = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y * 0.3f).magnitude;


        if (lightSuit != null)
        {
            if (movement > 0.1)
            {
                if (lightSuit.intensity < 1.2f)
                {
                    lightSuit.intensity += 0.1f * movement * Time.deltaTime;
                }
                lightSuit.range += 0.1f * movement * Time.deltaTime;
            }
            if (lightSuit.intensity > 0.3f)
            {
                lightSuit.intensity -= rangeDecrease * Time.deltaTime;
            }
            lightSuit.range -= rangeDecrease * Time.deltaTime;
        }
        
    }
}
