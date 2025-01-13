using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker current;
    public float shakeDuration = 1f;
    public float shakeIntensity = 0.2f;

    private Vector3 initialPos;
    private float currentShakeDuration = 0f;
    private void Awake()
    {
        current = this;
    }
    private void Start()
    {
        initialPos = transform.localPosition;
    }

    private void Update()
    {
        //if (currentShakeDuration < 0)
        //{
        //    Vector3 randomOffset = Random.insideUnitSphere * shakeIntensity;
        //    transform.localPosition = initialPos + randomOffset;

        //    currentShakeDuration -= Time.deltaTime;
        //}
        //else
        //{
        //    transform.localPosition = initialPos;
        //}
    }

    public void Shake(float duration, float strength = 1, int frequency = 10)
    {
        //currentShakeDuration = shakeDuration;

        transform.DOShakePosition(duration, strength, frequency);


    }

}
