using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    private bool isChasing = false;
    private GameObject player;
    public float speed;
    public float rotationSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update () {
        if (isChasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        transform.rotation *= Quaternion.Euler(Vector3.forward * rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isChasing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isChasing = false;
        }
    }
}
