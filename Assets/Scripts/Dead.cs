using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void playerDead()
    {
        anim.SetBool("isDead",true);
        UImanager.instance.restartButton.SetActive(true);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            playerDead();
            other.GetComponentInParent<Enemy>().EnemyWin();
            GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
