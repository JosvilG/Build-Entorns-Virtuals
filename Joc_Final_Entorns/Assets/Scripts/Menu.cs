using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Transform menuPause;
    public Transform Opciones;

    bool IsEnabled = false;
    bool IsEnabledOpciones = false;

    
    private void Start()
    {
        menuPause.GetComponent<Canvas>().enabled = false;
        Opciones.GetComponent<Canvas>().enabled = false;
        
        
    }
    public void Salir()
    {
        Application.Quit(); 
        Debug.Log("Se ha salido del juego");
    }

    public void CargaOpcion(string pNombreEscena)
    {
        SceneManager.LoadScene(pNombreEscena);
    }

    public void MuestraMenu()
    {
       if (!IsEnabled)
        {
            Debug.Log("mostrar");
            menuPause.GetComponent<Canvas>().enabled = true;
            IsEnabled = true;
        }
    }
    
    public void OcultaMenu() //se pulsa CONTINUE 
    {
        if (IsEnabled)
        {
            Debug.Log("ocultar");
            menuPause.GetComponent<Canvas>().enabled = false;
            IsEnabled = false;
        }   
    }
    
    public void MuestraOpciones() //se pulsa OPTIONS
    {
       if (!IsEnabledOpciones)
        {
            Debug.Log("mostrar opciones");
            Opciones.GetComponent<Canvas>().enabled = true;
            IsEnabledOpciones = true;
        }
    }
    
    public void OcultaOpciones() //se pulsa BACK
    {
        if (IsEnabledOpciones)
        {
            Debug.Log("ocultar opciones");
            Opciones.GetComponent<Canvas>().enabled = false;
            IsEnabledOpciones = false;
        }   
    }
}
