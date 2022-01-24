using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Touch touch;
    float speed;

    Rigidbody rigid;
    
    public Animator anim;

    Collider col;

    Dead dead;

    public bool test;

    void Start()
    {
        speed = 0.01f;    
        test = false;
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
        dead = GetComponent<Dead>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if(rigid.useGravity == false)
            {
                rigid.useGravity = true;
            }

            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed,
                transform.position.y, transform.position.z);
            }
        }
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f))
        {
            if (hit.collider.CompareTag("Okay"))
            {
                anim.SetBool("isJump", true);
                anim.applyRootMotion = true;
            } 
                

        }
        else anim.SetBool("isJump", false);

        
    }

    


    

}
