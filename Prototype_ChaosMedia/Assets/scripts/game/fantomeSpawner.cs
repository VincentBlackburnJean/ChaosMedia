using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantomeSpawner : MonoBehaviour
{

    public GameObject[] prefabs;

    public Transform conteneur;

    private GameObject[] path;

    private float random;

    private Vector3 positionInitiale;

    private Vector3 rotationInitiale = new Vector3(0, 180, 0);

    private Quaternion rotation;

    private GameObject[] fantomes;

    

    void Start()
    {
        rotation.eulerAngles = rotationInitiale;

       

        InvokeRepeating("SpawnFantome", 0.5f, 2f);
    }


    public void SpawnFantome(){

        if(fantomes.Length < 3){

            path = GameObject.FindGameObjectsWithTag("path");

            random = Random.Range(0,path.Length - 1);
            positionInitiale =  path[(int)random].transform.position;
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], positionInitiale, rotation, conteneur);
            Debug.Log("Wassup");


        }

        


    }

    void Update()
    {
        fantomes = GameObject.FindGameObjectsWithTag("fantome");
    }
}
