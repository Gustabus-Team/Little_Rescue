using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ZarisAnimateController : MonoBehaviour
{

    public Animator zariAnimator;
    public GameObject pivote;

    private void Awake()
    {
        zariAnimator = GetComponentInChildren<Animator>();
    }
    public void ActivateUnroll()
    {
        zariAnimator.SetBool("Unroll_Bool", true);
    }
    public void ActivateAnim()
    {
        Invoke("ActivateUnroll(", 0.4f);
    }
}
