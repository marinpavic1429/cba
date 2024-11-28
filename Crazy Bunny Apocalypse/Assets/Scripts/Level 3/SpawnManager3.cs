using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnManager3 : MonoBehaviour
{
    //varijante zombija koji ce se stvoriti
    public GameObject[] zombunnys;
    private int redniBrojZombunnya;

    //podatci o stvaranju zombija
    //public static int maxNumOfEnemies;
    public int maxNumOfEnemies = 10;

    //pozicije stvaranja
    private float posX;
    private float posZ;

    //hardkodirane vrijednost
    private float minX_First = 96f;
    private float maxX_First = 147f;
    private float minZ_First = 25f;
    private float maxZ_First = 123f;

    private float minX_Second = -60f;//-42
    private float maxX_Second = 22f;  //11
    private float minZ_Second = 25f; //60
    private float maxZ_Second = 120f;  //100

    


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
            Gun.zombunniesSpawned = 20;
        }
        else if(LoadSceneParameters.medium){
            Gun.zombunniesSpawned = 30;
        }
        else if(LoadSceneParameters.hard){
            Gun.zombunniesSpawned = 30;
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
            {

                while (true)
                {
                    posX = Random.Range(minX_First, maxX_First);
                    posZ = Random.Range(minZ_First, maxZ_First);
                    if ((posX > 111 && posX < 127) || (posZ > 103 && posZ < 118) || (posZ > 35 && posZ < 49))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                


                var pozicijaStvanja = new Vector3(posX, -1.5f, posZ);
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
                while (true)
                {
                    posX = Random.Range(minX_Second, maxX_Second);
                    posZ = Random.Range(minZ_Second, maxZ_Second);
                    if ((posX > 11 || posX < -42) && (posZ > 100 || posZ < 60))
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
        
    }
}
