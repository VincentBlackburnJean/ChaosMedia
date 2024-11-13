using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuStart : MonoBehaviour
{
    public score nbDePoints;
   

    public void StartGame(){

        nbDePoints.points = 1000;
        SceneManager.LoadScene(1);
        
    }

    public void EndGame(){

        SceneManager.LoadScene(2);

    }
    public void RestartGame(){

        SceneManager.LoadScene(0);

    }
}
