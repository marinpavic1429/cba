using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    private bool openedMenu = false;
    public GameObject pauseCanvas;
    public GameObject camera;
    public GameObject zeko;
    public GameObject deadMenu;


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && !zeko.GetComponent<Animator>().GetBool("Die"))
        {
            if (openedMenu)
            {
                Back();
            }
            else
            {
                pauseCanvas.SetActive(true);
                Time.timeScale = 0f;
                AudioListener.volume = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                openedMenu = true;
            }
        }
        if(openedMenu){
            zeko.GetComponent<PlayMakerFSM>().enabled = false;
            camera.GetComponent<PlayMakerFSM>().enabled = false;
        }
        else{
            zeko.GetComponent<PlayMakerFSM>().enabled = true;
            camera.GetComponent<PlayMakerFSM>().enabled = true;
        }

        if (zeko.GetComponent<Animator>().GetBool("Die"))
        {    
            StartCoroutine(PauseMenuOnDie());
        }
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start menu");
    }

    public void Back()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        openedMenu = false;
    }

    public void OnRetry()
    {
        Back();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator PauseMenuOnDie()
    {
        yield return new WaitForSeconds(3f);
        openedMenu = true;
        GameObject.FindGameObjectWithTag("PlayerHealth").SetActive(false);
        GameObject.Find("Canvas").SetActive(false); 
        deadMenu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
