using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oleadas : MonoBehaviour
{
    public GameObject curaOleada1;
    public GameObject curaOleada2;
    public GameObject curaOleada3;

    public GameObject oleada1;
    public GameObject oleada2;
    public GameObject oleada3;
    public GameObject oleada4;

    public GameObject portaEntrada;
    public GameObject portaSortida;
    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player" && EnemicControler.contadorMorts == 2)
        {
            portaEntrada.SetActive(true);
            portaSortida.SetActive(true);
            oleada1.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (EnemicControler.contadorMorts == 5)//Activa oleada2
        {
            if (curaOleada1 != null)
            {
                curaOleada1.SetActive(true);
            }
            StartCoroutine(EntreOleades(oleada2));
        }
        if (EnemicControler.contadorMorts == 7)//Activa oleada3
        {
            if (curaOleada2 != null)
            {
                curaOleada2.SetActive(true);
            }
            StartCoroutine(EntreOleades(oleada3));
        }
        if (EnemicControler.contadorMorts == 12)//Activa oleada4
        {
            if (curaOleada3 != null)
            {
                curaOleada3.SetActive(true);
            }
            StartCoroutine(EntreOleades(oleada4));
        }

        if (EnemicControler.contadorMorts == 13)//Acaba
        {
            Destroy(portaEntrada.gameObject);
            Destroy(portaSortida.gameObject);
            EnemicControler.contadorMorts = 0;
        }
    }

    IEnumerator EntreOleades(GameObject oleada)
    {
        
        yield return new WaitForSeconds(4);
        oleada.SetActive(true);
    }
}
