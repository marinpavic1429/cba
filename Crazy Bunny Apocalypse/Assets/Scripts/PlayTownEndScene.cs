using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTownEndScene : MonoBehaviour
{

    public GameObject zena;
    public GameObject dijete1;
    public GameObject dijete2;
    public GameObject dijete3;

    public GameObject videoPlayer;
    public GameObject canvas;
    private int timeToStop = 37;

    void Start()
    {
        videoPlayer.SetActive(false);
        canvas.SetActive(false);

        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        zena.SetActive(false);
        dijete1.SetActive(false);
        dijete2.SetActive(false);
        dijete3.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateVideo());
        }
    }

    IEnumerator ActivateVideo()
    {
        GameObject.Find("PlayerHealth 1").SetActive(false);
        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<PauseManager>().enabled = false;
        AudioListener.volume = 0f;
        GameObject.Find("Canvas").SetActive(false);
        videoPlayer.SetActive(true);

        yield return new WaitForSeconds(1f);

        GameObject.Find("ZekoLvl3").SetActive(false);
        zena.SetActive(false);
        dijete1.SetActive(false);
        dijete2.SetActive(false);
        dijete3.SetActive(false);

        Destroy(videoPlayer, timeToStop);

        yield return new WaitForSeconds(34.5f);

        canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
