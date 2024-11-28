using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    private int totalAmmo = 180; 
    public int maxAmmo = 30;
    private int currentAmmo;
    private bool isReloading = false;
    public int zombunniesKilled = 0;
    public static int zombunniesSpawned;
    public Text ammoDisplay;
    public Text objDisplay;
    GameObject player;
    public GameObject cross;
    public Color objectiveColor;
    public static bool gunAnimation;

    public GameObject endLevel1Text;
    public GameObject lijevaVrataOtvorena;
    public GameObject desnaVrataOtvorena;
    public GameObject zatvorenaVrata;

    public GameObject endLevel2Text;

    public GameObject endLevel3Text;

    public GameObject zena;
    public GameObject dijete1;
    public GameObject dijete2;
    public GameObject dijete3;

    private string sceneName;

    [SerializeField]
    [Range(0.1f, 1.5f)] //dodaje slider
    private float fireRate = 0.3f;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    //[SerializeField]
    //private Transform firePoint;

    //[SerializeField]
    //private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFireSource;
    public AudioClip clip;

    private float timer;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        gunAnimation = true;
        currentAmmo = maxAmmo;
        player = GameObject.FindGameObjectWithTag("Player");

        if(endLevel1Text != null)
        {
            endLevel1Text.SetActive(false);
        }

        if(endLevel2Text != null)
        {
            endLevel2Text.SetActive(false);
        }

        if (endLevel3Text != null)
        {
            endLevel3Text.SetActive(false);
        }

        if (sceneName.Equals("Level 1"))
        {
            lijevaVrataOtvorena.SetActive(false);
            desnaVrataOtvorena.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // uvjet za stvaranje mrkve
        if(sceneName.Equals("Level 1"))
        {
            if ((SpawnManager.maxNumOfEnemies == 10 && zombunniesKilled == 40) || (SpawnManager.maxNumOfEnemies == 15 && zombunniesKilled == 60))
            {
                endLevel1Text.SetActive(true);
                lijevaVrataOtvorena.SetActive(true);
                desnaVrataOtvorena.SetActive(true);
                zatvorenaVrata.SetActive(false);
                GameObject.Find("Mrkvica").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Mrkvica").GetComponent<BoxCollider>().enabled = true;
            }
        } else if(sceneName.Equals("Level 2"))
        {
            if((SpawnManager.maxNumOfEnemies == 10 && zombunniesKilled == 40) || (SpawnManager.maxNumOfEnemies == 15 && zombunniesKilled == 50))
            {
                endLevel2Text.SetActive(true);
                GameObject.Find("Mrkvica").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Mrkvica").GetComponent<BoxCollider>().enabled = true;
            }
        } else if(sceneName.Equals("Level 3"))
        {
            if ((SpawnManager.maxNumOfEnemies == 10 && zombunniesKilled == 20) || (SpawnManager.maxNumOfEnemies == 15 && zombunniesKilled == 30))
            {
                endLevel3Text.SetActive(true);
                GameObject.Find("Mrkva").GetComponent<MeshRenderer>().enabled = true;
                GameObject.Find("Mrkva").GetComponent<BoxCollider>().enabled = true;
                zena.SetActive(true);
                dijete1.SetActive(true);
                dijete2.SetActive(true);
                dijete3.SetActive(true);
            }
        }

        if (Input.GetButton("Fire2") && !gunAnimation)
        {
            cross.SetActive(true);
        }
        else
        {
            cross.SetActive(false);
        }
        
        ammoDisplay.text = currentAmmo.ToString() + " / " + totalAmmo.ToString();
        objDisplay.text = "  Zombunnies killed: " + zombunniesKilled.ToString() + " / " + zombunniesSpawned.ToString();
        if(zombunniesKilled >= zombunniesSpawned){
            objDisplay.text = "  Zombunnies killed: " + zombunniesKilled.ToString() + " / " + zombunniesSpawned.ToString() + "\n  Objective Completed!";
            objDisplay.color = objectiveColor;
        }
        timer += Time.deltaTime;
        if(timer > fireRate)
        {
            if (isReloading)
            {
                return;
            }
            if(currentAmmo <= 0 && totalAmmo != 0 && gameObject.GetComponent<Animator>().GetBool("Aim") == false)
            {
                Reload();
            }
            else if(currentAmmo > 0 && currentAmmo < maxAmmo && Input.GetButton("RRR") &&  totalAmmo != 0 && gameObject.GetComponent<Animator>().GetBool("Aim") == false)
            {
                Reload();
            }
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                if(currentAmmo >=1 && currentAmmo <= maxAmmo && gameObject.GetComponent<Animator>().GetBool("Aim") == true)
                {
                    currentAmmo--;
                    FireGun();
                }
                else
                {
                    gameObject.GetComponent<Animator>().SetBool("Fire", false);
                }
                
            }
        }
    }

    void Reload()
    {
        isReloading = true;
        gameObject.GetComponent<Animator>().SetBool("Reload", true);
        StartCoroutine(Reloading());
        if (totalAmmo - (maxAmmo - currentAmmo) >= 0)
        {
            totalAmmo -= (maxAmmo - currentAmmo);
            currentAmmo = maxAmmo;
        }
        else
        {
            currentAmmo += totalAmmo;
            totalAmmo = 0;
        }
        //totalAmmo -= (maxAmmo - currentAmmo);
        //currentAmmo = maxAmmo;

    }

    IEnumerator Reloading()
    {
        Animator playerAnimator = player.GetComponent<Animator>();
        if(playerAnimator.speed == 2)
        {
            yield return new WaitForSeconds(1.5f);
            isReloading = false;
            gameObject.GetComponent<Animator>().SetBool("Reload", false);
        }
        else
        {
            yield return new WaitForSeconds(3f);
            isReloading = false;
            gameObject.GetComponent<Animator>().SetBool("Reload", false);
        }

        
    }

    public void UpdateAmmoOnPowerUp()
    {
        currentAmmo = maxAmmo;
        totalAmmo = 180;
    }
    private void FireGun()
    {
        //crtanje zrakle da mozemo testirati radi li ispravno
        //Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);

        //muzzleParticle.Play(); //pokreni cestice pucanja
        gunFireSource.PlayOneShot(clip);//pokreni audio

        //radi zraku, od koje tocke gleda do koje tocke
        //Ray ray = new Ray(firePoint.position, firePoint.forward);
        //stavi zraku da ide od tocke gdje kamera gleda
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        RaycastHit hitInfo; //tu se pospremaju svi podaci
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        //Casts a ray, from point origin, in direction direction, of length maxDistance, against all colliders in the Scene.
        //true ako pogodimo nesto
        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            //Destroy(hitInfo.collider.gameObject);
            var health = hitInfo.collider.GetComponent<Health>();
            /////////////////////////////
            //if (hitInfo.collider.CompareTag("Head"))
            //{
            //    Debug.Log("Head");
            //    health.TakeDamage(damage + 1);
            //}
            //if (hitInfo.collider.CompareTag("Body"))
            //{
            //    Debug.Log("Body");
            //    health.TakeDamage(damage);
            //}
            /////////////////////////////
            //  var colider = hitInfo.collider.GetComponent<SphereCollider>();
            if (health != null)// ako smo pogopdili nesto
            {
                //if (hitInfo.collider.CompareTag("Head"))
                //{
                //    Debug.Log("Head");
                //    health.TakeDamage(damage + 1); //oduzmi health objektu za damage amount
                //}
                //if (hitInfo.collider.CompareTag("Body"))
                //{
                //    Debug.Log("Body");
                //    health.TakeDamage(damage); //oduzmi health objektu za damage amount

                //}
                health.TakeDamage(damage); //oduzmi health objektu za damage amount

            }
        }
    }
}
