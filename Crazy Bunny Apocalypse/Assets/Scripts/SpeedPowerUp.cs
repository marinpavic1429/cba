using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{

    private float duration = 10f;
    private float normalSpeep = 1f;
    private float boostSpeed = 2f;
    public GameObject pickUpEffect;
    public GameObject unisti;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider player)
    {
        Instantiate(pickUpEffect, transform.position, transform.rotation);
        Animator playerAnimator = player.GetComponent<Animator>();
        playerAnimator.speed = boostSpeed;

        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
       // player.GetComponent<TrailRenderer>().enabled = true;
        Debug.LogError("Pokrenuta brzina");
        yield return new WaitForSeconds(duration);
        Debug.LogError("Zaustavljena brzina");
        playerAnimator.speed = normalSpeep;
        //player.GetComponent<TrailRenderer>().enabled = false;
        Destroy(gameObject);
        Destroy(GameObject.Find("ExplosionMobile(Clone)"));


    }

}
