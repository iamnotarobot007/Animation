using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public float fov = 180f;
    public Transform target;
    public bool insight;

    public float AwareDistance = 5f;
    public bool AwareOfPlayer;
    public NavMeshAgent enemyAgent;

    public bool playerInVision;

    public Animator anim;
    public float Range = 2f;


    private void Update()
    {
        drawRay();
        float PlayerDistance = Vector3.Distance(target.position, transform.position);
        Vector3 playerDirection = target.position - transform.position;
        float playerAngle = Vector3.Angle(transform.forward, playerDirection);
        if (playerAngle <= fov / 2f)
        {

            insight = true;
          
        }
        else insight = false;
        if (insight == true && PlayerDistance <= AwareDistance && playerInVision == true)
        {
            AwareOfPlayer = true;
        }
        else AwareOfPlayer = false;
        if (AwareOfPlayer == true)
        {
            enemyAgent.SetDestination(target.position);
          //  anim.SetBool("Walk", true);
        }
       
       // else anim.SetBool("Walk", false);
        if (PlayerDistance >= Range && playerInVision == true)
        {
            anim.SetTrigger("Attack");
           // anim.SetBool("Idle", true);
        }
       

    }

    void drawRay()
    {
        Vector3 playerDirection = target.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, playerDirection, out hit))
        {
            if (hit.transform.tag == "Player") playerInVision = true;
            else playerInVision = false;
        }

    }
}

