using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimeUI : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private TextMeshProUGUI levelTime;

    private void OnEnable()
    {
        LevelTimerManager.OnTimerInitialized += LevelTimerManager_OnTimerInitialized;
        LevelTimerManager.OnTimerDecreased += LevelTimerManager_OnTimerDecreased;
    }

    private void OnDisable()
    {
        LevelTimerManager.OnTimerInitialized -= LevelTimerManager_OnTimerInitialized;
        LevelTimerManager.OnTimerDecreased -= LevelTimerManager_OnTimerDecreased;
    }

    private void SetLevelTimeText(int secs)
    {
        int minutes = secs / 60;
        int seconds = secs % 60;

        string minutesChain = minutes.ToString();
        string secondsChain = seconds.ToString();
        string totalChain;

        if (minutes > 0 && seconds < 10) secondsChain = "0" + seconds.ToString();

        if (minutes > 0)
        {
            totalChain = $"{minutesChain}:{secondsChain}";
        }
        else
        {
            totalChain = $"{secondsChain}";
        }

        SetRawLevelTimeText(totalChain);
    }

    private void SetRawLevelTimeText(string levelTimeText) => levelTime.text = levelTimeText;

    #region LevelTimerManager Subscriptions

    private void LevelTimerManager_OnTimerInitialized(object sender, LevelTimerManager.OnTimerEventArgs e)
    {
        SetLevelTimeText(e.time);
    }

    private void LevelTimerManager_OnTimerDecreased(object sender, LevelTimerManager.OnTimerEventArgs e)
    {
        SetLevelTimeText(e.time);
    }
    #endregion
}
