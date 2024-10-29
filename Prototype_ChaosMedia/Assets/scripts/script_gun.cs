using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_gun : MonoBehaviour
{
 

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.back);

        int layerMask = 1 << 6;

        layerMask = ~layerMask;


        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, fwd * hit.distance, Color.yellow);
            Debug.Log("Did Hit");

          /*  if (j.GetButton (Joycon.Button.SHOULDER_2))
			{
				Debug.Log ("Shoulder button 2 held");
			}
            
           */

        }
       

       
    }
}

