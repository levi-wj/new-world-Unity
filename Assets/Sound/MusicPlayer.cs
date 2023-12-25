using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	AudioSource aS;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		aS = GetComponent<AudioSource>();
		StartCoroutine(FadeIn(aS, 4f, PlayerPrefsController.GetMasterVolume()));
	}
	
	public void setVolume(float volume)
	{
		aS.volume = volume;
	}

	 public static IEnumerator FadeIn(AudioSource aS, float fadeTime, float finishValue)
    {
        float startVolume = 0.0f;
 
        aS.volume = 0;
 
        while (aS.volume < finishValue)
        {
            aS.volume += startVolume * Time.deltaTime / fadeTime;
 
            yield return null;
        }
 
        aS.volume = 1f;
    }
}
