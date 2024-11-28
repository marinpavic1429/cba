using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotation : MonoBehaviour
{
    private float speed = 50.0f;
    public GameObject go;

    void Start()
    {

    }

    void Update()
    {
        go.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

}
