using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

    public Light lightSuit;
    public float rangeDecrease = 0.5f;
    public float energy;
    public float modifier = 1.0f;
    
    void Start () {
        //lightSuit.color = Color.blue;
        energy = 100;
	}
	
	void Update () {

        if (lightSuit == null)
        {
            return;
        } else { 

            float movement = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y * 0.3f).magnitude;

            if (movement > 0.1)
            {
                energy += Time.deltaTime * movement * modifier;
            } else { 
                energy -= Time.deltaTime * rangeDecrease * modifier;
            }


            lightSuit.intensity = energy / 100;
            lightSuit.range = energy/10;
            //lightSuit.color = Color.Lerp(Color.red, Color.blue, energy / 100);


            //min and max light intensity
            if (lightSuit.intensity > 1.2f )
            {
                lightSuit.intensity = 1.2f;
            } else if (lightSuit.intensity < 0.3f)
            {
                lightSuit.intensity = 0.3f;
            }

            //min and max energy
            if (energy < 0)
            {
                energy = 0;
            } else if(energy > 100)
            {
                energy = 100;
            }

        }
    }
}
