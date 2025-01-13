using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefuseBox : MonoBehaviour, Interactor
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



    void Update()
    {
        if (isDefusing)
        {
            if (!Input.GetKey(KeyCode.Mouse0))
            {
                UiManager.current.ShowCursor();
                isDefusing = false;
            }
        }



        if (!isDefusing)
        {
            UiManager.current.HideDefuseProgress();

            currentValue = 0;
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

    public void Interact(float holdTime)
    {
        isDefusing = true;
      
        UiManager.current.HideCursor(); 
    }

    public void StartHoldInteract()
    {
    }
}
