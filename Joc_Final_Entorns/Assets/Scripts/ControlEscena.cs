using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEscena : MonoBehaviour
{
    public static string prevScene = "";
    public static string currentScene = "";

    public virtual void Start()//al ser virtual permet que els scripts que accedeixen a ell el puguin modificar
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string sceneName)
    {
        prevScene = currentScene;
        EnemicControler.minimMorts = 100000;
        EnemicControler.contadorMorts = 0;
        ActivaSpawn.obrir = false;
        SceneManager.LoadScene(sceneName);
    }

    public void Update()
    {
        //Debug.Log(ActivaSpawn.obrir+" - "+EnemicControler.minimMorts + " <= "+EnemicControler.contadorMorts);
        //Debug.Log("Col. restants: "+posicioAlMon.collecionablesBosc);
        determinaValors();
    }

    public void determinaValors()//Posa en ordre totes les dades necesaries al saltar de escena
    {
        posicioAlMon.vidaMax = HUD.maxVida;
        posicioAlMon.vidaActual = HUD.vida;
        posicioAlMon.fletxesMax = HUD.maxFletxes;
        posicioAlMon.fletxesActual = HUD.numFletxes;
        //Debug.Log("Vida max: " + posicioAlMon.vidaMax);
        //Debug.Log("Vida actual: " + posicioAlMon.vidaActual);
    }

}
