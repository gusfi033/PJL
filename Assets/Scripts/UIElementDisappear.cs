using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIElementDisappear : MonoBehaviour
{
    public GameObject uiElement;

    void Start()
    {
        StartCoroutine(DisappearAfterTime(8f));
    }

    private IEnumerator DisappearAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        uiElement.SetActive(false);

    }
}
