using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    private Vector3 portalTarget;

    void Awake()
    {
        portalTarget = GameObject.FindGameObjectWithTag("PortalTarget").transform.position;
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = portalTarget;
        }
    }
}
