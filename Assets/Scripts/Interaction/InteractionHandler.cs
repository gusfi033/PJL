using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public static InteractionHandler current;

    public Camera mainCamera;

    public float raycastDist = 9f;
    public LayerMask layerMask = 1;

    public Interactor hoveredInteractor;
    public float startInteractTime;

    public float timerMultiplier=4.5f;

    private void Awake()
    {
        current = this;
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
            TryHoldInteract();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
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

    void TryHoldInteract()
    {
        if (hoveredInteractor == null) return;
        startInteractTime = Time.time;

        hoveredInteractor.StartHoldInteract();
    }
    void TryInteract()
    {
        if (hoveredInteractor == null) return;

        float currentTime = Time.time;

        hoveredInteractor.Interact(currentTime - startInteractTime);
    }
}
