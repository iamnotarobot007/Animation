using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    public ParticleSystem pS;
    List<ParticleCollisionEvent> colEvents=new List<ParticleCollisionEvent>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pS.Play();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
       int events= pS.GetCollisionEvents(other, colEvents);
        Debug.Log("hit");
        for(int i = 0; i <= events; i++)
        {

        }
    }
}
