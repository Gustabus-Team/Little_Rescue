using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialCanvasFade : MonoBehaviour
{
    public CanvasGroup panelToFade;
    public Transform playerPos;
    public bool inFade;
    public int distance;
    private void FixedUpdate()
    {
        Vector3 direction = transform.position - playerPos.position;

        if (Vector3.Distance(transform.position, playerPos.position) <= distance)
        {
            if (inFade)
            {
                inFade = false;
                FadeCanvas(1, 1);
            }
        }
        else
        {
            if (!inFade)
            {
                inFade = true;
                FadeCanvas(0, 1);
            }
        }
    }
    public void FadeCanvas(float alpha, float time)
    {
        panelToFade.DOFade(alpha, time);
    }


}
