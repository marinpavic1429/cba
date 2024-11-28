using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    public static float soundVolume = 1f;
    public static float musicVolume = 0.3f;
    public GameObject soundSlider;
    public GameObject musicSlider;

    void Awake()
    {
        ChangeSoundVolume(soundVolume);
        ChangeMusicVolume(musicVolume);
        soundSlider.GetComponent<Slider>().normalizedValue = soundVolume;
        musicSlider.GetComponent<Slider>().normalizedValue = musicVolume;
    }

    public void ChangeSoundVolume(float volume)
    {
        soundVolume = volume;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().volume = volume;
        foreach (GameObject zombie in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            zombie.GetComponent<AudioSource>().volume = volume;
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        musicVolume = volume;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().volume = volume;
    }
}
