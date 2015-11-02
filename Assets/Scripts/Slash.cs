using UnityEngine;
using System.Collections;

public class Slash : MonoBehaviour
{

    public int dmg = 1;
    private GameObject enemy;
    private GameObject player;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");

        Destroy(this.gameObject, 0.3f);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        print("collision");
        if (other.gameObject.tag == "Enemy")
        {
            other.SendMessage("TakeDamage", dmg);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.parent = player.transform;
    }
}
    
