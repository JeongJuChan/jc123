using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject m_goPrefab  = null;
    [SerializeField] float m_force = 0f;
    [SerializeField] Vector3 m_offset = Vector3.zero;
    [SerializeField] ParticleSystem m_particle;

    // 색에 맞을때 파괴
    public MeshRenderer meshRenderer;
    
    public float currentColor;
    Pivot pivot;

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

        Debug.Log("현재색" + currentColor);
    }

    public virtual void Explosion()
    {
        if(currentColor != pivot.randomPivot) return;

        // Gamemanager.instance.TimeStop();

        Vibration.Vibrate((long)300);

        GameObject t_clone = Instantiate(m_goPrefab, transform.position, Quaternion.identity);
        if(t_clone != null)
        {
            m_particle.Play();
            
        }
        Rigidbody[] t_rigids = t_clone.GetComponentsInChildren<Rigidbody>();
        for(int i = 0; i< t_rigids.Length; i++)
        {
            t_rigids[i].AddExplosionForce(m_force, transform.position + m_offset, 10f);
        }


        gameObject.SetActive(false);
        Destroy(t_clone, 3f);

        pivot.RandomColor();
        
    }
    private void OnCollisionEnter(Collision other) 
    {
        PlayerMovement player = other.collider.GetComponentInParent<PlayerMovement>();
        if (player != null)
        {
            Explosion();
        }
        
    }


}
