using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorColisions : MonoBehaviour
{
    public GameObject camaraNormal;
    public GameObject camaraBaixa;
    public GameObject camaraMuntanya;
    public GameObject camaraEntraBosc;
    public GameObject camara1;
    public GameObject camara2;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
     
    }

    void OnTriggerEnter(Collider other)
    {
        
        
        if(this.name == "triggerCamaraNormal" && other.tag == "Player")//activa el primer enemic si pot
        {
            camaraNormal.SetActive(true);
            camaraMuntanya.SetActive(false);
        }
        if (this.name == "triggerCamaraMuntanya" && other.tag == "Player")//activa el primer enemic si pot
        {
            camaraNormal.SetActive(false);
            camaraMuntanya.SetActive(true);
            camaraBaixa.SetActive(false);
        }

        if (this.name == "triggerCamaraBaixaMuntanya" && other.tag == "Player")//activa el primer enemic si pot
        {
            camaraNormal.SetActive(false);
            camaraMuntanya.SetActive(false);
            camaraBaixa.SetActive(true);
            camaraEntraBosc.SetActive(false);
        }
        if (this.name == "triggerCamaraEntraBosc" && other.tag == "Player")//activa el primer enemic si pot
        {
            camaraNormal.SetActive(false);
            camaraMuntanya.SetActive(false);
            camaraBaixa.SetActive(false);
            camaraEntraBosc.SetActive(true);
        }

        if (this.name == "triggerCamaraEntra" && other.tag == "Player")//camara1 = proxima camara
        {
            camara1.SetActive(true);
            camara2.SetActive(false);
        }

        if (this.name == "triggerCamaraSurt" && other.tag == "Player")//camara2 = proxima camara
        {
            camara1.SetActive(false);
            camara2.SetActive(true);

        }

    }
    
}
