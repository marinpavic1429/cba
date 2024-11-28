using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimation : MonoBehaviour
{
    private Animator anim;
    public GameObject zeko;
    public GameObject kamera;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(anim.enabled);
        StartCoroutine(CountAnimationDuration());
    }

    IEnumerator CountAnimationDuration()
    {
        yield return new WaitForSeconds(30);
        anim.enabled = false;
        Gun.gunAnimation = false;
        Jump.jumpAnimation = false;
        PlayerStats.playerStatsAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.enabled){
            zeko.GetComponent<PlayMakerFSM>().enabled = false;
            kamera.GetComponent<PlayMakerFSM>().enabled = false;
        }
        else if(!anim.enabled){
            zeko.GetComponent<PlayMakerFSM>().enabled = true;
            kamera.GetComponent<PlayMakerFSM>().enabled = true;
        }
    }
}
