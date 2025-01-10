using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void Start()
    {
        cameraPosition = PlayerMovement.current.head;
    }

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
