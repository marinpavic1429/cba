using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{

    private float duration = 0.05f;
    public GameObject pickUpEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider player)
    {
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        PlayerStats stats = player.GetComponent<PlayerStats>();
        int health = (int)stats.healthBar.GetHealth();
        if (health >= 50)
        {
            stats.healthBar.SetHealth(100);
        }
        else
        {
            stats.healthBar.SetHealth(health + 50);
        }
        gameObject.GetComponent<BoxCollider>().isTrigger = false;

        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(duration);

        Destroy(gameObject);
        Destroy(GameObject.Find("ExplosionMobile(Clone)"));

    }

}
