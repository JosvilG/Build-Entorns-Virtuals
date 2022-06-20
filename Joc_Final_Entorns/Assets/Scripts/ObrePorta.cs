using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObrePorta : MonoBehaviour
{
    public GameObject porta;
    private bool obrir = true;
    public AudioClip obrirPorta;
    public AudioSource audio;
    public float volume;
    public bool porta1;
    public bool porta2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* void OnCollisionEnter(Collision other)
    {
        Debug.Log("Fa falta una clau");
        if (other.collider.tag == "Player" && HUD.numClaus >= 1)
        {
            HUD.numClaus--;
            Destroy(this.gameObject);

        }
        if (other.collider.tag == "Player" && HUD.numClaus < 1)
        {
            Debug.Log("Fa falta una clau");
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && HUD.numClaus >= 1 && obrir==true)
        {
            if (porta1 == true)
            {
                posicioAlMon.portaClau1 = true;
            }
            if(porta2 == true)
            {
                posicioAlMon.portaClauFinal = true;
            }
            HUD.numClaus-=1;
            obrir = false;
            obre();
            Destroy(porta.gameObject);
        }
       
        
            
    }

    void obre()
    {
            audio.PlayOneShot(obrirPorta, volume);
    }


}
