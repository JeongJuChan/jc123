using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
        FinalMove finalMove = other.GetComponent<FinalMove>();
        Animator playerAnim = other.GetComponent<Animator>();

        if (playerMovement != null)
        {
            finalMove.enabled = true;
            playerMovement.enabled = false;
            
        }
    }
}
