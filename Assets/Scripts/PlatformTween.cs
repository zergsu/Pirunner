using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// This script will make an object travel between any amount of positions in a set sequence
// The object will first be moved to the LAST station
public class PlatformTween : MonoBehaviour
{
    [SerializeField] Vector3[] stations;
    [SerializeField] float tweenDur;
    Vector3 startPos;
    Tween tweenInit;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        // make an initial tween towards the last station
        tweenInit = transform.DOMove(stations[stations.Length - 1], TTime());
        // start the tween and once it ends start a looping sequence
        tweenInit.Play().SetEase(Ease.Linear).OnComplete(() => MakeSeq());
    }

    // Make and start the sequence for this object
    void MakeSeq()
    {
        //make tweens between the stations
        Tween[] tweens = new Tween[stations.Length];
        //declare a new looping sequence
        Sequence seq = DOTween.Sequence();
        seq.SetLoops(-1);

        //build a sequence to go through all stations
        for (int i = 0; i < stations.Length; i++)
        {
            tweens[i] = transform.DOMove(stations[i], tweenDur).SetEase(Ease.InOutSine);
            seq.Append(tweens[i]);
        }
    }

    // A method that calculates tween duration for the initial tween based on the time and distance of the first tween
    float TTime()
    {
        float smartTime;
        Vector3 distance, distanceFull;
        float speed;
        //finds the distance between the first stations
        distanceFull = stations[1] - stations[0];
        //calculate the avg speed the object will have
        speed = distanceFull.magnitude / tweenDur;
        //finds the distance between the initial position and the last station
        distance = stations[stations.Length - 1] - startPos;
        //use the avg speed and the distance to calculate tween duration
        smartTime = distance.magnitude / speed;

        Debug.Log(smartTime);
        return smartTime;
    }
}
