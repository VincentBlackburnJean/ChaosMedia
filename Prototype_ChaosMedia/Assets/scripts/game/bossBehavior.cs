using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
   //test

private GameObject[] joueur;

public float hp;

[SerializeField] private float baseHp = 100;

public float speed;


public score nbDePoints;


[SerializeField] private int primeParKill = 2500;


private GameObject[] Bosspath;

private int pointsIndex;

private int random;

private Animator anim;

private AudioSource audioSource;

public bool isBossFightActive = false;

[SerializeField] GameObject clones;




    // Start is called before the first frame update
    void Start()
    {
       Bosspath = GameObject.FindGameObjectsWithTag("path");

       hp = baseHp;
    

       pointsIndex = Random.Range(0,Bosspath.Length - 1);

       anim = GetComponent<Animator>();

       //joueur = GameObject.FindGameObjectsWithTag("target");

       
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (hp < 0){

            anim.SetTrigger("mort");

            if(!audioSource.isPlaying){

                audioSource.Play();

            }
            

        }

       

       // transform.LookAt(joueur[0].transform);
                                

       

       
    }

   public void BossFight(){

        if(isBossFightActive == true){

            

        }

    }



   
    }

