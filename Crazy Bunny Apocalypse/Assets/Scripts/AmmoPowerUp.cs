using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmmoPowerUp : MonoBehaviour
{

    private Gun gun;
    private float duration = 0.05f;
    public GameObject pickUpEffect;
    public string sceneName;

    private void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>();
    }

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

        gun.UpdateAmmoOnPowerUp();

        GetComponentInChildren<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(duration);

        Destroy(gameObject);
        Destroy(GameObject.Find("ExplosionMobile(Clone)"));

    }

}
