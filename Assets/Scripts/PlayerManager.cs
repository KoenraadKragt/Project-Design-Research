using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	bool timeRunning = true;
	bool levelUpEnabled = false;
	public int unspentPoints = 0;
	public Texture background;

	int buttonLength = 500;

	string[] upgradeTitle;

    bool delayedLevelUp;

    void Awake()
    {
        delayedLevelUp = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().delayedLevelUp;
    }

	void Update () {
		// For Testing Only
		if (!delayedLevelUp && unspentPoints > 0) {
			if(timeRunning){
				StartCoroutine(FadeOut());
                timeRunning = false;
			}
		}
	}

	void OnGUI(){
		if (levelUpEnabled){
			GUIStyle centeredStyle = GUI.skin.GetStyle("Label");
			centeredStyle.alignment = TextAnchor.UpperCenter;
			centeredStyle.fontStyle = FontStyle.Bold;
			centeredStyle.fontSize = 24;
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),background,ScaleMode.StretchToFill,true,10.0f);
			GUI.Label (new Rect(Screen.width/2 - buttonLength/2, Screen.height/8 - Screen.height/16,buttonLength,Screen.height/8),"Unspent Skillpoints: " + unspentPoints);
			if(GUI.Button(new Rect(Screen.width/2 - buttonLength/2,Screen.height/6,buttonLength,Screen.height/6),"Upgrade 1")){
				unspentPoints-=1;
			}

			if(GUI.Button(new Rect(Screen.width/2 - buttonLength/2,Screen.height/6 * 3,buttonLength,Screen.height/6),"Upgrade 2")){
				unspentPoints-=1;
			}

			if(GUI.Button(new Rect(Screen.width/2 - buttonLength/2,Screen.height/6 * 5,buttonLength,Screen.height/6),"Upgrade 3")){
				unspentPoints-=1;
			}
			if(unspentPoints <= 0){
				StartCoroutine(FadeIn());
				levelUpEnabled = false;
			}
		}
	}

	IEnumerator FadeOut(){
		yield return new WaitForSeconds(0.1f * Time.timeScale);
		if (Time.timeScale > 0.1f) {
			Time.timeScale -= 0.1f;
			StartCoroutine (FadeOut ());
            Debug.Log("Timescale is going down");
		} else {
			Time.timeScale = 0.0f;
            Debug.Log("Timescale is 0");
			levelUpEnabled  = true;
		}
    }

	void LevelUp(){
		unspentPoints  += 1;
	}

	IEnumerator FadeIn(){
		yield return new WaitForSeconds(0.1f * Time.timeScale);
		if (Time.timeScale < 1.0f) {
			Time.timeScale += 0.1f;
			StartCoroutine (FadeIn ());
		} else {
			Time.timeScale = 1.0f;
			timeRunning = true;
		}
	}

    public void PortalReached()
    {
        if (delayedLevelUp && unspentPoints > 0)
        {
            levelUpEnabled = true;            
        }
    }
}
