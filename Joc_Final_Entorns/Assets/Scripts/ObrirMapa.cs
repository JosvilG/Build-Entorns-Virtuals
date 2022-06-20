using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObrirMapa : MonoBehaviour
{
    
    public GameObject mapa;
    public GameObject player;
    public GameObject camaraSobrePlayer;
    bool obre;
    // Start is called before the first frame update
    void Start()
    {
        obre = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.M) && obre == true)//Si el mapa esta obert el tanca
        {
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<PlayerControl>().enabled = true;
            
            DesactivaMapa();
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
            //camara.SetActive(false);

        }
        else if (Input.GetKeyDown(KeyCode.M) && obre == false)//Si el mapa no esta obert el obre
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<PlayerControl>().enabled = false;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            //camara.SetActive(true);
            /* mapa.SetActive(false);
             camaraSobrePlayer.SetActive(true);
             camaraSobrePlayer.SetActive(false);
             obre = true;*/
            ActivaMapa();
            

        }
    }

    private void DesactivaMapa()
    {
        Time.timeScale = 1;
        mapa.SetActive(false);
        obre = false;
        Debug.Log("TancaMapa");
    }

    private void ActivaMapa()
    {
        Debug.Log("Obremapa");
        Time.timeScale = 0;
        mapa.SetActive(true);
        camaraSobrePlayer.SetActive(true);
        camaraSobrePlayer.SetActive(false);
        obre = true;

    }
}
