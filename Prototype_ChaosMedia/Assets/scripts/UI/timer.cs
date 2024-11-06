using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class timer : MonoBehaviour
{

    [SerializeField] private lvlTimer chrono;
    public UnityEvent auChangementDuTemps;

    public UnityEvent aLaFinDuTemps;

     private bool decompteActif = false;

    // Start is called before the first frame update
    void Start()
    {
        DemarrerDecompte();
    }

    // Update is called once per frame
    void Update()
    {
        if(decompteActif == true)
        {
            if(chrono.temps > 0)
            {

                chrono.temps -= Time.deltaTime;

                auChangementDuTemps.Invoke();

            }

            else
            {

                chrono.temps = 0;

                decompteActif = false;

                aLaFinDuTemps.Invoke();

            }
        }
    }


    public void DemarrerDecompte()
    {

        chrono.temps = chrono.tempsInitial;
        decompteActif = true;

    }
}
