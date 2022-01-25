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
            if (!anim.applyRootMotion)
            {
                anim.applyRootMotion = true;
            }

            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed,
                transform.position.y, transform.position.z);
            }
        }
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            Cube cube = hit.collider.GetComponent<Cube>();
            if (hit.collider.CompareTag("Okay") && cube.currentColor != cube.pivot.randomPivot)
            {
                anim.SetBool("isJump", true);
                Gamemanager.instance.count = 0;
            }
        }
        else anim.SetBool("isJump", false);
     

    }


    

}
