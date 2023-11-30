using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastShoot : MonoBehaviour
{
    public Camera PlayerCamera;
    public float Damage = 20f;

    public float Firerate = 10f;
    private float nextShot;

    public int ammocount = 25;
    public int availableammo = 100;
    public int maxAmmo = 25;
    public Animator anim;
    public TMPro.TMP_Text bulletCount;

    public Animator aimAnim;

    public bool aim;

 



    void Update()
    {
        if (Input.GetButtonDown("Fire2")) aim = !aim;
        if (aim == true)
        {
            aimAnim.SetBool("AIM", true);

        }
        else aimAnim.SetBool("AIM", false);

        bulletCount.text = ammocount.ToString();

        if (Input.GetKeyDown(KeyCode.R) && ammocount <= maxAmmo)anim.SetBool("Reload", true);
      
        if (ammocount <= 0)
        {
            anim.SetBool("Reload", true);
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextShot)
        {
            //logic for time delay to shot
            nextShot = Time.time + 4f / Firerate;
            WeaponFire();
        }
    }

   
    void WeaponFire()
    {
        ammocount--;
        RaycastHit hit;
       
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit))
        {

            if (hit.transform.tag == "Enemy")
            {
                Debug.Log(hit.transform.name);
                DamageToEnemy attack = hit.transform.GetComponent<DamageToEnemy>();
                attack.DamageFromPlayer(Damage);
            }
        }

    }
    public void Reload()
    {
        availableammo = availableammo - maxAmmo + ammocount;
        ammocount = maxAmmo;
        anim.SetBool("Reload", false);
    }
}


