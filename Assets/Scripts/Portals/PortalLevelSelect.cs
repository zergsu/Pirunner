using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PortalLevelSelect : MonoBehaviour
{
    LevelData data;
    [SerializeField] bool levelUnlocked;
    [SerializeField] GameObject twirlEffect;
    [SerializeField] PortalScript trigger;
    [SerializeField] TextMeshPro Header;
    [SerializeField] PortalScore Score;

    // Start is called before the first frame update
    void Start()
    {
        switch (trigger.level)
        {
            case < 5:
                LoadPortalData();
                Header.text = ("Level " + trigger.level);
                break;
            case 5:
                Header.text = ("Level Select");
                break;
            case > 5:
                Header.text = ("To Be Continued");
                break;
        }

        if (levelUnlocked)
        {
            twirlEffect.SetActive(true);
            trigger.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Score.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Score.gameObject.SetActive(false);
    }

    private void LoadPortalData()
    {
        data = SaveData.Load2(trigger.level - 1);
        levelUnlocked = data.unlocked;
        Score.a = data.high1;
        Score.b = data.high2;
        Score.c = data.high3;
    }
}
