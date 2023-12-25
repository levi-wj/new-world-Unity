using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master volume";
	const string DIFFICULTY_KEY = "difficulty";

	public static void SetMasterVolume(float volume)
	{
		if(volume >= 0 && volume <= 1) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
			Debug.Log("Master Volume Key changed to " + volume);
		}else{
			Debug.LogError("Unable to set Player preference. Value out of range.");
		}
		
	}

	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void SetDifficulty(float difficulty)
	{
		if(difficulty >= 3 && difficulty <= 5) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
			Debug.Log("Difficulty set to " + difficulty);
		}else{
			Debug.LogError("Unable to set difficulty. Set to a a value 3-5");
		}
	}

	public static float GetDifficulty()
	{
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
