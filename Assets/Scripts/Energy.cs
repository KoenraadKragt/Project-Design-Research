using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

    public Health playerHealth;

    public Light lightSuit;
    public float rangeDecrease = 10f;
    public float energy;
    private float modifier = 1.0f;

    private Timer riskTimer;

    public enum lightMode {Kinetic, Rechargeable, Constant};
    public lightMode currentMode = lightMode.Kinetic;
    
    void Awake () {
        energy = 100;

        riskTimer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();

        currentMode = lightMode.Kinetic;
        modifier = 1.0f;

        riskTimer.SetLightMode(currentMode);
	}
	
	void Update () {

        if (currentMode != lightMode.Constant)
        {
            KineticUpdate();
        } else
        {
            if( GetComponent<Rigidbody2D>().velocity.magnitude > 0.1)
            {
                riskTimer.moving += Time.deltaTime;
            }
        }


        //risk meten
        if ((energy > 85))
        {
            riskTimer.energyHigh += Time.deltaTime;
        }
        if ((energy < 25))
        {
            riskTimer.energyLow += Time.deltaTime;
        }
    }
    


    void KineticUpdate()
    {
        if (lightSuit == null)
        {
            return;
        }
        //max energy;
        else if (energy > 100)
        {
            energy = 100;
            return;
        }
        //minimum light is 15% during kinetic mode
        if (energy < 15 && currentMode == lightMode.Kinetic)
        {
            energy = 15;
            return;
        }

        //player movement
        float movement = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y * 0.05f).magnitude;

        //change the energy
        float change;
        if (movement > 0.1)
        {
            change = -Time.deltaTime * movement * modifier;
            energy -= change;


            //risk meten
            riskTimer.moving += Time.deltaTime;
        }
        else
        {
            change = Time.deltaTime * rangeDecrease * modifier;
            energy -= change;
        }
        if(currentMode == lightMode.Kinetic && energy > 15)
        {
            playerHealth.DrainHealth(change);
        }

        lightSuit.intensity = energy / 100;
        lightSuit.range = energy / 10;

        //min and max light intensity
        if (lightSuit.intensity > 1.2f)
        {
            lightSuit.intensity = 1.2f;
        }
        else if (lightSuit.intensity < 0.9f)
        {
            lightSuit.intensity = 0.9f;
        }
    }
    
}
