using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraOrbit : MonoBehaviour
{
    public float turnSpeed = 1.0f;
    public Transform player;

    private Vector3 offset;
    private Vector3 a;
    private Vector3 rotacio;
    public int posX;
    public int posY;
    bool comp = false;

    void Start()
    {
        Cursor.visible = false;
        //offset = new Vector3(player.position.x-5, player.position.y+10,0);
        offset = new Vector3(player.position.x +posX, player.position.y + posY, 0);
        rotacio = new Vector3(0, 0, 0);
    }

    void LateUpdate()
    {
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.eulerAngles = transform.eulerAngles - rotacio;
        transform.LookAt(player.position);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && comp==false)
        {
            Cursor.visible = true;
            comp = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && comp == true)
        {
            Cursor.visible = false;
            comp = false;
        }

    }
}
