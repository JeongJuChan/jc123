using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Follow : MonoBehaviour
{
    
    void Start()
    {
        CinemachineVirtualCamera cam = FindObjectOfType<CinemachineVirtualCamera>();
        cam.Follow = transform;
    }

    void Update()
    {
        
    }
}
