using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantomeBehavior : MonoBehaviour
{

//test

private GameObject[] joueur;

public float hp;

[SerializeField] private float baseHp = 100;

public float speed;

[SerializeField] private float baseSpeed;

public score nbDePoints;

public bool estBlesse = false;

public float regen = 50;

[SerializeField] private int primeParKill = 500;


[Header("Pathing")]
[Space(10)]

private GameObject[] path;

private int pointsIndex;

private int random;

private Animator anim;

private AudioSource audioSource;




    // Start is called before the first frame update
    void Start()
    {
       path = GameObject.FindGameObjectsWithTag("path");

       hp = baseHp;
       speed = baseSpeed;

       pointsIndex = Random.Range(0,path.Length - 1);

       anim = GetComponent<Animator>();

       joueur = GameObject.FindGameObjectsWithTag("target");

       
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp > baseHp){

            estBlesse = false;
            hp = baseHp;
            speed = baseSpeed;


        }

        if (hp < 0){

            anim.SetTrigger("mort");

            if(!audioSource.isPlaying){

                audioSource.Play();

            }
            

        }

        if(hp < 100){

            hp += regen * Time.deltaTime;
            speed = 1;

        }

        else{

             speed = baseSpeed;

        }

       // transform.LookAt(joueur[0].transform);


       if(gameObject.layer == 0){

        foreach (Transform child in transform)
        {
             child.gameObject.layer = 0;
        }
                                

       }

        Pathing();
    }

    public void Pathing(){

        if(pointsIndex <= path.Length - 1){

            transform.position = Vector3.MoveTowards(transform.position, path[pointsIndex].transform.position, speed * Time.deltaTime);

            if(transform.position == path[pointsIndex].transform.position){

               pointsIndex= Random.Range(0,path.Length - 1);

               

            }

            if(pointsIndex == path.Length){

                pointsIndex = 0;

            } 

        }

    }



    public void Death(){

        Destroy(gameObject);   

        nbDePoints.points += primeParKill;   

    }
}
