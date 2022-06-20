using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgafaClau : MonoBehaviour
{
    private bool agafa = true;
    private bool clau = true;
    public AudioClip agafada;
    public AudioSource audio;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        clau = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(clau == true)
        {
            for (int i = 0; i < 15; i++)
            {
                this.transform.Translate(Vector3.down * Time.deltaTime);
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Limit")
        {
            clau = false;
        }
        if (this.name == "clau1" && other.tag == "Player" && agafa==true)
        {
            HUD.numClaus += 1;
            agafa = false;
            Destroy(this.gameObject);
            agafa = true;
            soAgafar();
            if (HUD.numClaus > 1)
            {
                HUD.numClaus = 1;
            }
        }
        if (this.name == "clauFinal" && other.tag == "Player" && agafa == true)
        {
            HUD.numClaus += 1;
            agafa = false;
            Destroy(this.gameObject);
            agafa = true;
            soAgafar();
            if (HUD.numClaus > 1)
            {
                HUD.numClaus = 1;
            }
        }
        
    }

    void soAgafar()
    {

        audio.PlayOneShot(agafada, volume);

    }
}
