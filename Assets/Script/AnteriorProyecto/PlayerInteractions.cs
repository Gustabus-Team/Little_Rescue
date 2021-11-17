using UnityEngine;
using System.Collections;


public class PlayerInteractions : MonoBehaviour
{
    public GameObject enterObject;
    public GameObject player;
    public bool itemIn;
    private void Start()
    {
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Movible"))
        {
            enterObject = other.gameObject;
            itemIn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(itemIn)
        {
            enterObject.transform.parent = null;
            itemIn = false;
        }
       
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)&&itemIn)
        {
            itemIn = false;
            enterObject.transform.parent = gameObject.transform;
            enterObject.transform.localPosition = new Vector3 (0, 0.7f, 1.3f);
            enterObject.transform.localRotation = Quaternion.identity;
            enterObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(enterObject.GetComponent<Rigidbody>());
            print("destruye wea;");
        }
        if (Input.GetMouseButtonUp(0) && !itemIn)
        {
            print("ay se me cayo");
            enterObject.transform.parent = null;
            enterObject.GetComponent<BoxCollider>().enabled = true;
            enterObject.AddComponent<Rigidbody>();
            enterObject = null;
        }



        if (Input.GetMouseButtonDown(1))
        {
           player.GetComponent<CMF.AdvancedWalkerController>().movementSpeed = 10;
        }

        if (Input.GetMouseButtonUp(1))
        {
            player.GetComponent<CMF.AdvancedWalkerController>().movementSpeed = 7;
        }


    }



}
