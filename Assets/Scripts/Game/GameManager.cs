using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string nextScene;
    [SerializeField] private string defeatScene;

    private void OnEnable()
    {
        LevelTimerManager.OnTimerReachedZero += LevelTimerManager_OnTimerReachedZero;
        PlayerHealth.OnPlayerDie += PlayerHealth_OnPlayerDie;
    }

    private void OnDisable()
    {
        LevelTimerManager.OnTimerReachedZero -= LevelTimerManager_OnTimerReachedZero;
        PlayerHealth.OnPlayerDie -= PlayerHealth_OnPlayerDie;
    }

        
    private void GoToNextScene() => SceneManager.LoadScene(nextScene);
    private void GoToDefeatScene() => SceneManager.LoadScene(defeatScene);

    private void LevelTimerManager_OnTimerReachedZero(object sender, System.EventArgs e)
    {
        GoToNextScene();
    }
    private void PlayerHealth_OnPlayerDie(object sender, System.EventArgs e)
    {
        GoToDefeatScene();
    }
}
