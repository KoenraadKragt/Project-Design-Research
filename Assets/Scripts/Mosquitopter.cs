using UnityEngine;
using System.Collections;

public class Mosquitopter : MonoBehaviour {

    public Light eye;
	private float hitpoints;

	public void Start(){
		hitpoints = GetComponent<EnemyBehaviour>().health;
	}

	public void TakeDamage(float amount)
    {
        if(hitpoints <= 2){
			eye.enabled = false;
        	this.enabled = false;
		} else {
			hitpoints = GetComponent<EnemyBehaviour>().health;
			eye.intensity = 2 - 2/(hitpoints - 1);
		}
    }
}
