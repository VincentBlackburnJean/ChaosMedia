using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantomeBehavior : MonoBehaviour
{



public float hp = 100;

public float speed = 1;

public score nbDePoints;

[SerializeField] private int primeParKill = 500;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0){

        Destroy(gameObject);   

        nbDePoints.points += primeParKill;         

        }
    }
}
