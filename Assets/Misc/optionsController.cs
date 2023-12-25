using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsController : MonoBehaviour {

	[SerializeField] Slider volumeSlider;
	[SerializeField] float defaultVolume = .5f;

	[SerializeField] Slider difficultySlider;
	[SerializeField] int defaultDifficulty = 2;

	MusicPlayer musicPlayer;

	public void SavePrefsFromSliders()
	{
		PlayerPrefsController.SetMasterVolume(volumeSlider.value);
		PlayerPrefsController.SetDifficulty(difficultySlider.value);
	}

	public void ResetSliderValues()
	{
		volumeSlider.value = defaultVolume;
		difficultySlider.value = defaultDifficulty;
	}

	void Start () {
		volumeSlider.value = PlayerPrefsController.GetMasterVolume();
		difficultySlider.value = PlayerPrefsController.GetDifficulty();

		musicPlayer = FindObjectOfType<MusicPlayer>();
	}
	
	void Update () {
		if(musicPlayer){
			musicPlayer.setVolume(volumeSlider.value);
		}else{
			Debug.LogWarning("No music player in scene.");
		}
	}
}
