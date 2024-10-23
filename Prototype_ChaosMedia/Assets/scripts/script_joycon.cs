using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_joycon : MonoBehaviour
{
private List<Joycon> joycons;

    // Values made available via Unity
    public float[] stick;
   
    public int jc_ind = 0;
    public Quaternion orientation;

    public Vector3 trueRotation;


    void Start ()
    {
       
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind+1){
			Destroy(gameObject);
		}
	}

    // Update is called once per frame
    void Update () {
		// make sure the Joycon only gets checked if attached
		if (joycons.Count > 0)
        {
			Joycon j = joycons [jc_ind];


            orientation = j.GetVector();

           // trueRotation = orientation.eulerAngles;

            gameObject.transform.localRotation = orientation;
            
        }

        
    }
}
