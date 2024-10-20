using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelTimerManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int levelTime;

    [Header("Debug")]
    [SerializeField] private float timer;

    public static event EventHandler<OnTimerEventArgs> OnTimerInitialized;
    public static event EventHandler<OnTimerEventArgs> OnTimerDecreased;
    public static event EventHandler OnTimerReachedZero;

    private int previousTime;

    public class OnTimerEventArgs : EventArgs
    {
        public int time;
    }

    private void Start()
    {
        InitializeVariables();
    }

    private void Update()
    {
        HandleTimer();
    }

    private void InitializeVariables()
    {
        SetTimer(levelTime);
        previousTime = levelTime;
        OnTimerInitialized?.Invoke(this, new OnTimerEventArgs { time = levelTime });
    }

    private void HandleTimer()
    {
        if (timer <= 0f) return;
            
        timer-=Time.deltaTime;

        if(Mathf.CeilToInt(timer)< previousTime)
        {
            int newPreviousTime = Mathf.CeilToInt(timer);
            OnTimerDecreased?.Invoke(this, new OnTimerEventArgs { time = newPreviousTime });
            previousTime = newPreviousTime;
        }

        if(timer <= 0f)
        {
            OnTimerReachedZero?.Invoke(this, EventArgs.Empty);
        }
    }

    private void SetTimer(int time) => timer = time;
    private void ResetTimer() => timer = 0f;
}
