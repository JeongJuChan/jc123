using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public float randomPivot;

    public SkinnedMeshRenderer matPivot;

    public Collider punchCol;

    private void Start() 
    {
        RandomColor();
        matPivot = GetComponent<SkinnedMeshRenderer>();
        Debug.Log(randomPivot);
    }

    public void RandomColor()
    {
        randomPivot = Random.Range(0,3);

        if(randomPivot == 0)
        {
            matPivot.material.color = Color.red;
        }
        if(randomPivot == 1)
        {
            matPivot.material.color = Color.blue;
        }
        if(randomPivot == 2)
        {
            matPivot.material.color = Color.green;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        ExitWall exit = other.GetComponent<ExitWall>();
        if (exit != null)
        {
            exit.stack++;
        }
    }
}
