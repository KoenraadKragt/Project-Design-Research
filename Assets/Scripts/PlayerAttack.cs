using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public GameObject attack;
    bool left = false;
    bool cooldown = false;


    Quaternion rotation = Quaternion.identity;
    Vector3 position = Vector3.zero;
    Vector3 scale = Vector3.zero;

    void Update() {


        if (Input.GetAxis("Horizontal") < 0)
        {
            left = true;
            position = transform.position + new Vector3(-0.7f, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") > 0 )
        {
            left = false;
            position = transform.position + new Vector3(0.7f, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.Z) && cooldown == false)
        {
           
            rotation = transform.rotation;
            
            scale = transform.localScale * 0.6f;

            GameObject clone = (GameObject)Instantiate(attack, transform.position, rotation);
            clone.transform.localScale = scale;

            StartCoroutine(Wait());
        }
	}

    private IEnumerator Wait()
    {
        cooldown = true;
        yield return new WaitForSeconds(.3f);
        cooldown = false;
    }
}
