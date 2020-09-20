using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private float speed = 6.0F;
    private float jumpSpeed = 8.0F;
    private float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float sensitivity = 5;
    private Animator anim;

    int coin = 0;
    bool canThrow = false;
    void Start()
    {
        Cursor.visible = false;
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        
        if (controller.isGrounded)
        {
            
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            
           
            moveDirection *= speed;
            
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                anim.SetBool("is_in_air", true);
            }
            else
            {
                anim.SetBool("is_in_air", false);
            }
                
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                speed = 0;
            }
            else
            {
                speed = 6;
            }
        }
        turner = Input.GetAxis("Mouse X") * sensitivity;
        if (turner != 0)
        {
            
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        
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
