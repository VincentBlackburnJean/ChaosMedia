using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class affichageScoreFin : MonoBehaviour
{

    [SerializeField] private TMP_Text champTextePoints;

    [SerializeField] private score points;

    // Start is called before the first frame update
    void Start()
    {
        champTextePoints.text = points.points + "$";
    }

    
}
