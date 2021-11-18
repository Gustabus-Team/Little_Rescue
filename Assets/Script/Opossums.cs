using UnityEngine;
using DG.Tweening;
using Cinemachine;
using System;
using System.Collections;

public class Opossums : MonoBehaviour
{
    public GameObject opossum;
    public bool callOpossum;
    public int countOpossum;
    public float jumpFallOpossum = 0.8f;
    public bool canRotate;
    public float rotationSpeed;

    public Vector3 aumentoFollowPLayer;


    public Transform followPlayer;


    public float alturaPosition = 1;
    public float profundidadPosition;

    public ZarisAnimateController zariAnim;

    private void Start()
    {
        CameraMovement();
        
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            if(callOpossum && opossum != null)
            {
                StartCoroutine(RotationTransition());

            }
        }
        if (canRotate)
        {
            OpossumRotate();
        }

    }

    public void OpossumRotate()
    {

        opossum.transform.Find("Pivote").RotateAround(opossum.transform.position, Vector3.back, rotationSpeed * Time.deltaTime);
    }

    IEnumerator RotationTransition()
    {
        canRotate = true;
        opossum.transform.parent = transform;
        opossum.transform.DOLocalJump(new Vector3(0, jumpFallOpossum, 0), 5, 1, 1f).SetEase(Ease.Linear);
        countOpossum++;
        alturaPosition++;
        CameraMovement();
        jumpFallOpossum += 0.8f;

        yield return new WaitForSeconds(.5f);
        opossum.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
        canRotate = false;
        callOpossum = false;
        
        zariAnim.ActivateUnroll();
        zariAnim.pivote.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
        yield return new WaitForSeconds(.5f);
        zariAnim = null;

        print("Termino");
        yield break;
    }
 
    public void CameraMovement()
    {
        aumentoFollowPLayer = new Vector3(0, alturaPosition, followPlayer.transform.localPosition.z - 1);
        followPlayer.transform.localPosition = aumentoFollowPLayer;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            print("inicio comparetegag");
            opossum = other.gameObject;
            zariAnim = other.GetComponent<ZarisAnimateController>();
            callOpossum = true;

        }
        print("termino ejecucion");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            callOpossum = false;
            opossum = null;
            zariAnim = null;
        }
    }
}
