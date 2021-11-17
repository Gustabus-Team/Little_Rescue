using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour
{
    public Transform zari1;
    public Transform zari2;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            zari1.DOLocalJump(new Vector3(0, 2.5f, 0), 1,1,0.5f).SetEase(Ease.Linear);
            zari2.DOLocalJump(new Vector3(0, 4.2f, 0), 1, 1, 0.5f).SetEase(Ease.Linear);

        }
    }
}
