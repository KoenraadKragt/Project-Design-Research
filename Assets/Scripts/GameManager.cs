using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private int lives = 3;
    private float totalExperience;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        Debug.Log("lives(awake) " + lives);
    }

    void Update()
    {
        if (Application.loadedLevel == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void ExperienceGained(float amount)
    {
        totalExperience += amount;
        Debug.Log(totalExperience);
    }

    public void Death()
    {
        lives -= 1;
        Debug.Log("lives(death) " + lives);

        if (lives <= 0)
        {
            Application.LoadLevel(0);
        } else if (lives > 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
