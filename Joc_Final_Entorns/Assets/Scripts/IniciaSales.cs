using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciaSales : MonoBehaviour
{
    public GameObject spawnerSala2;
    public GameObject clau1;
    public GameObject porta;
    bool clau = true;

    public static int contadorMorts = 0;

    public void Update()
    {
        
        if (EnemicControler.contadorMorts >= 2 && clau==true)
        {
            clau1.SetActive(true);
            clau = false;
        }
        /*if (EnemicControler.contadorMorts >= 5)
        {
            Destroy(porta.gameObject);
            EnemicControler.contadorMorts = 0;
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
 
        if (this.name== "TriggerActivaEnemics" && other.tag == "Player")
        {
            spawnerSala2.SetActive(true);
        }

    }

   
}
