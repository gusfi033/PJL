using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float xSens;
    public float ySens;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        orientation = PlayerMovement.current.orientation;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;

        yRotation += mouseX;


        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
