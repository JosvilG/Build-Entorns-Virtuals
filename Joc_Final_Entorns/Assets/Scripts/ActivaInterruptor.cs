using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaInterruptor : MonoBehaviour
{
    public GameObject clauFinal;
    private bool comprovacio = false;
    public GameObject camaraEscena;
    public GameObject camaraNormal;
    public GameObject porta;
    bool obrirPorta;
    bool moures = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obrirPorta == true)
        {
            StartCoroutine(Obrir());
            porta.gameObject.transform.position -= new Vector3(0, 0.2f, 0);
        }
        if(this.name== "interruptor")
        {

            //StartCoroutine(MouDreta());
            //StartCoroutine(MouEsq());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Arma" && comprovacio==false && this.name!= "interruptor1")
        {
            clauFinal.SetActive(true);
            comprovacio = true;//perque no salti missatge d'error
        }

        if (other.collider.tag == "Arma" && this.name=="interruptor1" && obrirPorta==false)
        {
            StartCoroutine(Obrir());
            camaraEscena.SetActive(true);
            camaraNormal.SetActive(false);
            
        }
    }

    IEnumerator MouDreta()
    {
            this.gameObject.transform.position -= new Vector3(0.5f, 0, 0);
            yield return new WaitForSeconds(1);
         
    }
    IEnumerator MouEsq()
    {
        
            this.gameObject.transform.position += new Vector3(0.5f, 0, 0);
            yield return new WaitForSeconds(1);
        
    }

    IEnumerator Obrir()
    {
        if (obrirPorta == false)
        {
            yield return new WaitForSeconds(2);
            obrirPorta = true;
        }
        if (obrirPorta == true)
        {
            yield return new WaitForSeconds(2);
            camaraEscena.SetActive(false);
            camaraNormal.SetActive(true);
        }

    }
}
