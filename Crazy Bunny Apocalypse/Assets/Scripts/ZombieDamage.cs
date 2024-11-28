using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDamage : MonoBehaviour
{
    public bool start = false;
    public static int damage;
    private NavMeshAgent navMeshAgent;
    public float hurtPauseTime;
    public GameObject player;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerStats ps = new PlayerStats();
        StartCoroutine(Cekaj());
        navMeshAgent = GetComponent<NavMeshAgent>();
        hurtPauseTime = 3;
        //damage = 10;
    }


    void OnTriggerStay(Collider other) {
        

        if (start && hurtPauseTime <= 0.0f && other.CompareTag("Player") && Vector3.Distance(other.transform.position, transform.position) < 1f && gameObject.GetComponent<Animator>().GetBool("Punch") == false)
        {

            //Debug.LogError(navMeshAgent.remainingDistance);
            //Debug.LogError(navMeshAgent.remainingDistance);
            hurtPauseTime = 1f;
            if(!gameObject.GetComponent<Animator>().GetBool("Death"))
            {
                StartCoroutine(Punching());
                other.GetComponent<PlayerStats>().TakeDamage(damage);
            }
            
        }

    }

    IEnumerator DamageEffect()
    {
        var obj = Instantiate(canvas);
        obj.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        //obj.gameObject.SetActive(false);
        Destroy(obj.gameObject);
    }

    IEnumerator Punching()
    {
        gameObject.GetComponent<Animator>().SetBool("Punch", true);
        yield return new WaitForSeconds(1);
        StartCoroutine(DamageEffect());
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Animator>().SetBool("Punch", false);
    }

    IEnumerator Cekaj()
    {
        yield return new WaitForSeconds(2);
        start = true;

    }


    // Update is called once per frame
    void Update()
    {

        hurtPauseTime -= Time.deltaTime;
    }
}
