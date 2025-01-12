using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;

    [SerializeField] TextMeshProUGUI countdownText;

    private void Start()
    {
        currentTime = startingTime;

        countdownText.gameObject.SetActive(false);

        StartCoroutine(StartCountdownAfterDelay(5f));
 
    }

    private void Update()
    {
        if (countdownText.gameObject.activeSelf) 
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 1)
            {
                currentTime = 1;

                
                countdownText.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator StartCountdownAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        countdownText.gameObject.SetActive(true);
    }
}
