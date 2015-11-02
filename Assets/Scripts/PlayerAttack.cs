using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public GameObject attack;
    public Vector3 spawn = new Vector3(20, -2, 0);
    bool left = false;
    bool right = true;
    bool cooldown = false;
    
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("left"))
        {
            left = true;
            right = false;
            print ("going left");
        }
        else if (Input.GetKeyDown("right"))
        {
            right = true;
            left = false;
            print ("going right");
        }

        if(Input.GetKeyDown(KeyCode.Z) && cooldown == false)
        {            
            print("attacking");
            if(left == true && right == false)
            {
                Instantiate(attack, transform.position - (new Vector3(0.7f, 0, 0)), new Quaternion(0f, 0f, 0f, 0f));
            }
            if (left == false && right == true)
            {
                Instantiate(attack, transform.position + (new Vector3(0.7f, 0, 0)), new Quaternion(0f, 180f, 0f, 0f));
            }
            StartCoroutine(Wait());
        }
	}

    private IEnumerator Wait()
    {
        print("wait");
        cooldown = true;
        yield return new WaitForSeconds(.3f);
        cooldown = false;
    }
}
