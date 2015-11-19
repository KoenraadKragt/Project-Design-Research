using UnityEngine;
using System.Collections;

public class Slash : MonoBehaviour
{

    float dmg;
    public float lifespan = 0.3f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        dmg = player.GetComponent<PlayerAttack>().getDamage();

        Destroy(this.gameObject, lifespan);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.SendMessage("TakeDamage", dmg, SendMessageOptions.DontRequireReceiver);
        }
    }
    
    void Update()
    {
        this.transform.parent = player.transform;
        this.transform.position = transform.parent.position;
    }
}
    
