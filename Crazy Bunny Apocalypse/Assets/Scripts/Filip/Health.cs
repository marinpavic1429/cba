using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject zeko;

    [SerializeField]
    private int startingHealth = 5;
    [SerializeField]
    private int currentHealth;
    public AudioClip deadSound;

    private void Start()
    {
        zeko = GameObject.FindWithTag("Player");
    }

    //poziva se kada objekt postane enabled and active
    private void OnEnable()
    {
        currentHealth = startingHealth;
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        gameObject.GetComponent<Animator>().SetBool("Hit", true);
        StartCoroutine(VratiSeIzAnimacije());
        if(currentHealth <= 0)
        {
            zeko.GetComponent<Gun>().zombunniesKilled++;
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Stop();
            audioSource.PlayOneShot(deadSound);
            gameObject.GetComponent<Animator>().SetBool("Death", true);
            StartCoroutine(UnistiZombija());
        }
    }

    IEnumerator UnistiZombija()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    IEnumerator VratiSeIzAnimacije()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Animator>().SetBool("Hit", false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
