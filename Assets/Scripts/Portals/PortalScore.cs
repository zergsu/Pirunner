using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PortalScore : MonoBehaviour
{
    public TextMeshPro text;
    public float a, b, c;
    // Start is called before the first frame update
    void Start()
    {
        text.text = $"Best Times <br>{a}<br>{b}<br>{c}";
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    CheckScore(1.5f);
        //    SaveData.SaveNewScore(a, b, c);
        //}

    }

    void CheckScore(float newTime)
    {
        if (newTime < c)
        {
            c = b;
            if (newTime < b)
            {
                b = a;
                if (newTime < a)
                {
                    a = newTime;
                }
                else b = newTime;
            }
            else c = newTime;
            
        }
        Debug.Log(a+""+ b+""+ c);
    }
}
