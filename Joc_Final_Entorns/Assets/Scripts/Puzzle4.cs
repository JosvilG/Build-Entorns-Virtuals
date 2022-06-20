using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Puzzle4 : MonoBehaviour
{
    public GameObject player;
    public GameObject porta;
    public GameObject[] cubo;
    public bool[] pisado;
    public Light[] llum;
    public AudioClip soCorrecte;
    public AudioClip soError;
    public AudioSource audio;
    public float volume;
    bool potSonar = false;
    int contador = 0;
    public Light groc;
    public Light turquesa;
    public Light blau;
    public Light vermell;
    public Light blanc;


    public void Start()
    {
        audio = GetComponent<AudioSource>();
        for (int i = 0; i <= llum.Length - 1; i++)
        {
            llum[i].GetComponent<Light>();
            llum[i].intensity = 0;
        }

    }
    public void aversifunciona(Collider other, string nombre)
    {

        if (Puzzle5_Interruptor.pz4 != false)
        {
            if (nombre == "BaldosaG" && other.tag == "Player")
            {
                pisado[0] = true;
            }
            if (nombre == "BaldosaB" && other.tag == "Player")
            {
                pisado[1] = true;
            }
            if (nombre == "BaldosaBF" && other.tag == "Player")
            {
                pisado[2] = true;
            }
            if (nombre == "BaldosaR" && other.tag == "Player")
            {
                pisado[3] = true;
            }
            if (nombre == "BaldosaF" && other.tag == "Player")
            {
                pisado[4] = true;
            }
        }
        else { }
    }
    void reinicio()
    {
        for (int i = 0; i <= pisado.Length - 1; i++)
        {
            pisado[i] = false;
        }
        SonaError();
    }
    void comprobacion()
    {
        if (pisado[1] == true && pisado[0] == false)
        {
            reinicio();
        }
        if (pisado[2] == true && pisado[0] == false && pisado[1] == false || pisado[2] == true && pisado[0] == true && pisado[1] == false)
        {
            reinicio();
        }
        if (pisado[3] == true && pisado[0] == false && pisado[1] == false && pisado[2] == false || pisado[3] == true && pisado[0] == true && pisado[1] == false && pisado[2] == false || pisado[3] == true && pisado[0] == true && pisado[1] == true && pisado[2] == false)
        {
            reinicio();
        }
        if (pisado[4] == true && pisado[0] == false && pisado[1] == false && pisado[2] == false && pisado[3] == false || pisado[4] == true && pisado[0] == true && pisado[1] == false && pisado[2] == false && pisado[3] == false || pisado[4] == true && pisado[0] == true && pisado[1] == true && pisado[2] == false && pisado[3] == false || pisado[4] == true && pisado[0] == true && pisado[1] == true && pisado[2] == true && pisado[3] == false)
        {
            reinicio();
        }
    }
    private void Update()
    {
        if (Puzzle5_Interruptor.pz4 == true)
        {
            comprobacion();
            activabaldosa();
            controllums();
            SonaCorrecte();
        }
        else { }
    }
    public void activabaldosa()
    {
        if (Puzzle5_Interruptor.pz4 == true)
        {
            if (pisado[0] == true)
            {
                if (contador == 0)
                {
                    potSonar = true;
                    groc.intensity = 1;
                }
                
                pisado[0] = true;
                if (pisado[1] == true)
                {
                    if (contador == 1)
                    {
                        potSonar = true;
                        turquesa.intensity = 1;
                    }
                    pisado[1] = true;
                    if (pisado[2] == true)
                    {
                        if (contador == 2)
                        {
                            potSonar = true;
                            blau.intensity = 1;
                        }
                        pisado[2] = true;
                        if (pisado[3] == true)
                        {
                            if (contador == 3)
                            {
                                potSonar = true;
                                vermell.intensity = 1;
                            }
                            pisado[3] = true;
                            if (pisado[4] == true)
                            {
                                if (contador == 4)
                                {
                                    potSonar = true;
                                    blanc.intensity = 1;
                                }
                                pisado[4] = true;
                                posicioAlMon.puzzleOrdre = true;
                                Destroy(porta.gameObject);
                            }
                        }
                    }

                }
            }
        }
        else { }
    }
    public void controllums()
    {
        for (int i = 0; i <= pisado.Length - 1; i++)
        {
            if (pisado[i] == true && Puzzle5_Interruptor.pz4 == true)
            {
                llum[i].intensity = 10;
            }
            if (pisado[i] == false)
            {
                llum[i].intensity = 0;
            }
        }
    }

    void SonaCorrecte()
    {
        if (potSonar)
        {
            audio.PlayOneShot(soCorrecte,volume);
            potSonar = false;
            contador++;
        }
        
    }

    void SonaError()
    {
            audio.PlayOneShot(soError, volume);
            potSonar = false;
            contador=0;

    }
}