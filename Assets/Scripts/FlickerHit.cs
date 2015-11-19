using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlickerHit : MonoBehaviour {

	bool flickerOn = false;
	float flickerTime;
	float color;
	Color baseColor;
	Color color1;
	Color color2;
	int runX = 8;
	Renderer rend;


	void Start(){
		rend = GetComponent<Renderer>();
		baseColor = rend.material.color;
		color1 = new Color(1,0,0.2f);
		color2 = new Color(1,1,1);
	}

	void OnHit(float iTime){
		flickerTime = iTime/runX;
		Flicker(flickerTime,runX);
		StartCoroutine(Flicker(flickerTime,runX));
	}

	IEnumerator Flicker(float waitTime,int times){
		yield return new WaitForSeconds(waitTime);
		if(flickerOn){
			flickerOn = false;
			rend.material.color = color1;
		} else {
			flickerOn = true;
			rend.material.color = color2;
		}
		if(times>0){
			StartCoroutine(Flicker(flickerTime,times-1));
		} else {
			rend.material.color = baseColor;
		}
	}
}
