using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Animator anim;
    public FPSController player;
  
    void Update()
    {
        float curSpeedX = Input.GetAxis("Vertical") ;
        float curSpeedY = Input.GetAxis("Horizontal");

        if (curSpeedX == 0f && curSpeedY == 0f)
        {
            anim.SetBool("Breath", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }
        else
        {
            if (player.isWalking == false)
            {
                anim.SetBool("Breath", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
            }
            if (player.isWalking == true)
            {
                anim.SetBool("Breath", false);
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
            }
        }
    }

   
}
