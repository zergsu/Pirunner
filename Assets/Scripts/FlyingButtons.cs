using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//Makes menu buttons fly into the screen
//it might be better to check the condition on a game manager that toggles on/off, and put this script on a canvas
public class FlyingButtons : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;
    [SerializeField]
    float tweenDur;

    public bool clickable = true;

    int menuUp; //0 closed, 1 opening, 2 open
    Vector3 hidingPos;

    private void Start()
    {
        hidingPos = buttons[0].transform.position;
    }
    void Update()
    {
        // Menu open/close condition
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (menuUp == 0)
            {
                menuUp = 2;
                Test();
            }
            else if (menuUp == 2)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].transform.DOComplete();
                    buttons[i].transform.DOMove(hidingPos, 0);
                }

                menuUp = 0;
            }
        }

    }


    [ContextMenu("Test")]
    void Test()
    {
        if(clickable)
		{
            StartCoroutine(Delay());
        }
    }
    
    IEnumerator Delay()
    {
        //go through every button and tween it to a position on the canvas, each button is lower, and with a small delay
        for (int i = 0; i < buttons.Length; i++)
        {
            clickable = false;
            buttons[i].transform.DOMove(new Vector3(transform.position.x, transform.position.y + 50 - (30 * i), 0), tweenDur);//.SetId(i).OnComplete(() => CheckIfDone());
            yield return new WaitForSeconds(0.1f);
            clickable = true;
        }
    }
}
