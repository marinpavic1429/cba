using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour
{
    //varijante zombija koji ce se stvoriti
    public GameObject[] zombunnys;
    private int redniBrojZombunnya;

    public GameObject endTextCanvas;

    //podatci o stvaranju zombija
    public static int maxNumOfEnemies;

    //pozicije stvaranja
    private float posX;
    private float posZ;

    //hardkodirane vrijednost
    private float minX_SW = 20f;
    private float maxX_SW = 80f;
    private float minZ_SW = 20f;
    private float maxZ_SW = 80f;

    private float minX_SE = 193f;
    private float maxX_SE = 227f;
    private float minZ_SE = 22f;
    private float maxZ_SE = 63f;

    private float minX_NW = 27f;
    private float maxX_NW = 62f;
    private float minZ_NW = 178f;
    private float maxZ_NW = 223f;

    private float minX_NE = 188f;
    private float maxX_NE = 225f;
    private float minZ_NE = 180f;
    private float maxZ_NE = 223f;

    private float minX_CENTER = 88f;
    private float maxX_CENTER = 142f;
    private float minZ_CENTER = 100f;
    private float maxZ_CENTER = 131f;

    private NavMeshAgent navMeshAgent;


    public int GetMaxNumOfEnemies()
    {
        return maxNumOfEnemies;
    }

    public void SetMaxNumOfEnemies(int newValue)
    {
        maxNumOfEnemies = newValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(LoadSceneParameters.easy){
            Gun.zombunniesSpawned = 40;
        }
        else if(LoadSceneParameters.medium){
            Gun.zombunniesSpawned = 60;
        }
        else if(LoadSceneParameters.hard){
            Gun.zombunniesSpawned = 60;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        //sw trigger
        if (other.CompareTag("SW"))
        {
            Debug.LogError("SW trigger");
            Debug.LogError("Sm skripta: " + GetMaxNumOfEnemies());
            for (int i = 0; i < maxNumOfEnemies; i++)
            {
                Debug.LogError("Sm skripta: "+ maxNumOfEnemies);
                while (true)
                {
                    posX = Random.Range(minX_SW, maxX_SW);
                    posZ = Random.Range(minZ_SW, maxZ_SW);
                    if ((posX > 50 || posX < 30) && (posZ > 50 || posZ < 35))
                    {
                        break;
                    }
                }
                var pozicijaStvanja = new Vector3(posX, 0, posZ);
                redniBrojZombunnya = Random.Range(0, zombunnys.Length);

                var enemy = Instantiate(zombunnys[redniBrojZombunnya], pozicijaStvanja, zombunnys[redniBrojZombunnya].transform.rotation);
                //Debug.LogError(navMeshAgent.remainingDistance);
                enemy.transform.LookAt(transform.position);
                enemy.GetComponent<AudioSource>().volume = SoundsManager.soundVolume;
            }
        }

        //se trigger
        if (other.CompareTag("NW"))
        {
            Debug.LogError("NW trigger");
            for (int i = 0; i < maxNumOfEnemies; i++)
            {
                while (true)
                {
                    posX = Random.Range(minX_NW, maxX_NW);
                    posZ = Random.Range(minZ_NW, maxZ_NW);
                    if ((posX > 56 || posX < 35) && (posZ > 215 || posZ < 195))
                    {
                        break;
                    }
                }
                var pozicijaStvanja = new Vector3(posX, 0, posZ);
                redniBrojZombunnya = Random.Range(0, zombunnys.Length);

                var enemy = Instantiate(zombunnys[redniBrojZombunnya], pozicijaStvanja, zombunnys[redniBrojZombunnya].transform.rotation);
                //Debug.LogError(navMeshAgent.remainingDistance);
                enemy.transform.LookAt(transform.position);
                enemy.GetComponent<AudioSource>().volume = SoundsManager.soundVolume;
            }
        }

        //se trigger
        if (other.CompareTag("NE"))
        {
            Debug.LogError("NE trigger");
            for (int i = 0; i < maxNumOfEnemies; i++)
            {
                while (true)
                {
                    posX = Random.Range(minX_NE, maxX_NE);
                    posZ = Random.Range(minZ_NE, maxZ_NE);
                    if ((posX > 216 || posX < 197) && (posZ > 213 || posZ < 194))
                    {
                        break;
                    }
                }
                var pozicijaStvanja = new Vector3(posX, 0, posZ);
                redniBrojZombunnya = Random.Range(0, zombunnys.Length);

                var enemy = Instantiate(zombunnys[redniBrojZombunnya], pozicijaStvanja, zombunnys[redniBrojZombunnya].transform.rotation);
                //Debug.LogError(navMeshAgent.remainingDistance);
                enemy.transform.LookAt(transform.position);
                enemy.GetComponent<AudioSource>().volume = SoundsManager.soundVolume;
            }
        }

        //se trigger
        if (other.CompareTag("SE"))
        {
            Debug.LogError("SE trigger");
            for (int i = 0; i < maxNumOfEnemies; i++)
            {
                while (true)
                {
                    posX = Random.Range(minX_SE, maxX_SE);
                    posZ = Random.Range(minZ_SE, maxZ_SE);
                    if ((posX > 220 || posX < 200) && (posZ > 50 || posZ < 30))
                    {
                        break;
                    }
                }
                var pozicijaStvanja = new Vector3(posX, 0, posZ);
                redniBrojZombunnya = Random.Range(0, zombunnys.Length);

                var enemy = Instantiate(zombunnys[redniBrojZombunnya], pozicijaStvanja, zombunnys[redniBrojZombunnya].transform.rotation);
                //Debug.LogError(navMeshAgent.remainingDistance);
                enemy.transform.LookAt(transform.position);
                enemy.GetComponent<AudioSource>().volume = SoundsManager.soundVolume;
            }
        }

        //se trigger
        if (other.CompareTag("CENTER"))
        {
            endTextCanvas.GetComponent<TextMeshProUGUI>().enabled = false;
            Debug.LogError("CENTER trigger");
            for (int i = 0; i < 4; i++)
            {
                posX = Random.Range(minX_CENTER, maxX_CENTER);
                posZ = Random.Range(minZ_CENTER, maxZ_CENTER);

                var pozicijaStvanja = new Vector3(posX, 0, posZ);
                redniBrojZombunnya = Random.Range(0, zombunnys.Length);

                var enemy = Instantiate(zombunnys[redniBrojZombunnya], pozicijaStvanja, zombunnys[redniBrojZombunnya].transform.rotation);
                //Debug.LogError(navMeshAgent.remainingDistance);
                enemy.transform.LookAt(transform.position);
                enemy.GetComponent<AudioSource>().volume = SoundsManager.soundVolume;
            }
        }




    }

    //nakon izlazska iz triggera zabrani daljnje spawnanje
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SW"))
        {
           // Debug.LogError("SW trigger");
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("NW"))
        {
          //  Debug.LogError("SW trigger");
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("SE"))
        {
           // Debug.LogError("SW trigger");
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("NE"))
        {
            //Debug.LogError("SW trigger");
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("CENTER"))
        {
           // Debug.LogError("SW trigger");
            other.gameObject.SetActive(false);
        }




    }
}
