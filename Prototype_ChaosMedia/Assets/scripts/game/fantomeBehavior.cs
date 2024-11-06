using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantomeBehavior : MonoBehaviour
{



public float hp = 100;

public float speed = 5;

public score nbDePoints;

[SerializeField] private int primeParKill = 500;


[Header("Pathing")]
[Space(10)]

private GameObject[] path;

private int pointsIndex;




    // Start is called before the first frame update
    void Start()
    {
       path = GameObject.FindGameObjectsWithTag("path");
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0){

        Destroy(gameObject);   

        nbDePoints.points += primeParKill;         

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

   
}
