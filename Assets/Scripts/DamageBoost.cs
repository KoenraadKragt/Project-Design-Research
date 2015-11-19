using UnityEngine;
using System.Collections;

public class DamageBoost : MonoBehaviour {

    public float highDamage = 2;

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("PowerBoost", highDamage, SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
        }
    }
}
