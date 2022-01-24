using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public float randomPivot;

    // public MeshRenderer matPivot;

    public SkinnedMeshRenderer matPivot;

    private void Start() {
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

        // switch (randomPivot)
        // {
        //     case 0:
        //     matPivot.material.color = Color.red;
        //     break;

        //     case 1:
        //     matPivot.material.color = Color.blue;
        //     break;

        //     case 2:
        //     matPivot.material.color = Color.green;
        //     break;

        //     default:
        //     break;
        // }
    }
}
