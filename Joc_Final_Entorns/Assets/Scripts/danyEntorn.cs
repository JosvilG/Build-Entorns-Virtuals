using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danyEntorn : MonoBehaviour
{
    public int dany;

   
    void OnTriggerEnter(Collider other)
    {

        HUD.vida -= dany;
        
        
        
    }
}
