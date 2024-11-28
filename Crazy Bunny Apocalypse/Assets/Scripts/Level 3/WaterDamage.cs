using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{

    private GameObject zeko;
    private bool izasao = true;
    private bool flag = false;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        zeko = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Cekalica", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!izasao)
        {
            StartCoroutine(OduzmiHealth());
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.LogError("Ušao");
            izasao = false;
        }
    }


    private void OnTriggerExit(Collider other)
    {

        Debug.LogError("Izašao");
        izasao = true;
    }

    IEnumerator OduzmiHealth()
    {
        if (!izasao && flag)
        {
            flag = false;
            Debug.LogError("Oduzmi Health");
            zeko.GetComponent<PlayerStats>().TakeDamage(ZombieDamage.damage);
            StartCoroutine(DamageEffect());
            yield return new WaitForSeconds(4f);
            
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

    private void Cekalica()
    {
        flag = true;
    }

}
