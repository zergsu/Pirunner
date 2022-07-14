using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicSource, effectsSource, oceanSource;

	public bool notDiedYet = true;

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


	private void Start()
	{
		//musicSource.Play();
	}

	public void PlaySound(AudioClip clip)
	{
        effectsSource.PlayOneShot(clip);
	}
}
