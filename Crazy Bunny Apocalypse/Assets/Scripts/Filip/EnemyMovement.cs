using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private AggroDetection aggroDetection;
    private Transform target;
    private float speed;
    

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        this.target = target;
    }


    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //ostatak = Time.time.ToString().Split('.');
            //broj = "1." + ostatak[1];
            //konacniBroj = double.Parse(broj);
            //finalNum = (konacniBroj - 1) / (2 - 1 + 1) * (5 - 2 + 1) + 2;
            //Debug.Log(finalNum);
            var distance = navMeshAgent.remainingDistance;
            speed = vratiBrzinu(distance);
            navMeshAgent.SetDestination(target.position); //prati playera
            float currentSpeed = navMeshAgent.velocity.magnitude;
            navMeshAgent.speed = speed;
            //Debug.Log(speed);
            
            //  animator.SetFloat("Speed", currentSpeed);
        }

    }

    private float vratiBrzinu(float distance)
    {
        if(distance < 2)
        {
            speed = 0.6f;
        }
        else if (distance < 4)
        {
            speed = 1f;
        }
        else if (distance < 6)
        {
            speed = 1f;
        }
        else if (distance < 8)
        {
            speed = 1f;
        }
        else if (distance < 10)
        {
            speed = 1f;
        }
        else if (distance < 12)
        {
            speed = 1f;
        }
        else if (distance < 14)
        {
            speed = 1.2f;
        }
        else if (distance < 16)
        {
            speed = 1.4f;
        }
        else if (distance < 18)
        {
            speed = 1.6f;
        }
        else if (distance < 20)
        {
            speed = 1.8f;
        }
        else if (distance < 22)
        {
            speed = 2.0f;
        }
        else if (distance < 24)
        {
            speed = 2.1f;
        }
        else if (distance < 26)
        {
            speed = 2.2f;
        }
        else if (distance < 28)
        {
            speed = 2.5f;
        }
        else if (distance <= 30)
        {
            speed = 2.8f;
        } else
        {
            speed = 3f;
        }
        return speed;
    }
}
