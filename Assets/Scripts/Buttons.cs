using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

	public void RestartLevel()
	{
        GameManager.instance.RestartLevel();
	}

    public void BackToMenu()
	{
        GameManager.instance.BackToMenu();
	}

}
