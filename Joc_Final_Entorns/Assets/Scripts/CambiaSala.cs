using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiaSala : MonoBehaviour
{
    public GameObject camara1;//camara de la sala actual
    public GameObject camara2;//camara de la seguent sala
    public GameObject player;
    public bool activarCollider = false;
    public GameObject espasa;
    public GameObject col;
   

    void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("TriggerSurt") && other.tag == "Player" && camara2.activeSelf == true)//Aixo passa quan es surt de la sala
        {
            /*if (!activarCollider)
            {
                Debug.Log("aaa");
                col.GetComponent<BoxCollider>().enabled = false;
                espasa.SetActive(true);
            }*/
            
            //Activa la camara de la sala seguent i desactiva la actual
            camara1.SetActive(true);
            camara2.SetActive(false);
            EnemyAI.potSeguir = false;
            StartCoroutine(DisableScript());
        }
        if (this.CompareTag("TriggerEntra") && other.tag == "Player" && camara1.activeSelf == true)//Aixo passa quan entres a la sala
        {

            /*if (activarCollider)
            {
                Debug.Log("bbbb");
                col.GetComponent<BoxCollider>().enabled = true;
                espasa.SetActive(false);
            }*/
            EnemyAI.potSeguir = false;
            camara1.SetActive(false);
            camara2.SetActive(true);
            StartCoroutine(DisableScript());
            

        }
        if(this.name== "TriggerActivaCol" && other.tag == "Player")
        {
            if (activarCollider)
            {
                col.GetComponent<BoxCollider>().enabled = true;
            }
        }
        if (this.name == "TriggerDesactivaCol" && other.tag == "Player")
        {
            if (!activarCollider)
            {
                col.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    IEnumerator DisableScript()//Fa esperar 2 segons al jugador perque la camara es pugui reposicionar
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerControl>().enabled = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        yield return new WaitForSeconds(2f);
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<PlayerControl>().enabled = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
        EnemyAI.potSeguir = true;
        //player.SetActive(true);
    }

    void Update()
    {
        if (col == null)
        {
            //Debug.Log("aaa");
        }
        /*else if (!activarCollider)
        {
            col.GetComponent<BoxCollider>().enabled = false;
            //this.GetComponent<SphereCollider>().enabled = false;
        }
        else if (activarCollider)
        {
            col.GetComponent<BoxCollider>().enabled = true;
            //col.SetActive(true);
        }*/
        

    }
}
