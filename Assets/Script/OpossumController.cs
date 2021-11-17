using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class OpossumController : MonoBehaviour
{
    public GameObject opossum;
    public bool callOpossum;
    public int countOpossum;
    public float jumpFallOpossum = 0.8f;

    public Vector3 aumentoFollowPlayer;
    public Transform followPlayer;
    public float alturaPosition = 15;
    public float profundidadPosition;


    private void Start()
    {
        CameraMovement();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (callOpossum && opossum != null)
            {
                callOpossum = false;
                opossum.transform.parent = transform;
                opossum.transform.DOLocalJump(new Vector3(0, jumpFallOpossum, 0), 5, 1, 0.5f);
                opossum.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
                jumpFallOpossum += 0.8f;
                countOpossum++;   //esto deberia eliminarse pero se quedara para futuras pruebas
                GameManager._gameManager.opposumCount++; // esto conecta con el gameManager
                alturaPosition++;
                CameraMovement();
                Invoke("CallAnimation", 0.3f);

            }
        }

    }
    public void CallAnimation()
    {
        trash.GetComponent<ZarisAnimateController>().ActivateUnroll();
    }

    public GameObject trash;
    public void CameraMovement()
    {
        aumentoFollowPlayer = new Vector3(0, alturaPosition, followPlayer.transform.localPosition.z - 1);
        followPlayer.transform.localPosition = aumentoFollowPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            print("inicio comparetegag");
            trash = other.gameObject;
            opossum = other.transform.GetChild(0).gameObject;
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
        }
    }
}   