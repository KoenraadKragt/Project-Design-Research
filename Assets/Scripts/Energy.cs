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

        riskTimer = GetComponent<Timer>();

        switch (Application.loadedLevelName)
        {
            case "Level 1":
                currentMode = lightMode.Kinetic;
                modifier = 1.0f;
                break;
            case "Level 2":
                currentMode = lightMode.Rechargeable;
                modifier = -1.0f;
                break;
            case "Level 3":
                currentMode = lightMode.Constant;
                modifier = 0.0f;
                GetComponent<EnergyGUI>().enabled = false;
                break;
        }

        riskTimer.SetLightMode(currentMode);
	}
	
	void Update () {

        if (currentMode != lightMode.Constant)
        {
            KineticUpdate();
        }
        if ((energy < 25 || energy > 85) && currentMode == lightMode.Kinetic)
        {
            riskTimer.riskValue += Time.deltaTime;
        }
        if (currentMode == lightMode.Rechargeable && (energy < 25))
        {
            riskTimer.riskValue += Time.deltaTime;
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
        else if (lightSuit.intensity < 0.6f)
        {
            lightSuit.intensity = 0.6f;
        }
    }
    
}
