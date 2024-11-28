using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneParameters : MonoBehaviour
{
    public string sceneName;
    public static bool easy = false;
    public static bool medium = false;
    public static bool hard = false;
   
    public void EasyLoadGame()
    {
        SpawnManager.maxNumOfEnemies = 10;
        ZombieDamage.damage = 10;
        easy = true;
        medium = false;
        hard = false;
        SceneManager.LoadScene(sceneName);
    }

    public void MediumLoadGame()
    {
        SpawnManager.maxNumOfEnemies = 15;
        ZombieDamage.damage = 10;
        easy = false;
        medium = true;
        hard = false;
        SceneManager.LoadScene(sceneName);
    }

    public void HardLoadGame()
    {
        SpawnManager.maxNumOfEnemies = 15;
        ZombieDamage.damage = 20;
        easy = false;
        medium = false;
        hard = true;
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSoundVolume(float volume)
    {
        SoundsManager.soundVolume = volume;
    }

    public void ChangeMusicVolume(float volume)
    {
        SoundsManager.musicVolume = volume;
    }
}
