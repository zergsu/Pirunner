using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLevelSelect : MonoBehaviour
{
    [SerializeField] bool levelUnlocked;
    [SerializeField] GameObject twirlEffect;
    [SerializeField] GameObject trigger;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject Score;

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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("s");
        Canvas.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Canvas.SetActive(false);
    }
}
