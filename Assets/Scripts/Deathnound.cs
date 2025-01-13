using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathnound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == null) return;
        if (!other.attachedRigidbody.CompareTag("Player")) return;

        GameManager.current.PlayerDeath();
    }
}
