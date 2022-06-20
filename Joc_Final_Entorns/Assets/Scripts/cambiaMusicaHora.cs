using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiaMusicaHora : MonoBehaviour
{
    public AudioClip musicaSona;
    public AudioSource audio;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.Stop();
            audio.GetComponent<AudioSource>();
            audio.clip = musicaSona;
            audio.Play();
            if (this.name == "triggerDia")
            {
                canviaEscena.nit = false;
            }

        }
    }
}
