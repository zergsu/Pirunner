using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{

	[SerializeField] Slider musicSlider, sfxSlider, sensSlider;

	[SerializeField] PlayerCam playerCam;

	private void Update()
	{
		SoundManager.instance.musicSource.volume = musicSlider.value;
		SoundManager.instance.effectsSource.volume = sfxSlider.value;
		SoundManager.instance.oceanSource.volume = sfxSlider.value;
		playerCam.mouseSensitivity = sensSlider.value * 200;
	}
}
