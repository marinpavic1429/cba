using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnNextLevelLoad : MonoBehaviour
{
    public string sceneName;
    
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneName);
        AudioListener.volume = 1f;
    }
}
