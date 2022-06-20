using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canviaEscena : MonoBehaviour
{
    [SerializeField] private string seguentEscena;
    private ControlEscena sceneController;
    public GameObject player;
    public GameObject pos;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject posRespawn;
    public static bool darrera = false;
    public static bool nit = false;

    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControlEscena>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        /**********************************IGNORAR AIXO***********************************/

        if (collision.CompareTag("Player") && this.name == "portaExterior1") // Entrar al castell pel davant
        {
            sceneController.LoadScene(seguentEscena);//-136.8, 1.4, 141.5
            posicioAlMon.proximaPosicio = pos1.transform.position;
            posicioAlMon.entra = true;
            posicioAlMon.davant = true;
            posicioAlMon.surt = false;
            HUD.numClaus = 0;
            EnemicControler.contadorMorts=0;
        }

        if (collision.CompareTag("Player") && this.name == "portaExterior2") // Entrar al castell pel darrera
        {
            sceneController.LoadScene(seguentEscena);//-133.2, 1.4, 266.2
            posicioAlMon.proximaPosicio = pos2.transform.position;
            posicioAlMon.entra = true;
            posicioAlMon.davant = false;
            posicioAlMon.surt = false;
            HUD.numClaus = 0;
            EnemicControler.contadorMorts = 0;
        }

        if (collision.CompareTag("Player") && this.name== "portaInterior1")//Sortida al exterior per davant el castell
        {
            sceneController.LoadScene(seguentEscena);//509.62, 38.33, 364.91
            posicioAlMon.proximaPosicio = pos1.transform.position;
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
            HUD.numClaus = 0;
            EnemicControler.contadorMorts = 0;
        }
        
        if (collision.CompareTag("Player") && this.name == "portaInterior2") // Sortir al exterior pel darrera del castell
        {
            sceneController.LoadScene(seguentEscena);//654.21, 42.6, 422.36
            posicioAlMon.proximaPosicio = pos2.transform.position;
            posicioAlMon.entra = false;
            posicioAlMon.davant = false;
            posicioAlMon.surt = true;
            HUD.numClaus = 0;
            EnemicControler.contadorMorts = 0;
            nit = true;
        }
        
    }

    void Update()
    {
        if(darrera == true)
        {
            CargarDarreraCastell();
        }
    }

    void CargarDarreraCastell()//En cas de que moris al sortir del castell
    {
        Debug.Log("hola");
        sceneController.LoadScene(seguentEscena);//654.21, 42.6, 422.36
        posicioAlMon.proximaPosicio = posRespawn.transform.position;
        posicioAlMon.entra = false;
        posicioAlMon.davant = false;
        posicioAlMon.surt = true;
        HUD.numClaus = 0;
        EnemicControler.contadorMorts = 0;
        darrera = false;
    }
}
