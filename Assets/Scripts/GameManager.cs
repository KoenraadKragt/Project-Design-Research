using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    private int lives = 3;
    private float totalExperience;
    private float currentXP;
    private Texture heartImage;
    public Slider powerSlider;

    private int playerLevel = 1;
    private Slider experienceSlider;
    private Text playerLevelText;

    public bool permaDeath = false;


    private Timer riskTimer;

    void Awake()
    {
        heartImage = Resources.Load("Heart") as Texture;

        experienceSlider = GameObject.FindGameObjectWithTag("ExperienceSlider").GetComponent<Slider>();
        playerLevelText = GameObject.FindGameObjectWithTag("PlayerLevel").GetComponent<Text>();
        powerSlider = GameObject.FindGameObjectWithTag("PowerSlider").GetComponent<Slider>();

        if (permaDeath)
        {
            lives = 1;
        }


        riskTimer = this.gameObject.GetComponent<Timer>();
        riskTimer.DeathType(permaDeath);

        if (Application.loadedLevel == 1)
        {
            Application.LoadLevel(2);
        }
    }

    void Update()
    {
        if (currentXP >= experienceSlider.maxValue)
        {
            currentXP -= experienceSlider.maxValue;
            experienceSlider.maxValue = 100 + ((playerLevel * playerLevel) *  10);
            playerLevel += 1;
            playerLevelText.text = playerLevel.ToString();
        }
        experienceSlider.value = currentXP;
    }

    public void ExperienceGained(float amount)
    {
        totalExperience += amount;
        currentXP += amount;
    }

    public void Death()
    {
        lives -= 1;
        Debug.Log("lives(death) " + lives);

        if (lives <= 0)
        {

            ReachedGoal();
        } else if (lives > 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void ReachedGoal()
    {

        this.gameObject.SendMessage("Experience", totalExperience, SendMessageOptions.DontRequireReceiver);
        this.gameObject.SendMessage("WriteFile", lives, SendMessageOptions.DontRequireReceiver);
        Application.LoadLevel(0);
    }

    void OnGUI()
    {
        if (!permaDeath)
        {
            int positionX = 10;
            int i = 0;

            while (i < lives)
            {
                GUI.DrawTexture(new Rect(positionX, 10, 60, 60), heartImage, ScaleMode.ScaleToFit, true, 10.0F);
                positionX += 80;
                i++;
            }

        }

    }

}
