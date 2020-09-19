using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    public float sensitivity;

    int coin = 0;
    bool canThrow = false;
    void Start()
    {
        Cursor.visible = false;
    }

   
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        
        if (controller.isGrounded)
        {
            
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            
           
            moveDirection *= speed;
            
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        turner = Input.GetAxis("Mouse X") * sensitivity;
        looker = -Input.GetAxis("Mouse Y") * sensitivity;
        if (turner != 0)
        {
            
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        if (looker != 0)
        {
            
            transform.eulerAngles += new Vector3(looker, 0, 0);
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        print("gg");
        controller.Move(moveDirection * Time.deltaTime);



        //Attack
        if (Input.GetButtonDown("Fire1"))
        {
            if (coin > 9)
            {
                print("Fiiiiire");
            }
            else
            {
                print("You must have over 9 coin");
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            
            Destroy(other.gameObject);
            coin = coin + 1;
            print(coin);
        }
    }

}
