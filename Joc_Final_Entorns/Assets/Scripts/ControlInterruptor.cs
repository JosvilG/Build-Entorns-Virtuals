using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInterruptor : MonoBehaviour
{
    public GameObject Blaus;
    public GameObject Vermells;
    public GameObject intVermell;
    public GameObject intBlau;
    bool potTornar = true;
    public AudioClip obrirPorta;
    public AudioSource audio;
    public float volume;

    void Start()
    {
        if (DesactivaPuzzle5.vermells == true)
        {
            Blaus.SetActive(false);
            Vermells.SetActive(true);
            intVermell.SetActive(true);
            intBlau.SetActive(false);
        }
        else if(DesactivaPuzzle5.vermells == false)
        {
            Blaus.SetActive(true);
            Vermells.SetActive(false);
            intVermell.SetActive(false);
            intBlau.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && DesactivaPuzzle5.vermells == true && potTornar == true && DesactivaPuzzle5.puzzleAcabat == false)//Activa blaus
        {
            //Activa blocs
            Blaus.SetActive(true);
            Vermells.SetActive(false);
            ///Activa interruptor color
            intVermell.SetActive(false);
            intBlau.SetActive(true);

            DesactivaPuzzle5.vermells = false;
            potTornar = false;
            sona();
            StartCoroutine(EsperaProximCop());
            
        }
        else if (collision.gameObject.CompareTag("Player") && DesactivaPuzzle5.vermells == false && potTornar == true && DesactivaPuzzle5.puzzleAcabat == false)//Activa vermells
        {
            //Activa blocs
            Blaus.SetActive(false);
            Vermells.SetActive(true);
            ///Activa interruptor color
            intVermell.SetActive(true);
            intBlau.SetActive(false);

            DesactivaPuzzle5.vermells = true;
            potTornar = false;
            sona();
            StartCoroutine(EsperaProximCop());
        }

    }

    void Update()
    {
        if (DesactivaPuzzle5.vermells == true)
        {
            intVermell.SetActive(true);
            intBlau.SetActive(false);
        }
        else if (DesactivaPuzzle5.vermells == false)
        {
            intVermell.SetActive(false);
            intBlau.SetActive(true);
        }
    }

    void sona()
    {
        audio.PlayOneShot(obrirPorta, volume);
    }


    IEnumerator EsperaProximCop()
    {

        yield return new WaitForSeconds(1);
        potTornar = true;
    }
}
