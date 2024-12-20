using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FreezePhysicsInteractor : MonoBehaviour, Interactor
{

    public Vector3 offset= new Vector3(0,0,1);
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

    public void Interact()
    {
        Freeze();
    }

    void Freeze()
    {
        body.isKinematic = true;

        Timer.current.CreateNewTimer(transform, offset, freezeTime);

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
}
