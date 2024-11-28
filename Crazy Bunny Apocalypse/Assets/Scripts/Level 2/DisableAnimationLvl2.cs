using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimationLvl2 : MonoBehaviour
{
    private Animator anim;
    public GameObject zeko;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(CountAnimationDuration());
    }

    IEnumerator CountAnimationDuration()
    {
        yield return new WaitForSeconds(24);
        anim.enabled = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        Gun.gunAnimation = false;
        Jump.jumpAnimation = false;
        PlayerStats.playerStatsAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.enabled){
            zeko.GetComponent<PlayMakerFSM>().enabled = false;
            camera.GetComponent<PlayMakerFSM>().enabled = false;
        }
        else{
            zeko.GetComponent<PlayMakerFSM>().enabled = true;
            camera.GetComponent<PlayMakerFSM>().enabled = true;
        }
    }
}
