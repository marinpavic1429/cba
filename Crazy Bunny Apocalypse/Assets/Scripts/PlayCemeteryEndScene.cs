using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCemeteryEndScene : MonoBehaviour
{

    public GameObject videoPlayer;
    public GameObject canvas;
    private int timeToStop = 15;

    void Start()
    {
        videoPlayer.SetActive(false);
        canvas.SetActive(false);

        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(ActivateVideo());
        }
    }

    IEnumerator ActivateVideo()
    {
        GameObject.FindGameObjectWithTag("SceneManager").GetComponent<PauseManager>().enabled = false;
        AudioListener.volume = 0f;
        GameObject.Find("PlayerHealth").SetActive(false);
        GameObject.Find("Canvas").SetActive(false);
        videoPlayer.SetActive(true);

        yield return new WaitForSeconds(1f);

        GameObject.Find("Zeko").SetActive(false);

        Destroy(videoPlayer, timeToStop);

        yield return new WaitForSeconds(12.4f);

        canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
