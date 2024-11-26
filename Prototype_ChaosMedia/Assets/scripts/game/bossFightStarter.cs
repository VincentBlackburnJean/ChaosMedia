using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFightStarter : MonoBehaviour
{

    [SerializeField] private bossBehavior scriptBoss; 

    [SerializeField] private fantomeSpawner scriptSpawnFantome; 

    public void StartBossFight(){

        scriptBoss.BeginFight();

        scriptSpawnFantome.blocked = true;

        for (int i = 0; i < scriptSpawnFantome.fantomes.Length; i++){

            Destroy(scriptSpawnFantome.fantomes[i]);

        }

    }
    
}
