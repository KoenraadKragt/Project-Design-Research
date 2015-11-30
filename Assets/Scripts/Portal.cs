using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    private Vector3 portalTarget;

    public int finalLevel = 5;

    void Awake()
    {
        Debug.Log(Application.levelCount);

        if(GameObject.FindGameObjectWithTag("PortalTarget") == null)
        {
            Debug.Log("No target for the portal.");
            return;
        }
        portalTarget = GameObject.FindGameObjectWithTag("PortalTarget").transform.position;
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (Application.loadedLevel < Application.levelCount-1)
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
            else
            {
                other.gameObject.transform.position = portalTarget;
            }

        }
    }
}
