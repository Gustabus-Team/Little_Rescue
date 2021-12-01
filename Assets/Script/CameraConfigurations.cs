using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfigurations : MonoBehaviour
{
    RaycastHit oldHit;

    void FixedUpdate()
    {
        //XRay();
    }

    // Hacer a los objetos que interfieran con la vision transparentes
    /*private void XRay()
    {

        float characterDistance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit, characterDistance))
        {         
            // Add transparence
            Color colorB = hit.transform.GetComponent<Renderer>().material.color;
            colorB.a = 0.5f;
            print("lo setio en 0.5");
            if (oldHit.transform)
            {
                // Add transparence
                Color colorA = oldHit.transform.GetComponent<Renderer>().material.color;
                colorA.a = 1f;
                oldHit.transform.GetComponent<Renderer>().material.SetColor("_Color", colorA);
                print("lo setio en 1");
            }

            hit.transform.gameObject.GetComponent<Renderer>().material.SetColor("_Color", colorB);

            // Save hit
            oldHit = hit;
        }
    }*/
}