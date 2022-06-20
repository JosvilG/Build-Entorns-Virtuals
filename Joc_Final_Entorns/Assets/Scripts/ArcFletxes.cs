using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcFletxes : MonoBehaviour
{
    bool go;

    GameObject player; //Personatge
    GameObject fletxes; //Arma del personatge

    Transform itemToRotate; //Fill del gameobject

    Vector3 locationInFrontOfPlayer; //Posicio cap a la que viatjara
    // Start is called before the first frame update
    void Start()
    {
        go = false;

        player = GameObject.Find("PJ_v2"); // On torna el objecte
        fletxes = GameObject.Find("ShortAttackColider"); //Arma actual del personatge

        fletxes.GetComponent<MeshRenderer>().enabled = false;  //Amaga l'arma actual

        itemToRotate = gameObject.transform.GetChild(0); //Troba el fill del gameobject actual

        locationInFrontOfPlayer = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z) + player.transform.forward * 150f;

        StartCoroutine(Boom());
    }

    IEnumerator Boom()
    {
        go = true;
        yield return new WaitForSeconds(0.5f);
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        //itemToRotate.transform.Rotate(0, Time.deltaTime * 500, 0);
        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 60);
        }
        if (!go)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Time.deltaTime * 40);
            Destroy(this.gameObject);
            fletxes.GetComponent<MeshRenderer>().enabled = true;
        }
        if (!go && Vector3.Distance(player.transform.position, transform.position) < 1.5)
        {
            fletxes.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
