using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    Health,
    Damage
}

public class PowerUp : MonoBehaviour
{
    private Gun gun;
    public GameObject pickupEffect;
    public Animator animation;
    public PowerUpType powerUpType;

    private void Start()
    {
        gun = GameObject.Find("Zeko").GetComponent<Gun>();
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            StartCoroutine(PickUp(collider));
        }
    }

    IEnumerator PickUp(Collider player) {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        animation.Play("Base Layer.opened_closed", 0, 0f);
        PlayerStats stats = player.GetComponent<PlayerStats>();
        if (powerUpType == PowerUpType.Health)
        {
            int health = (int)stats.healthBar.GetHealth();
            if (health >= 60)
            {
                stats.healthBar.SetHealth(100);
            }
            else
            {
                stats.healthBar.SetHealth(health + 40);
            }
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
            yield return new WaitForSeconds(2);
        }
        else if (powerUpType == PowerUpType.Damage) {
            //int damage = stats.damage*2;
            gun.UpdateAmmoOnPowerUp();
            //stats.SetDamage(damage);
            gameObject.GetComponent<BoxCollider>().isTrigger = false; 
            yield return new WaitForSeconds(2);
            transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(8);
            //stats.SetDamage(damage/2);
        }

        Destroy(gameObject);
    }
}
