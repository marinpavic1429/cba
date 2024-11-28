using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AggroDetection : MonoBehaviour
{
    //event
    public event Action<Transform> OnAggro = delegate { };

    private NavMeshAgent navMesh;
    private CharacterController player;

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<CharacterController>();

        if (player != null)
        {
            OnAggro(player.transform);
            //Debug.Log("Player je usao u prostor neprijatelja");
           
            // navMesh = GetComponent<NavMeshAgent>(); //prati playera

        }
    }

    private void Update()
    {
        //navMesh.SetDestination(player.transform.position);
    }
}
