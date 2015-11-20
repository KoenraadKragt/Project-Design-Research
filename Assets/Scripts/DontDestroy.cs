using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {
    
	void Awake () {

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Application.loadedLevel == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
