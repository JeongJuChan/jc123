using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform playerTrans;
    Animator anim;
    Rigidbody rigid;

    Vector3 move;

    NavMeshAgent pathFinder;
    
    public float speed = 100f;

    bool playerDead;

    
    public Collider attackCollider;


    void Start()
    {
        playerTrans = FindObjectOfType<PlayerMovement>().transform;
        anim = GetComponent<Animator>();
        pathFinder = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Vector3.Distance(playerTrans.position, transform.position) < 2f)
        {
            StartCoroutine(Attack());
        }

        if (!playerDead) pathFinder.SetDestination(playerTrans.position);


    }

    IEnumerator Attack()
    {
        anim.SetTrigger("Attack");
        attackCollider.enabled = true;
        yield return new WaitForSeconds(0.2f);
        attackCollider.enabled = false;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Okay"))
        {
            anim.SetTrigger("Run");
        }
    }

    public void EnemyWin()
    {
        anim.SetBool("Win", true);
        playerDead = true;
    }

}
