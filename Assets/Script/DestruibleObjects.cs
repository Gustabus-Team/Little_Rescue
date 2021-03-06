using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class DestruibleObjects : MonoBehaviour
{
   // public Transform DestruibleObj;
    public GameObject player;
    public GameObject[] Obstacle;
    public float countToDestroy;
    public float forceImpulse;
    public GameObject water;
    public bool isHidrante;


    //texto
    public TextMeshProUGUI have;
    public TextMeshProUGUI need;
    public bool canRotate;
    public bool fueUsado = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }
    // Update is called once per frame
    void Update()
    {
        //setear texto
        have.text = GameManager._gameManager.opposumCount.ToString();
        need.text = countToDestroy.ToString();
        //con esto logramos rotar
        if(canRotate)
        {
            var lookPos = player.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 500);
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {        
            if(GameManager._gameManager.opposumCount >= countToDestroy && !fueUsado)
            {
                fueUsado = true;
                for(int i = 0; i < Obstacle.Length; i++)
                {
                    Obstacle[i].GetComponent<Rigidbody>().isKinematic = false;
                    print("numero obstaculo " + i);
                }
                if(isHidrante)
                {
                    isHidrante = false;
                    Instantiate(water, transform.position , Quaternion.Euler(0,90,0)); 
                }
                GameManager._gameManager.destroyedObjects++;
            }
            else
            {
                print("no cumple los requisitos");
            }
        }
    }

    public CanvasGroup panelToFade;
    public bool inFade;
    public int distance;
    private void FixedUpdate()
    {
        Vector3 direction = transform.position - player.transform.position;

        if (Vector3.Distance(transform.position, player.transform.position) <= distance)
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
