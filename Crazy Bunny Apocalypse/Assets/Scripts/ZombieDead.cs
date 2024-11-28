using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDead : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    bool dead;
   
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        dead = gameObject.GetComponent<Animator>().GetBool("Death").Equals(true);

        if(dead)
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            navMeshAgent.isStopped = true;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f, gameObject.transform.position.z);

        }
    }
}
