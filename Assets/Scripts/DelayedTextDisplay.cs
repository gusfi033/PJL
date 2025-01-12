using System.Collections;
using UnityEngine;
using TMPro;
using Unity.UI;

public class DelayedTextDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] float delayBeforeDisplay = 10f;
    [SerializeField] float displayDuration = 2f;

    private void Start()
    {
        if (displayText != null)
        {
           
            displayText.gameObject.SetActive(false);

            
            StartCoroutine(ShowTextAfterDelay(delayBeforeDisplay, displayDuration));
        }
    }

    private IEnumerator ShowTextAfterDelay(float delay, float duration)
    {
        
        yield return new WaitForSeconds(delay);

        
        displayText.gameObject.SetActive(true);

        
        yield return new WaitForSeconds(duration);

        
        displayText.gameObject.SetActive(false);
    }
}
