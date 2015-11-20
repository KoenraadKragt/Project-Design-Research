using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public GameObject attack;
    bool cooldown = false;
    public float startingDamage = 1;
    float damage;

    float boostTimer = 0;
    float boostDuration = 10;

    private Slider powerSlider;

    Quaternion rotation = Quaternion.identity;
    Vector3 scale = Vector3.zero;

    void Awake()
    {
        damage = startingDamage;


        powerSlider = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().powerSlider;
    }

    void Update() {

        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;

            if(!powerSlider.IsActive())
            {
                powerSlider.gameObject.SetActive(true);
            }

            powerSlider.value = boostTimer / boostDuration;
        } else
        {
            damage = startingDamage;
            if (powerSlider.IsActive())
            {
                powerSlider.gameObject.SetActive(false);
            }
        }


        if(Input.GetKeyDown(KeyCode.Z) && cooldown == false)
        {
           
            rotation = transform.rotation;
            
            scale = transform.localScale * 0.6f;

            GameObject clone = (GameObject)Instantiate(attack, transform.position, rotation);
            clone.transform.localScale = scale;

            StartCoroutine(Wait());
        }
	}

    private IEnumerator Wait()
    {
        cooldown = true;
        yield return new WaitForSeconds(.3f);
        cooldown = false;
    }

    public float getDamage()
    {
        return damage;
    }
    public void PowerBoost(float _damage)
    {
        boostTimer = boostDuration;

        powerSlider.value = boostTimer / boostDuration;

        damage = _damage;
    }
}
