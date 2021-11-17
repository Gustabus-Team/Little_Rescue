using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ChangeCharacter : MonoBehaviour
{
    public GameObject madre;
    public GameObject hijoTop;
    public GameObject hijoMedio;
    public bool estaEncima;
    public bool sePresiona;

    private void Start()
    {
        Destroy(hijoTop.GetComponent<Rigidbody>());
        hijoTop.GetComponent<CMF.AdvancedWalkerController>().enabled = false;

    }


    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftShift)&& !estaEncima)
        {
            if(!sePresiona)
            {
                estaEncima = true;
                hijoTop.transform.DOLocalJump(new Vector3(-0.15f, 0.9f, 0), 0.5f, 1, 0.5f);
                hijoMedio.transform.DOLocalJump(new Vector3(0.15f, 0.9f, 0.6f), 0.5f, 1, 0.5f);
                hijoTop.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.5f);
                hijoMedio.transform.DOLocalRotate(new Vector3(0,-90, 0), 0.5f).OnComplete(() => sePresiona = true);
                hijoTop.GetComponent<CMF.AdvancedWalkerController>().enabled = false;
                Destroy(hijoTop.GetComponent<Rigidbody>());

                print("SeCuelga");

            }


        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && estaEncima)
        {
            if(sePresiona)
            {
                estaEncima = false;
                hijoTop.transform.DOLocalJump(new Vector3(0f, 1.35f, 0.16f), 0.5f, 1, 0.5f);
                hijoMedio.transform.DOLocalJump(new Vector3(0, 0.9f, 0.16f), 0.5f, 1, 0.5f);
                hijoTop.transform.DOLocalRotate(new Vector3(0,0,0), 0.5f);
                hijoMedio.transform.DOLocalRotate(new Vector3(0,0,0), 0.5f).OnComplete(() => sePresiona = false);
                //hijoTop.GetComponent<CMF.AdvancedWalkerController>().enabled = true;
                //hijoTop.AddComponent<Rigidbody>();


            }


        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }



    }







}
