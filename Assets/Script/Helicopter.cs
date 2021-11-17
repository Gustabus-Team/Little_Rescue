using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Helicopter : MonoBehaviour
{

    public Transform helice;
    void Start()
    {
        helice.DORotate(new Vector3(0, 360, 0), 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        transform.DOMoveY(transform.position.y - 1.75f, 3).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DOTween.Kill(helice.transform);
        }
    }

}
