using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivaPuzzle5 : MonoBehaviour
{
    public GameObject Blaus;
    public GameObject Vermells;
    public static bool puzzleAcabat = false;
    public static bool vermells = true;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            puzzleAcabat = true;
        }

    }

    void Update()
    {
        if (puzzleAcabat == true)
        {
            posicioAlMon.puzzleBlocsAcabat = true;
            Blaus.SetActive(false);
            Vermells.SetActive(false);
        }
    }
}
