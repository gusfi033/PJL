using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadialProgress : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text; 
    [SerializeField] Image image; 
    [SerializeField] float speed = 10f; 

    float currentValue; 

    void Update()
    {
       
        if (currentValue < 100)
        {
            currentValue += speed * Time.deltaTime; 
            text.text = ((int)currentValue).ToString() + "%"; 
        }
        else
        {
            text.text = "DEFUSE"; 
            text.color = Color.green; 

            
            image.gameObject.SetActive(false); 
        }

        
        image.fillAmount = currentValue / 100;
    }
}
