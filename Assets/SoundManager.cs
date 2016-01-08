using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioClip[] soundSource;
	AudioSource audioSource;

	void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	void SetAudio(int number){
		audioSource.clip = soundSource[number];
		audioSource.Play();
	}
}
