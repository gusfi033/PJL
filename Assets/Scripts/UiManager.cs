using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Canvas cameraCanvas;
    public static UiManager current;

    [Header("Bomb")]
    [SerializeField] TextMeshProUGUI countdownText;  // Texto do countdown


    [Header("Defuse")]
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image image;

    private void Awake()
    {
        current = this;
        cameraCanvas.worldCamera = Camera.main;
    }


    public void UpdateBombCountDown(float remainingTime)
    {
        // Calcula os minutos e segundos restantes
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ShowBombCountDownExplode()
    {
        countdownText.color = Color.red;
    }

    public void ShowBombCountDownDefuse()
    {
        UpdateBombCountDown(0);
        countdownText.color = Color.green;
    }

    public void HideDefuseProgress()
    {
        image.enabled = false;
        text.enabled = false;
    }


    public void ShowCompleteProgress()
    {
        text.text = "DEFUSE";
        text.color = Color.green;
        image.enabled = false;
    }
    public void UpdateDefuseProgress(float percentage)
    {
        image.enabled = true;
        text.enabled = true;
        text.text = $"{percentage} %";
        image.fillAmount = percentage / 100;
    }
}
