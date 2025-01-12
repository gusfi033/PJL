using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayTextForDuration : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] float displayDuration = 5f;

    private void Start()
    {
        if (displayText != null)
        {
            displayText.gameObject.SetActive(true);

            StartCoroutine(HideTextAfterDelay(displayDuration));
        }
    }

    private IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        displayText.gameObject.SetActive(false);
    }
}
