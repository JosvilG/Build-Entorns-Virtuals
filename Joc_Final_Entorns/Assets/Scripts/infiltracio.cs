using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infiltracio : MonoBehaviour
{
    //public GameObject player;
    public Transform punt1;
    public Transform punt2;
    public float speed;
    public bool posicio1;
    public bool posicio2;
    private float t;
    public float duration = 1;
    public float lerpValue = 0;
    bool potTornar = true;
    public int segonsEspera;
    public GameObject player;
    public GameObject alerta;
    public Transform posicioRespawn;
    public AudioClip soAlerta;
    public AudioSource audio;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Mou());
    }

    // Update is called once per frame
    void Update()
    {
        duration++;
        if (potTornar == true)
        {
            Mou();
        }

        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && comprovaAmagat.amagat==false)
        {
            Debug.Log("Trobat");
            alerta.transform.position = player.transform.position + new Vector3(0,2,0);
            alerta.SetActive(true);
            StartCoroutine(Enganxat());
        }
        if (collision.gameObject.name == "Point1")
        {
            posicio2 = true;
            posicio1 = false;
            potTornar = false;
            StartCoroutine(Espera());
        }
        else if (collision.gameObject.name == "Point2")
        {
            posicio2 = false;
            posicio1 = true;
            potTornar = false;
            StartCoroutine(Espera());
        }

    }

    private void Localitzacio()
    {
        if (potTornar)
        {
            lerpValue += Time.deltaTime / speed;
            if (posicio1)
            {
                transform.position = Vector3.Lerp(this.transform.position, punt1.position, lerpValue);
            }
            else if (posicio2)
            {
                transform.position = Vector3.Lerp(this.transform.position, punt2.position, lerpValue);
            }
            lerpValue = 0;
        }
        
    }

    IEnumerator Mou()
    {
        duration = 4;

        for (t = 0; t < duration; t += Time.deltaTime)
        {
            Localitzacio();
            yield return null;
        }
        

    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(segonsEspera);
        potTornar = true;

    }

    IEnumerator Enganxat()
    {
        audio.PlayOneShot(soAlerta, volume);
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<PlayerControl>().enabled = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        yield return new WaitForSeconds(2f);
        alerta.SetActive(false);
        player.SetActive(false);
        player.transform.position = posicioRespawn.position;
        player.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<PlayerControl>().enabled = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
        HUD.vida -= 10;
    }
}
