using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLevelSelect : MonoBehaviour
{
    [SerializeField] bool levelUnlocked;
    [SerializeField] GameObject twirlEffect;
    [SerializeField] GameObject trigger;

    // Start is called before the first frame update
    void Start()
    {
        if (levelUnlocked)
        {
            twirlEffect.SetActive(true);
            trigger.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
