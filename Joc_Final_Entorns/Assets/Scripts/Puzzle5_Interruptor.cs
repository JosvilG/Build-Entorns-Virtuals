using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5_Interruptor : MonoBehaviour
{
    public static bool pz4 = false;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            pz4 = true;
        }
    }
}
