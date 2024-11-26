using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AffichageInfos : MonoBehaviour
{
   
    [SerializeField] private lvlTimer chrono;

    [SerializeField] private score points;

    private int nbDePoints;


    [SerializeField] private TMP_Text champTexteTemps;
    [SerializeField] private TMP_Text champTextePoints;


    void Start(){

         points.points = points.pointsInitiaux;

    }


    public void AfficherTemps()
     {

        float temps = chrono.temps;

        if(temps < 0) temps = 0;
        
        TimeSpan ts = TimeSpan.FromSeconds(temps);

        champTexteTemps.text = string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

     }



    // Update is called once per frame
    void Update()
    {

        nbDePoints = (int)points.points;
        
        champTextePoints.text = nbDePoints + "$";


    }
}
