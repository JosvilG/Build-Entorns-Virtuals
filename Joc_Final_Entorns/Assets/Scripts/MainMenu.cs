using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Entorns_ExteriorCastell");
        posicioAlMon.entra = false;
        posicioAlMon.davant = false;
        posicioAlMon.surt = false;
        AttackControl.getEspasa = true;
        AttackControl.getBumerang = true;
        AttackControl.getArc = true;
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");

        Application.Quit();
    }

}
