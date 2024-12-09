using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_joycon : MonoBehaviour
{
private List<Joycon> joycons;

    // Values made available via Unity
    public float[] stick;
   
    public int jc_ind = 0;
    public Quaternion orientation;
    public Quaternion orientation2;

    public Vector3 trueRotation;

    private GameObject cible;

    private fantomeBehavior scriptFantome;

    private bossBehavior scriptBoss; 
    private bossCloneBehavior scriptClones; 

    public score nbDePoints;

    [SerializeField] private int gunDmg = 50;

    [SerializeField] private int prixParSeconde = 50;

    private AudioSource audioSource;

    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject crosshair;
    
    private ParticleSystem spray;
    private ParticleSystem fantomeParticle;

    private Scene currentScene;

    public menuStart sceneManager;
    
    
        
    

    


    void Start ()
    {
       
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind+1){
			Destroy(gameObject);
		}


         audioSource = GetComponent<AudioSource>();

         spray = GetComponent<ParticleSystem>();

         Scene currentScene = SceneManager.GetActiveScene ();

         

	}

    // Update is called once per frame
    void Update () {

        string sceneName = currentScene.name;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int layerMask = 1 << 6;

        layerMask = ~layerMask;

		// make sure the Joycon only gets checked if attached
		if (joycons.Count > 0)
        {
			Joycon j = joycons [jc_ind];

            orientation = j.GetVector();

            if(j.GetButton (Joycon.Button.DPAD_DOWN)){

                    if (SceneManager.GetActiveScene().buildIndex == 0) 
                        {
                            sceneManager.StartGame();
                        }
                        else if (SceneManager.GetActiveScene().buildIndex == 2)
                        {
                            sceneManager.EndGame();
                        } 
            }

            if (j.GetButtonDown (Joycon.Button.SHOULDER_1)) {
				Debug.Log ("Rumble");

				j.SetRumble (160, 320, 0.6f, 200);
                j.Recenter ();
				
			}



           if (joycons.Count == 2){

            Joycon j2 = joycons [1];

            orientation2 = j2.GetVector();

           if (j2.GetButtonDown (Joycon.Button.SHOULDER_1)) {
				Debug.Log ("Rumble");

				j2.SetRumble (160, 320, 0.6f, 200);
                j2.Recenter ();
				
			}

           } 
                    gameObject.transform.localRotation = orientation;

                    player2.transform.localRotation = orientation2;

                    if (j.GetButton (Joycon.Button.SHOULDER_2))
                    {

                            nbDePoints.points -= prixParSeconde * Time.deltaTime;

                            audioSource.volume = 1;

                            crosshair.transform.Rotate(0, -5, 0, Space.Self);

                            spray.Play();



                        }

                         else{

                            audioSource.volume = 0;
                            spray.Stop();

                        }


           
            

                    RaycastHit hit;
                    // Does the ray intersect any objects excluding the player layer
                    if (Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity))
                    {
                        Debug.DrawRay(transform.position, fwd * hit.distance, Color.yellow);
                        

                        cible = hit.transform.gameObject;

                        scriptFantome = cible.GetComponent<fantomeBehavior>();

                        scriptBoss = cible.GetComponent<bossBehavior>();

                        scriptClones = cible.GetComponent<bossCloneBehavior>();

                        fantomeParticle = cible.GetComponent<ParticleSystem>();

                        if (j.GetButton (Joycon.Button.SHOULDER_2))
                        {
                            
                           if(cible.transform.tag == "fantome"){

                                scriptFantome.hp -= gunDmg * Time.deltaTime;


                                cible.layer = 0;

                                fantomeParticle.Play();

                            }

                           if(cible.transform.tag == "boss"){

                                if(scriptBoss.isInvincible == false){

                                scriptBoss.hp -= gunDmg * Time.deltaTime;

                                }

                                
                                fantomeParticle.Play();
                                

                            }

                            if(cible.transform.tag == "boss clones"){

                                

                                scriptClones.hp -= gunDmg * Time.deltaTime;

                                Debug.Log ("Gros big");

                                fantomeParticle.Play();

                            }
                        }

                       
                        
                    

                    }


                    
            
        }

        
    }
}
