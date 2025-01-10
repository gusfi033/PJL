using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefuseBox : MonoBehaviour
{

    float defuseTime = 10f;
    float currentValue;

    public bool isDefusing = false;
    public bool isDone = false;

    float completePercentage;

    private void Start()
    {
        defuseTime = GameManager.current.defuseTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == null) return;
        if (!other.attachedRigidbody.CompareTag("Player")) return;

        isDefusing = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody == null) return;
        if (!other.attachedRigidbody.CompareTag("Player")) return;

        isDefusing = false;

    }


    void Update()
    {
        if (!isDefusing)
        {
            UiManager.current.HideDefuseProgress();
        }

        if (!isDefusing) return;
        if (isDone) return;

        if (completePercentage < 100)
        {
            currentValue += Time.deltaTime;
            currentValue = Mathf.Min(currentValue, defuseTime);

            completePercentage = Mathf.Round((currentValue / defuseTime) * 100f);
            UiManager.current.UpdateDefuseProgress(completePercentage);


        }
        else if (!isDone)
        {
            Defuse();
        }



    }
    void Defuse()
    {
        UiManager.current.ShowCompleteProgress();
        GameManager.current.GameWin();

    }
}
