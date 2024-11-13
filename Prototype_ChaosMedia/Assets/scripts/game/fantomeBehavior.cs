using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantomeBehavior : MonoBehaviour
{

//test

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






    // Start is called before the first frame update
    void Start()
    {
       path = GameObject.FindGameObjectsWithTag("path");

       hp = baseHp;
       speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp > baseHp){

            estBlesse = false;
            hp = 100;
            speed = baseSpeed;


        }

        if (hp < 0){

        Destroy(gameObject);   

        nbDePoints.points += primeParKill;         

        }

        else{

            estBlesse = true;

        }

        Pathing();
    }

    public void Pathing(){

        if(pointsIndex <= path.Length - 1){

            transform.position = Vector3.MoveTowards(transform.position, path[pointsIndex].transform.position, speed * Time.deltaTime);

            if(transform.position == path[pointsIndex].transform.position){

                pointsIndex++;

            }

            if(pointsIndex == path.Length){

                pointsIndex = 0;

            }

        }

    }

    public void Regen(){

        if(estBlesse == true){

            hp += regen * Time.deltaTime;
            speed = 1;

        }

        else{

            speed = baseSpeed;

        }


    }
}
