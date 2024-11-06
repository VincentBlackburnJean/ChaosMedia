using System;
using System.Threading;
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

    private GameObject cible;

    private fantomeBehavior scriptFantome;

    public score nbDePoints;

    [SerializeField] private int gunDmg = 33;

    [SerializeField] private int prixParSeconde = 50;

    private AudioSource audioSource;


    void Start ()
    {
       
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind+1){
			Destroy(gameObject);
		}


         audioSource = GetComponent<AudioSource>();

	}

    // Update is called once per frame
    void Update () {


        Vector3 fwd = transform.TransformDirection(Vector3.back);

        int layerMask = 1 << 6;

        layerMask = ~layerMask;

		// make sure the Joycon only gets checked if attached
		if (joycons.Count > 0)
        {
			Joycon j = joycons [jc_ind];


            orientation = j.GetVector();

           

            gameObject.transform.localRotation = orientation;

            if (j.GetButtonDown (Joycon.Button.DPAD_DOWN)) {
				Debug.Log ("Rumble");

				j.SetRumble (160, 320, 0.6f, 200);
                j.Recenter ();
				
			}

            RaycastHit hit;
                    // Does the ray intersect any objects excluding the player layer
                    if (Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity, layerMask))
                    {
                        Debug.DrawRay(transform.position, fwd * hit.distance, Color.yellow);
                        Debug.Log("Did Hit");

                        cible = hit.transform.gameObject;

                        scriptFantome = cible.GetComponent<fantomeBehavior>();

                        if (j.GetButton (Joycon.Button.SHOULDER_2))
                        {
                            Debug.Log ("Shoulder button 2 held");

                            nbDePoints.points -= prixParSeconde * Time.deltaTime;

                            audioSource.Play();


                           if(cible.transform.tag == "fantome"){

                                scriptFantome.hp -= gunDmg * Time.deltaTime;

                            }
                        }

                        else{

                            audioSource.Stop();

                        }
                        
                    

                    }


                    
            
        }

        
    }
}
