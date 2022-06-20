using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemics : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject enemic;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnPoint.position = new Vector3(11.1f,1.6f,96.8f);
        //Destroy(GameObject.FindWithTag("pilota"));
        
        Instantiate(enemic, SpawnPoint.position, SpawnPoint.rotation);
        SpawnPoint.position += new Vector3(5,0,0);
        Instantiate(enemic, SpawnPoint.position, SpawnPoint.rotation);
        //Instantiate(enemic, SpawnPoint.position, SpawnPoint.rotation);

    }
}
