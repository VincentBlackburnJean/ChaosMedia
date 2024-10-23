using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_crosshair : MonoBehaviour
{
 

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int layerMask = 1 << 6;

        layerMask = ~layerMask;


        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, fwd * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            
           

        }
       

       
    }
}

