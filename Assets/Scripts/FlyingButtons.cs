using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//Makes menu buttons fly into the screen
//it might be better to check the condition on a game manager that toggles on/off, and put this script on a canvas
public class FlyingButtons : MonoBehaviour
{

    [SerializeField] GameObject[] elements;
    [SerializeField] float tweenDur;

    float screenPart = Screen.height / 6;
    Vector2 hidingPos = new Vector2(-80, -15);

    // Start is called before the first frame update
    private void Start()
    {

    }

    private void OnEnable()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].transform.position = hidingPos;
        }

        StartCoroutine(DelayTween());

    }

    IEnumerator DelayTween()
    {
        //go through every button and tween it to a position on the canvas, each button is lower, and with a small delay
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].transform.DOMove(new Vector3(transform.position.x, transform.position.y + screenPart - (screenPart * i), 0), tweenDur).SetUpdate(true);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}