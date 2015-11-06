using UnityEngine;
using System.Collections;
using System.IO;

public class Timer : MonoBehaviour {

	private float timer;
	private int timerMin;
	private int timerSec;
	private string currentTime;
	private string fileName;


    public float riskValue;
    public bool isEnemyNear = false;
    public float enemyNear;
    public float energyHigh;
    public float energyLow;
    public float moving;
    public int enemyCount = 0;


    bool isFinished = false;
    public Energy.lightMode currentMode;

    void Update () {
		timer += Time.deltaTime;

        if (isEnemyNear)
        {
            enemyNear += Time.deltaTime;
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Solar")
        {
            WriteFile(true);

            Time.timeScale = 0.0f;
            isFinished = true;
        }
    }
    void OnGUI()
    {
        if (isFinished)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2, 500, 50), "You found the Solar Artifact!"))
            {
                Time.timeScale = 1.0f;
                Application.LoadLevel(0);
            }
        }
    }

    private void WriteFile(bool reachedGoal)
    {
        currentTime = System.DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
        fileName = currentTime + ".txt";

        timerMin = (int)(timer - (timer % 60)) / 60;
        timerSec = ((int)timer) % 60;

        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " already exists.");
            return;
        }
        StreamWriter write = File.CreateText(fileName);

        //#######################################################################################

        write.WriteLine("LightMode: " + currentMode.ToString());

        if (reachedGoal)
        {
            write.WriteLine("Goal is reached");
        }else
        {
            write.WriteLine("Player has died");
        }

        if (timerSec < 10)
        {
            write.WriteLine("Time: " + timerMin + ":0" + timerSec);
        }
        else
        {
            write.WriteLine("Time: " + timerMin + ":" + timerSec);
        }

        write.WriteLine("\nCompletion Time:\t" + timer.ToString("F1") + " seconden");
        write.WriteLine("Time near enemy:\t" + enemyNear.ToString("F1") + " seconden");
        write.WriteLine("Time low energy:\t" + energyLow.ToString("F1") + " seconden");
        write.WriteLine("Time high energy:\t" + energyHigh.ToString("F1") + " seconden");
        write.WriteLine("Time spent moving:\t" + moving.ToString("F1") + " seconden");


        write.WriteLine("Player has encountered:\t" + enemyCount + " enemies");

        write.Close();
        //#######################################################################################

    }

    public void SetLightMode(Energy.lightMode _currentMode)
    {
        currentMode = _currentMode;
    }
}

