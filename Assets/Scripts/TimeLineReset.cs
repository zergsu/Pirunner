using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineReset : MonoBehaviour
{
    [SerializeField] GameObject camPos;
    [SerializeField] GameObject fadeFX;
	[SerializeField] GameObject Timer;
	[SerializeField] PlayableDirector Timeline;
	[SerializeField] LevelMenu levelMenu;



	[SerializeField] Vector3 camPosReset = new Vector3(-6f, 6.5f, -16.6f);


	private void Update()
	{
		if (Timeline.state !=PlayState.Playing)
		{
			SoundManager.instance.PlayMusic();
			camPos.transform.position = camPosReset;
			camPos.transform.rotation = Quaternion.Euler(0, 0, 0);
			Destroy(fadeFX);
			Timer.SetActive(true);
			Destroy(gameObject);
			levelMenu.canOpen = true;
			GameManager.instance.inTimeLine = false;
		}

		else if(Timeline.state == PlayState.Playing)
		{
			SoundManager.instance.musicSource.Stop();
			GameManager.instance.playerWon = false;
			levelMenu.canOpen = false;
			GameManager.instance.inTimeLine = true;
		}
	}
}
