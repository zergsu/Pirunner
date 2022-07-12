using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{

	[SerializeField] private Slider sfxSlider;
	[SerializeField] private Slider musicSlider;

	public Timer timer;

    public static SoundManager instance;

    [SerializeField] private AudioSource musicSource, effectsSource;
	[SerializeField] private AudioClip music;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Update()
	{
		effectsSource.volume = sfxSlider.value;
		musicSource.volume = musicSlider.value;

		if(timer.justStarted == false)
		{
			//PlayMusic(music);
		}
	}


	public void PlaySound(AudioClip clip)
	{
        effectsSource.PlayOneShot(clip);
	}

    public void PlayMusic(AudioClip music)
	{
        musicSource.PlayOneShot(music);
	}


    public void ChangeMasterVolume(float value)
	{
        AudioListener.volume = value;
	}
}
