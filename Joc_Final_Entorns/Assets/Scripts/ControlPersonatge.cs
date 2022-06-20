using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonatge : MonoBehaviour
{

    public float speed = 20.0F;
    public float impuls = 30.0F;
    public float sprint = 45.0F;
    public float gravity = 20.0F;
    public float rotateSpeed = 10.0F;
    float SpeedBase;
    private Vector3 moveDirection = Vector3.zero;
    public int comp = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpeedBase = speed;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                speed = SpeedBase;
                moveDirection *= speed;
            
            if (Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S))
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                speed = sprint;
                moveDirection *= speed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                speed = SpeedBase;
                moveDirection *= speed;
            }
            



        }
        
        comp++;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        //Rotate Player
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
      
    }

   
}
