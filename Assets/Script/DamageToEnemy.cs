using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    public float Health = 100f;

    public void DamageFromPlayer(float Amount)
    {
        Health -= Amount;
    }
    void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
