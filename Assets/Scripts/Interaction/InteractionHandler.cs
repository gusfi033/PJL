using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{

    public Camera mainCamera;

    public float raycastDist = 9f;
    public LayerMask layerMask = 1;

    public Interactor hoveredInteractor;


    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HoverInteract();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TryInteract();
        }

    }


    void HoverInteract()
    {
        bool hasHit = Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out RaycastHit hitInfo, raycastDist, layerMask);

        if (!hasHit)
        {
            UiManager.current.SetCursorDefault();
            return;
        }

        bool hasInteractor = hitInfo.collider.TryGetComponent<Interactor>(out hoveredInteractor);


        if (hasInteractor)
        {
            UiManager.current.SetCursorInteract();
        }
        else
        {
            UiManager.current.SetCursorDefault();
        }

    }

    void TryInteract()
    {
        if (hoveredInteractor == null) return;

        hoveredInteractor.Interact();
    }
}
