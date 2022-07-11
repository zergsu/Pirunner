using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{

	[SerializeField] private Slider sfxSlider;
	[SerializeField] private Slider musicSlider;

    public static SoundManager instance;

    [SerializeField] private AudioSource musicSource, effectsSource;

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
	}


	public void PlaySound(AudioClip clip)
	{
        effectsSource.PlayOneShot(clip);
	}

    public void PlayMusic(AudioClip music)
	{
        musicSource.clip = music;
        musicSource.Play();
	}


    public void ChangeMasterVolume(float value)
	{
        AudioListener.volume = value;
	}
}
