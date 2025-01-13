using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class FreezePhysicsInteractor : MonoBehaviour, Interactor
{

    public Vector3 offset = new Vector3(0, 0, 1);
    public float freezeTime = 5f;
    Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact(float holdTime)
    {
        Timer.current.DestroySubtractTimer();
        Freeze(holdTime);
    }

    void Freeze(float holdTime)
    {
        holdTime = holdTime * InteractionHandler.current.timerMultiplier;

        body.isKinematic = true;

        var removedTime = Bomb.current.SubtractTime(holdTime);
        Timer.current.CreateNewTimer(transform, offset, removedTime);

        StartCoroutine(WaitToUnfreeze());
    }

    void Unfreeze()
    {
        body.isKinematic = false;
    }
    IEnumerator WaitToUnfreeze()
    {
        yield return new WaitForSeconds(freezeTime);
        Unfreeze();
    }

    public void StartHoldInteract()
    {
        Timer.current.CreateSubtractTimer(transform, offset);
    }
}
