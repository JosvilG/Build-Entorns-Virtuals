using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amagat : MonoBehaviour
{
    public AudioClip moureHerbes;
    public AudioSource audio;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && comprovaAmagat.amagat == false)
        {
            audio.PlayOneShot(moureHerbes, volume);
            comprovaAmagat.amagat = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && comprovaAmagat.amagat == true)
        {
            comprovaAmagat.amagat = false;
        }
    }
}
