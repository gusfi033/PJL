using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{

    public Camera mainCamera;

    public float raycastDist = 9f;
    public LayerMask layerMask = 1;

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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TryInteract();
        }

    }


    void TryInteract()
    {
        bool hasHit = Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out RaycastHit hitInfo, raycastDist, layerMask);

        if (!hasHit) return;

        bool hasInteractor = hitInfo.collider.TryGetComponent<Interactor>(out Interactor interactor);

        if (!hasInteractor) return;

        interactor.Interact();

    }
}
