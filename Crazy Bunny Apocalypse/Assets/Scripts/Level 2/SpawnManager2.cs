using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager2 : MonoBehaviour
{
    //varijante zombija koji ce se stvoriti
    public GameObject[] zombunnys;
    private int redniBrojZombunnya;

    //podatci o stvaranju zombija
    //public static int maxNumOfEnemies;
    public int maxNumOfEnemies = 10;

    public GameObject endTextCanvas;

    //pozicije stvaranja
    private float posX;
    private float posZ;

    //hardkodirane vrijednost
    private float minX_First = 157f;
    private float maxX_First = 175f;
    private float minZ_First = 190f;
    private float maxZ_First = 230f;

    private float minX_Second = 210f;
    private float maxX_Second = 223f;
    private float minZ_Second = 85f;
    private float maxZ_Second = 135f;

    private float minX_Third = 91f;
    private float maxX_Third = 155;
    private float minZ_Third = 56f;
    private float maxZ_Third = 86f;

    //private float minX_Fourth = 155f;
    //private float maxX_Fourth = 166f;
    //private float minZ_Fourth = 124f;
    //private float maxZ_Fourth = 130f;

    private float minX_Fourth = 155f;
    private float maxX_Fourth = 166f;
    private float minZ_Fourth = 112f;
    private float maxZ_Fourth = 120f;


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
            Gun.zombunniesSpawned = 50;
        }
        else if(LoadSceneParameters.hard){
            Gun.zombunniesSpawned = 50;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("First"))
        {

            for (int i = 0; i < SpawnManager.maxNumOfEnemies; i++)
            //for (int i = 0; i < 20; i++)
            {
                
                posX = Random.Range(minX_First, maxX_First);
                posZ = Random.Range(minZ_First, maxZ_First);
                    
                
                var pozicijaStvanja = new Vector3(posX, 0, posZ);
                redniBrojZombunnya = Random.Range(0, zombunnys.Length);

                var enemy = Instantiate(zombunnys[redniBrojZombunnya], pozicijaStvanja, zombunnys[redniBrojZombunnya].transform.rotation);
                //Debug.LogError(navMeshAgent.remainingDistance);
                enemy.transform.LookAt(transform.position);
                enemy.GetComponent<AudioSource>().volume = SoundsManager.soundVolume;
            }
        }

        if (other.CompareTag("Second"))
        {
            for (int i = 0; i < SpawnManager.maxNumOfEnemies; i++)
            {
                posX = Random.Range(minX_Second, maxX_Second);
                posZ = Random.Range(minZ_Second, maxZ_Second);
                    
                
                var pozicijaStvanja = new Vector3(posX, 0, posZ);
                redniBrojZombunnya = Random.Range(0, zombunnys.Length);

                var enemy = Instantiate(zombunnys[redniBrojZombunnya], pozicijaStvanja, zombunnys[redniBrojZombunnya].transform.rotation);
                //Debug.LogError(navMeshAgent.remainingDistance);
                enemy.transform.LookAt(transform.position);
                enemy.GetComponent<AudioSource>().volume = SoundsManager.soundVolume;
            }
        }

        if (other.CompareTag("Third"))
        {
            for (int i = 0; i < 20; i++)
            {
                posX = Random.Range(minX_Third, maxX_Third);
                posZ = Random.Range(minZ_Third, maxZ_Third);
                    
                
                var pozicijaStvanja = new Vector3(posX, 0, posZ);
                redniBrojZombunnya = Random.Range(0, zombunnys.Length);

                var enemy = Instantiate(zombunnys[redniBrojZombunnya], pozicijaStvanja, zombunnys[redniBrojZombunnya].transform.rotation);
                //Debug.LogError(navMeshAgent.remainingDistance);
                enemy.transform.LookAt(transform.position);
                enemy.GetComponent<AudioSource>().volume = SoundsManager.soundVolume;
            }
        }

        if (other.CompareTag("Fourth"))
        {
            endTextCanvas.GetComponent<TextMeshProUGUI>().enabled = false;
            for (int i = 0; i < 5; i++)
            {
                posX = Random.Range(minX_Fourth, maxX_Fourth);
                posZ = Random.Range(minZ_Fourth, maxZ_Fourth);
                    
                
                var pozicijaStvanja = new Vector3(posX, 2f, posZ);
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
        if (other.CompareTag("First"))
        {
            // Debug.LogError("SW trigger");
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Second"))
        {
            //  Debug.LogError("SW trigger");
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Third"))
        {
            // Debug.LogError("SW trigger");
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Fourth"))
        {
            //Debug.LogError("SW trigger");
            other.gameObject.SetActive(false);
        }
        




    }
}
