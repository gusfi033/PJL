using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRotation;

    Rigidbody rb;

    public static FallingCube current;
    private bool isInDeathZone = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPos = transform.position;
        startRotation = transform.rotation;  

        SetupVars();
    }

    private void SetupVars()
    {
        rb.freezeRotation = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deathbound") && !isInDeathZone)
        {
            Debug.Log("FallingCube entered the death zone");
            isInDeathZone = true;  
            Resspawn();  
        }
    }

    public void Resspawn()
    {
        transform.position = startPos;
        transform.rotation = startRotation;  

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        isInDeathZone = false;
    }
}
