using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
            touch = Input.GetTouch(0);
            
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                if(rigid.useGravity == false)
                {
                    rigid.useGravity = true;
                    UImanager.instance.offText();
                }
                
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed,
                    transform.position.y, transform.position.z);
                }
            }
                
        }
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            Cube cube = hit.collider.GetComponent<Cube>();
            if (hit.collider.CompareTag("Okay") && cube.currentColor != cube.pivot.randomPivot)
            {
                Gamemanager.instance.combo = 0;
                anim.SetBool("isJump", true);
            }
        }
        else anim.SetBool("isJump", false);
    }
}
