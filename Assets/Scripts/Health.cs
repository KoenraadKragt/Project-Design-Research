using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

    public Energy playerEnergy;

    public float startingHP = 100;
    private float HP;
    private float iFrameTimer;
    private bool invulnerable;
    private float iFrameDuration = 0.5f;
    private Slider healthSlider;

    void Awake()
    {
        HP = startingHP;

        invulnerable = false;

        healthSlider = GameObject.FindGameObjectWithTag("HealthSlider").GetComponent<Slider>();
    }

    void Update()
    {
        if(HP > 100)
        {
            HP = 100;
        }

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

		this.SendMessage("OnHit",iFrameDuration,SendMessageOptions.DontRequireReceiver);
        HP -= amount;
        playerEnergy.energy -= amount;

        healthSlider.value = HP;

        iFrameTimer = iFrameDuration;

        if (HP <= 0)
        {
            Death();
        }
    }

    public void DrainHealth(float amount)
    {
        HP -= amount;

        healthSlider.value = HP;

        if (HP <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        GameObject.FindGameObjectWithTag("GameManager").SendMessage("Death", SendMessageOptions.DontRequireReceiver);
    }
}
