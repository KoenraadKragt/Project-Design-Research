using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    private Vector3 portalTarget;

    public int finalLevel = 5;

    void Awake()
    {
        portalTarget = GameObject.FindGameObjectWithTag("PortalTarget").transform.position;
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (Application.loadedLevel == finalLevel)
            {
                other.gameObject.transform.position = portalTarget;
            }
            else
            {
                Application.LoadLevel(Application.loadedLevel + 1);

            }

        }
    }
}
