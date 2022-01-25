using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject m_goPrefab  = null;
    public float m_force = 0f;
    public ParticleSystem m_particle;
    public Vector3 m_offset = Vector3.zero;

    public float currentColor;
    public Pivot pivot;
    AudioSource debrisAudio;
    
    public virtual void Explosions()
    {
        Vibration.Vibrate((long)100);

        GameObject t_clone = Instantiate(m_goPrefab, transform.position, Quaternion.identity);
        if(t_clone != null) 
        {
            debrisAudio = t_clone.GetComponent<AudioSource>();
            debrisAudio.Play();
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

        Gamemanager.instance.Combo();
        
    }

}
