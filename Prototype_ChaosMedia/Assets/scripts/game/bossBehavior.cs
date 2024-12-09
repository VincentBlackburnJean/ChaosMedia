using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
   //test

private GameObject[] joueur;

public float hp;

[SerializeField] private float baseHp = 150;

public float speed;


public score nbDePoints;


[SerializeField] private int primeParKill = 2500;


private GameObject[] bosspath;

private int pointsIndex;

private int random;

private Animator anim;

private AudioSource audioSource;

//public bool isBossFightActive = false;

[SerializeField] GameObject clones;

public int realSpot;

private GameObject[] listeDeClones;

private int lives = 3;

public bool isInvincible = true;

public menuStart sceneManager;

[SerializeField] private AudioClip rire;
[SerializeField] private AudioClip mort;
[SerializeField] private AudioClip hurt;


    // Start is called before the first frame update
    void Start()
    {
       bosspath = GameObject.FindGameObjectsWithTag("boss path");

      

       hp = baseHp;
    

       pointsIndex = Random.Range(0,bosspath.Length - 1);

       anim = GetComponent<Animator>();

       //joueur = GameObject.FindGameObjectsWithTag("target");

       
        audioSource = GetComponent<AudioSource>();

       

    
    }

    // Update is called once per frame
    void Update()
    {
       
         listeDeClones = GameObject.FindGameObjectsWithTag("boss clones");

        if (hp < 0){

            anim.SetTrigger("hurt");

         // if(!audioSource.isPlaying){

                audioSource.clip = hurt;

                PlayAudio();

          //  }
            
            lives--;

            isInvincible = true;

            hp = baseHp;



        }

        

       

       // transform.LookAt(joueur[0].transform);
                                

       

       
    }


    public void BeginFight(){

        for (int i = 0; i < listeDeClones.Length; i++){

            Destroy(listeDeClones[i]);

        }



        if(lives <= 0){

            anim.SetTrigger("dead");

           audioSource.clip = mort;

           PlayAudio() ;

        }


        else{

            anim.SetTrigger("roar");

            audioSource.clip = rire;

            PlayAudio();       

        }
           

           


    }

   public void BossFight(){


           if(lives > 0){


             isInvincible = false;

            realSpot = Random.Range(0,bosspath.Length - 1);

            transform.position = bosspath[realSpot].transform.position;

            for(int i = 0; i < bosspath.Length; i++){
                if(i == realSpot) continue;


                Instantiate(clones, bosspath[i].transform.position, bosspath[i].transform.rotation);



            } 



           }


    }

    public void Dead(){

        Destroy(gameObject);   

        nbDePoints.points += primeParKill;   

        sceneManager.EndGame();



    }

    public void PlayAudio(){


         if (audioSource.isPlaying)
    {
        audioSource.Stop(); // Stop any ongoing audio playback
    }

        audioSource.Play();
         Debug.Log("Playing AudioClip: " + audioSource.clip.name);

    }



   
    }

