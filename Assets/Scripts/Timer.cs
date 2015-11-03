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
    bool isFinished = false;
    public Energy.lightMode currentMode;

    void Update () {
		timer += Time.deltaTime;
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
        currentTime = System.DateTime.Now.ToString("hh-mm-ss");
        fileName = currentTime + ".txt";

        timerMin = (int)(timer - (timer % 60)) / 60;
        timerSec = ((int)timer) % 60;

        if (File.Exists(fileName))
        {
            Debug.Log(fileName + " already exists.");
            return;
        }
        StreamWriter write = File.CreateText(fileName);

        write.WriteLine("LightMode: " + currentMode.ToString());

        if (reachedGoal)
        {
            write.WriteLine("Goal is reached\n");
        }else
        {
            write.WriteLine("Player has died\n");
        }

        if (timerSec < 10)
        {
            write.WriteLine("Time: " + timerMin + ":0" + timerSec);
        }
        else
        {
            write.WriteLine("Time: " + timerMin + ":" + timerSec);
        }

        write.WriteLine("Risicovol gedrag is " + riskValue.ToString("F1") + " van de "+ timer.ToString("F1") + " seconden");
        write.Close();
    }

    public void SetLightMode(Energy.lightMode _currentMode)
    {
        currentMode = _currentMode;
    }
}

