using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Canvas cameraCanvas;
    public static UiManager current;

    [Header("Center Cursor")]
    public GameObject cursorContainer;
    public GameObject cursorDefault;
    public GameObject cursorInteract;

    [Header("Bomb")]
    [SerializeField] TextMeshProUGUI countdownText;  // Texto do countdown


    [Header("Defuse")]
    [SerializeField] TextMeshProUGUI defuseWinText;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image image;
    [SerializeField] GameObject defuseContainer;

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
        defuseContainer.SetActive(false);
        text.enabled = false;
    }


    public void ShowCompleteProgress()
    {
        defuseWinText.text = "DEFUSE";
        image.enabled = false;
        defuseContainer.SetActive(false);

    }
    public void UpdateDefuseProgress(float percentage)
    {
        defuseContainer.SetActive(true);
        image.enabled = true;
        text.enabled = true;
        text.text = $"{percentage} %";
        image.fillAmount = percentage / 100;
    }


    public void ShowCursor()
    {
        cursorContainer.SetActive(true);
    }

    public void HideCursor()
    {
        cursorContainer.SetActive(false);
    }

    public void SetCursorInteract()
    {
        cursorDefault.SetActive(false);
        cursorInteract.SetActive(true);
    }

    public void SetCursorDefault()
    {
        cursorDefault.SetActive(true);
        cursorInteract.SetActive(false);

    }
}
