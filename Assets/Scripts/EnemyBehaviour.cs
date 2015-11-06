using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    private GameObject player;
    public float speed;
    public float rotationSpeed;
    public float range = 10;

    private Timer riskTimer;
    private bool hasChased = false;

    public float health;
    private float iFrameTimer;
    private bool invulnerable;
    public float iFrameDuration = 0.5f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        riskTimer = player.GetComponent<Timer>();
    }

	void Update () {

        transform.rotation *= Quaternion.Euler(Vector3.forward * rotationSpeed);

        Vector3 playerPos = player.transform.position;
        
        if(Vector3.Distance(transform.position, playerPos) < range)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);


            if (!hasChased)
            {
                riskTimer.enemyCount++;
                hasChased = true;
            }
            riskTimer.isEnemyNear = true;
        } else if(hasChased)
        {
            riskTimer.isEnemyNear = false;
        }

        if (playerPos.x - transform.position.x >= 0)
        {
            transform.localScale = new Vector3(-transform.localScale.y, transform.localScale.y, 1);
        } else
        {
            transform.localScale = new Vector3(transform.localScale.y, transform.localScale.y, 1);
        }


        //moment if invulnerability after being hit
        if (iFrameTimer > 0)
        {
            invulnerable = true;
            iFrameTimer -= Time.deltaTime;


        } else {
            invulnerable = false;
        }
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SendMessage("TakeDamage", 20, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void TakeDamage(float amount)
    {
        if (invulnerable)
        {
            return;
        }

        health -= amount;

        iFrameTimer = iFrameDuration;
        invulnerable = true;

        if (health <= 0)
        {
            riskTimer.isEnemyNear = false;
            Destroy(this.gameObject);
        }
    }
}
