using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

    public Energy playerEnergy;

    public float startingHP = 100;
    private float HP;
    private float iFrameTimer;
    private bool invulnerable;
    public float iFrameDuration = 0.5f;
    public Slider healthSlider;
    public Image damageImage;
    bool damaged;
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    void Awake()
    {
        HP = startingHP;

        invulnerable = false;
    }

    void Update()
    {
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        // Reset the damaged flag.
        damaged = false;


        //moment if invulnerability after being hit
        if (iFrameTimer > 0)
        {
            invulnerable = true;
            iFrameTimer -= Time.deltaTime;
        } else
        {
            invulnerable = false;
        }
    }

    public void TakeDamage(float amount)
    {
        if (invulnerable)
        {
            return;
        }

        HP -= amount;
        playerEnergy.energy -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = HP;

        //update UI bar
        //UI flash screen

        iFrameTimer = iFrameDuration;

        if (HP <= 0)
        {
            Death();
        }
    }

    public void DrainHealth(float amount)
    {
        HP -= amount;

        //update UI bar
        healthSlider.value = HP;

        if (HP <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        gameObject.SendMessage("WriteFile", false, SendMessageOptions.DontRequireReceiver);
		Application.LoadLevel(0);
    }


    void OnGUI()
    {
        if (HP <= 0)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2, 500, 50), "GAME OVER!"))
            {
                Time.timeScale = 1.0f;
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
