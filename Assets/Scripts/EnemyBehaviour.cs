using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    private GameObject player;
    public float speed;
    public float rotationSpeed;
    public float range = 10;
    private Timer riskTimer;

    public int health = 2;

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

            if(riskTimer.currentMode == Energy.lightMode.Constant)
            {
                riskTimer.riskValue += Time.deltaTime;
            }
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
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
        health -= (int)amount;
    }
}
