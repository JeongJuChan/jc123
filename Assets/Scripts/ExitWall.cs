using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWall : Explosion
{
    public int stack = 0;

    public int limit = 5;
    
    private void Update() 
    {
        if (stack == limit)
        {
            this.Explosions();
            Gamemanager.instance.Win();
        }
    }

    public override void Explosions()
    {
        Vibration.Vibrate((long)300);

        GameObject t_clone = Instantiate(m_goPrefab, transform.position, Quaternion.identity);
        if(t_clone != null) m_particle.Play();
        
        Rigidbody[] t_rigids = t_clone.GetComponentsInChildren<Rigidbody>();
        for(int i = 0; i< t_rigids.Length; i++)
        {
            t_rigids[i].AddExplosionForce(m_force, transform.position + m_offset, 10f);
        }

        gameObject.SetActive(false);
        Destroy(t_clone, 3f);
    }

    
}
