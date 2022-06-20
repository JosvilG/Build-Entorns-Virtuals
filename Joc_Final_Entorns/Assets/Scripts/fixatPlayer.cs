using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixatPlayer : MonoBehaviour
{

    public Transform player;
    public Transform aquest;
    public bool noMoure;
    bool girarCamara=false;
    // Start is called before the first frame update
    void Start()
    {
        
        aquest.position = player.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (this.tag == "orbe")
        {
            aquest.position = player.position+new Vector3(0,-10,0);
        }
        /*if (this.name == "camaraSobrePlayer")
        {
            aquest.position = player.position + new Vector3(0, 20, 0);

        }*/

        else
        {
            if (aquest.transform.position == player.transform.position)
            {

            }
            else
            {

                aquest.position = player.position;
            }
            if (noMoure == false)
            {
                if (Input.GetKey(KeyCode.Mouse1) && Input.GetAxis("Mouse X") < 0)
                {
                    //Code for action on mouse moving left
                    aquest.transform.Rotate(0, 110f * Time.deltaTime, 0);
                }
                if (Input.GetKey(KeyCode.Mouse1) && Input.GetAxis("Mouse X") > 0)
                {
                    //Code for action on mouse moving right
                    aquest.transform.Rotate(0, -110f * Time.deltaTime, 0);
                }
                if (Input.GetButtonDown("Jump") && girarCamara==false && aquest.transform.rotation != player.transform.rotation)
                {
                    //aquest.transform.rotation = player.transform.rotation;
                    
                    StartCoroutine(Reposiciona());
                }
            }
            else if (noMoure == true)
            {

            }
        }

        
        if (girarCamara == true)
        {
            aquest.transform.Rotate(0, 400 * Time.deltaTime, 0);
            /*if (aquest.transform.rotation == player.transform.rotation)
            {
                aquest.transform.Rotate(0, 0, 0);
                girarCamara = false;
            }*/
        }
        else
        {
            aquest.transform.Rotate(0, 0, 0);
        }
    }

    IEnumerator Reposiciona()
    {
        girarCamara = true;
        yield return new WaitForSeconds(0.45f);
        girarCamara = false;
    }

}
