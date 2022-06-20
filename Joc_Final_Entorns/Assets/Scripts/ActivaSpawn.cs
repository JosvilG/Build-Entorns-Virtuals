using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaSpawn : MonoBehaviour
{
    public bool actiu = false;
    public GameObject spawn;
    public GameObject porta;
    public GameObject porta2;
    public static bool obrir = false;
    public GameObject camaraNormal;
    public GameObject camaraCombat;
    public GameObject camaraNormalEscena;
    public GameObject camaraEscena;
    public GameObject arc;
    public int morts;
    public static bool potArc=false;
    public bool potEscena;
    public static bool activa = false;
    public GameObject player;
    private int num = 0;
    
    void Update()
    {
        
        if (obrir == true && activa==false)
        {
            EnemyAI.potSeguir = false;
            porta.SetActive(false);
            porta2.SetActive(false);
            camaraNormal.SetActive(true);
            camaraCombat.SetActive(false);
            if (this.name == "combatVolca" && potArc==true)
            {
                arc.SetActive(true);
            }
        }
        Debug.Log("Portes: " + EnemicControler.contadorMorts + " --- de: " + EnemicControler.minimMorts);
       
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (num == 0)
        {
            obrir = false;
        }
        if(EnemicControler.contadorMorts == morts)
        {

        }
        else
        {
            if (this.name == "combatVolca" && potEscena == true && other.tag == "Player")
            {
                num++;
                StartCoroutine(CombatEscena(4.0f));

            }
            else
            {
                num++;
                EnemyAI.potSeguir = true;
                porta.SetActive(true);
                porta2.SetActive(true);
                spawn.SetActive(true);
                EnemicControler.minimMorts = morts;
            }
            
        }
        
        

    }

    void escenaCamara()
    {
        activa = true;
        StartCoroutine(Escena());
    }

    private IEnumerator CombatEscena(float f)
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<AttackControl>().enabled = false;
        EnemyAI.potSeguir = false;
        camaraNormal.SetActive(false);
        camaraEscena.SetActive(true);
        yield return new WaitForSeconds(f);
        camaraEscena.SetActive(false);
        camaraNormalEscena.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<AttackControl>().enabled = true;
        EnemyAI.potSeguir = true;
        potEscena = false;
        activa = false;
        
        potArc = true;
        StopCoroutine(Escena());
    }

    private IEnumerator Escena()
    {
        player.GetComponent<CharacterController>().enabled = false;
        camaraNormal.SetActive(false);
        camaraEscena.SetActive(true);
        camaraNormalEscena.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        camaraEscena.SetActive(false);
        camaraNormalEscena.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
        potEscena = false;
        activa = false;
        StopCoroutine(Escena());
    }
}
