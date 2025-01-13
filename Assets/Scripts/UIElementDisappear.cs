using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIElementDisappear : MonoBehaviour
{
    public Image uiElement;
    public float disapier;

    void Start()
    {
        StartCoroutine(DisappearAfterTime(disapier));
    }

    private IEnumerator DisappearAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        uiElement.enabled= false;

    }
}
