using UnityEngine;
using System.Collections;

public class Slash : MonoBehaviour
{

    public float dmg = 1;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Destroy(this.gameObject, 0.3f);
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
    
