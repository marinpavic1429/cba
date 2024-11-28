using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject panel;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeBackgroundColor()
    {
        if (panel.GetComponent<Image>().color == UnityEngine.Color.white) {
            panel.GetComponent<Image>().color = UnityEngine.Color.black;
        }
        else
        {
            panel.GetComponent<Image>().color = UnityEngine.Color.white;
        }
    }
}
