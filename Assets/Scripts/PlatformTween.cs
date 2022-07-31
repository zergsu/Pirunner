using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlatformTween : MonoBehaviour
{
    [SerializeField] Vector3[] stations;
    [SerializeField] float tweenDur;
    Vector3 startPos;
    Tween tweenInit;


    void Start()
    {
        startPos = transform.position;
        tweenInit = transform.DOMove(stations[stations.Length - 1], TTime());
        tweenInit.Play().SetEase(Ease.Linear).OnComplete(() => MakeSeq());
    }


    void MakeSeq()
    {
        Tween[] tweens = new Tween[stations.Length];
        Sequence seq = DOTween.Sequence();
        seq.SetLoops(-1);

 
        for (int i = 0; i < stations.Length; i++)
        {
            tweens[i] = transform.DOMove(stations[i], tweenDur).SetEase(Ease.InOutSine);
            seq.Append(tweens[i]);
        }
    }


    float TTime()
    {
        float smartTime;
        Vector3 distance, distanceFull;
        float speed;
        distanceFull = stations[1] - stations[0];
        speed = distanceFull.magnitude / tweenDur;
        distance = stations[stations.Length - 1] - startPos;
        smartTime = distance.magnitude / speed;

        Debug.Log(smartTime);
        return smartTime;
    }
}
