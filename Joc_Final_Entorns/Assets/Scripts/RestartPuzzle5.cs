using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPuzzle5 : MonoBehaviour
{
    public GameObject Cub;
    public Transform Respawn;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cub.transform.position = Respawn.position;
        }
        
    }
}
