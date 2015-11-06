using UnityEngine;
using System.Collections;

public class Mosquitopter : MonoBehaviour {

    public Light eye;

	public void TakeDamage(float amount)
    {
        eye.enabled = false;
        this.enabled = false;
    }
}
