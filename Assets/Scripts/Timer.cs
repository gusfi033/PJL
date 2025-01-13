using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.VFX;
public class Timer : MonoBehaviour
{
    public static Timer current;
    public TextMeshProUGUI timerBase;
    public VisualEffect effect;

    public TimerInstance subtractTimer;

    public List<TimerInstance> timers = new List<TimerInstance>();

    public class TimerInstance
    {
        public Transform source;
        public Vector3 sourceOffset;


        public float startTime;
        public float counter;
        public TextMeshProUGUI timerUI;
    }


    private void Awake()
    {
        current = this;
    }

    public void CreateSubtractTimer(Transform source, Vector3 offset)
    {
        var timerUI = GameObject.Instantiate(timerBase);
        timerUI.transform.parent = timerBase.transform.parent;

        //VFXEventAttribute vFXEventAttribute = effect.CreateVFXEventAttribute();
        //vFXEventAttribute.SetVector3("Pos", source.position);
        //effect.SendEvent("OnFreeze", vFXEventAttribute);

        TimerInstance instance = new TimerInstance();
        instance.sourceOffset = offset;
        instance.source = source;
        instance.startTime = Time.time;
        instance.timerUI = timerUI;

        subtractTimer = instance;

    }

    public void DestroySubtractTimer()
    {
        Destroy(subtractTimer.timerUI.gameObject);
        subtractTimer = null;
    }

    public void CreateNewTimer(Transform source, Vector3 offset, float duration)
    {
        foreach (var timer in timers)
        {
            if (timer.source == source && timer.counter > 0)
                return;
        }

        var timerUI = GameObject.Instantiate(timerBase);
        timerUI.transform.parent = timerBase.transform.parent;


        VFXEventAttribute vFXEventAttribute = effect.CreateVFXEventAttribute();
        vFXEventAttribute.SetVector3("Pos", source.position);
        effect.SendEvent("OnFreeze", vFXEventAttribute);

        TimerInstance instance = new TimerInstance();
        instance.sourceOffset = offset;
        instance.source = source;
        instance.startTime = Time.time;
        instance.timerUI = timerUI;
        instance.counter = duration;

        timers.Add(instance);
    }


    private void Update()
    {
        if (subtractTimer != null)
        {
            var newPos = subtractTimer.source.position + subtractTimer.timerUI.transform.TransformDirection(-subtractTimer.sourceOffset);
            subtractTimer.timerUI.transform.position = newPos;

            subtractTimer.timerUI.transform.forward = -(Camera.main.transform.position - newPos);

            subtractTimer.counter += Time.deltaTime * InteractionHandler.current.timerMultiplier;

            var currentTimeSpan = TimeSpan.FromSeconds(subtractTimer.counter);
            subtractTimer.timerUI.text = $"{currentTimeSpan.Minutes:D2}:{currentTimeSpan.Seconds:D2}";
        }

        foreach (var timer in timers)
        {

            var newPos = timer.source.position + timer.timerUI.transform.TransformDirection(-timer.sourceOffset);
            timer.timerUI.transform.position = newPos;

            timer.timerUI.transform.forward = -(Camera.main.transform.position - newPos);

            timer.counter -= Time.deltaTime;

            var currentTimeSpan = TimeSpan.FromSeconds(timer.counter);
            timer.timerUI.text = $"{currentTimeSpan.Minutes:D2}:{currentTimeSpan.Seconds:D2}";
        }


        for (int i = timers.Count - 1; i >= 0; i--)
        {
            if (timers[i].counter <= 0)
            {
                GameObject.Destroy(timers[i].timerUI);
                timers.RemoveAt(i);
            }
        }

    }
}
