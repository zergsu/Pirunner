using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PortalLevelSelect : MonoBehaviour
{
    [SerializeField] bool levelUnlocked;
    [SerializeField] GameObject twirlEffect;
    [SerializeField] PortalScript trigger;
    [SerializeField] TextMeshPro Header;
    [SerializeField] GameObject Score;

    // Start is called before the first frame update
    void Start()
    {
        if (levelUnlocked)
        {
            twirlEffect.SetActive(true);
            trigger.gameObject.SetActive(true);
        }
        switch (trigger.level)
        {
            case < 5:
                Header.text = ("Level " + trigger.level);
                break;
            case 5:
                Header.text = ("Level Select");
                break;
            case > 5:
                Header.text = ("To Be Continued");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Score.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Score.SetActive(false);
    }
}
