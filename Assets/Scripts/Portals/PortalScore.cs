using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PortalScore : MonoBehaviour
{
    public TextMeshPro text;
    public float a, b, c;

    void Start()
    {
        text.text = $"Best Times <br>{a.ToString("F2")}<br>{b.ToString("F2")}<br>{c.ToString("F2")}";
    }

}
