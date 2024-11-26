using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCloneBehavior : MonoBehaviour
{

    public float hp;

    [SerializeField] private float baseHp = 150;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        hp = baseHp;
    }

    // Update is called once per frame
    void Update()
    {
         if (hp < 0){

            

            if(!audioSource.isPlaying){

                audioSource.Play();

            }

            Invoke("Destroy", 2.0f);

         }


    }


    private void Destroy(){

        Destroy(gameObject);

    }
}
