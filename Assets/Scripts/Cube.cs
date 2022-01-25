using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Explosion
{
    
    public MeshRenderer meshRenderer;

    public AudioSource cubeaudio;
    
    

    private void Awake() {
        
        pivot = FindObjectOfType<Pivot>();
        
        if(meshRenderer.material.color == Color.red)
        {
            currentColor = 0;
        }
        if(meshRenderer.material.color == Color.blue)
        {
            currentColor = 1;
        }
        if(meshRenderer.material.color == Color.green)
        {
            currentColor = 2;
        }

        cubeaudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        PlayerMovement player = other.collider.GetComponentInParent<PlayerMovement>();
        if (player != null && currentColor == pivot.randomPivot)
        {
            Explosions();
        }
    }


}
