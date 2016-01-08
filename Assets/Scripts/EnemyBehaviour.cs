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
    public float damage = 20;
	public bool flying;

	private GameObject soundManager;

    public float xpReward;

    void Awake()
    {
		soundManager = GameObject.FindGameObjectWithTag("SoundManager");
		player = GameObject.FindGameObjectWithTag("Player");
        riskTimer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Timer>();
    }

	void Update () {

        transform.rotation *= Quaternion.Euler(Vector3.forward * rotationSpeed);

        Vector3 playerPos = player.transform.position;
        
        if(Vector3.Distance(transform.position, playerPos) < range)
        {
			if(flying){
	            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
			} else {
				Vector3 targetPos = new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z);
				transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
			}
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
            other.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void TakeDamage(float amount)
    {
        if (invulnerable)
        {
            return;
        }

		soundManager.SendMessage("SetAudio",0,SendMessageOptions.DontRequireReceiver);

        health -= amount;

        iFrameTimer = iFrameDuration;
        invulnerable = true;

        if (health <= 0)
        {
            riskTimer.isEnemyNear = false;
            GameObject.FindGameObjectWithTag("GameManager").SendMessage("ExperienceGained", xpReward, SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
        }
    }
}
