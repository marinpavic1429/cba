using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int damage;
    public HealthBar healthBar;
    private CharacterController cc;
    private bool jumping = false;
    GameObject player;
    public static bool playerStatsAnimation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cc = GetComponent<CharacterController>();
        damage = 20;
        healthBar.SetHealth(100);
        playerStatsAnimation = true;
    }

    void Update() {
        
        if (Input.GetButton("Jump") && jumping == false && !playerStatsAnimation)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            jumping = true;
            StartCoroutine(Jumping());
        }
    }

    IEnumerator Jumping()
    {
        Animator playerAnimator = player.GetComponent<Animator>();
        if (playerAnimator.speed == 2)
        {
            yield return new WaitForSeconds(0.85f);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            jumping = false;
        }
        else
        {
            yield return new WaitForSeconds(1.7f);
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            jumping = false;
        }

        
    }

    public void TakeDamage(int damageTaken) {
        healthBar.SetHealth((int)healthBar.GetHealth() - damageTaken);
        if ((int)healthBar.GetHealth() <= 0) {
            gameObject.GetComponent<Animator>().SetBool("Die", true);
            cc.enabled = false;
        }
    }

    

    public void SetDamage(int newDamage) {
        damage = newDamage;
    }



}
