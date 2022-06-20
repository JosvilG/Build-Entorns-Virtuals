using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicioAlMon : ControlEscena // depen del script controlEscena
{
    public GameObject player;
    public static bool entra = false;
    public static bool surt = true;
    public static bool davant = true;
    public GameObject camara1;
    public GameObject camara11;
    public static Vector3 proximaPosicio;

    public static int vidaMax;//Determina la maxima vida total del personatge
    public static int vidaActual;//Determina la vida que te el personatge a la fase
    public static int fletxesMax;//Determina el numero maxim de fletxes que pot portar el personatge
    public static int fletxesActual;//Determina la quantitat de fletxes que te el personatge a la fase
    public static bool puzzleOrdre;
    public static bool portaClau1;
    public static bool portaClauFinal;
    public static bool puzzleBlocsAcabat;
    public GameObject porta1;
    public GameObject triggerEnemics1;
    public GameObject portaOrdre;
    public GameObject portaFinal;
    public bool interior;
    // Use this for initialization
    public override void Start()
    {
        base.Start();

        if (prevScene == "Entorns_ExteriorCastell" && entra == true)
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            player.SetActive(true);
            if (davant == true)
            {
                camara1.SetActive(true);
                camara11.SetActive(false);
            }
            if (davant == false)
            {
                camara1.SetActive(false);
                camara11.SetActive(true);
            }


            entra = false;
        }

        if (prevScene == "interior" && surt == true)
        {
            player.SetActive(false);
            player.transform.position = proximaPosicio;
            player.SetActive(true);
            surt = false;
        }
        if(interior == true)
        {
            if (portaClau1 == true)
            {
                porta1.SetActive(false);
                triggerEnemics1.SetActive(false);
                EnemicControler.contadorMorts = 2;

            }
            if (puzzleBlocsAcabat == true)
            {
                DesactivaPuzzle5.puzzleAcabat = true;
            }
            if (puzzleOrdre == true)
            {
                portaOrdre.SetActive(false);
            }
            if (portaClauFinal == true)
            {
                portaFinal.SetActive(false);
            }
        }
        

    }
}
