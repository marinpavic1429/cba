using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAmmoRotation : MonoBehaviour
{

    private float speed = 50.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
