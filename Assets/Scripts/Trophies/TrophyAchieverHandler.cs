using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyAchieverHandler : MonoBehaviour
{
    private const int ENTER_GAME_TROPHY_ID = 248027;
    private const int LEVEL2_GAME_TROPHY_ID = 248028;
    private const int VICTORY_GAME_TROPHY_ID = 248031;
    private const int KILL_10_ENEMIES_TROPHY_ID = 248029;
    private const int KILL_20_ENEMIES_TROPHY_ID = 248030;

    private const string MAIN_MENU_SCENE_NAME = "MainMenu";
    private const string LEVEL2_SCENE_NAME = "Level2";
    private const string VICTORY_SCENE_NAME = "Victory";

    private const int KILL_10_ENEMIES_KILL_COUNT = 10;
    private const int KILL_20_ENEMIES_KILL_COUNT = 20;

    private void OnEnable()
    {
        SceneLoadChecker.OnSceneLoad += SceneLoadChecker_OnSceneLoad;
        EnemiesKilledHandler.OnEnemyKilled += EnemiesKilledHandler_OnEnemyKilled;
    }

    private void OnDisable()
    {
        SceneLoadChecker.OnSceneLoad -= SceneLoadChecker_OnSceneLoad;
        EnemiesKilledHandler.OnEnemyKilled -= EnemiesKilledHandler_OnEnemyKilled;
    }

    #region Trophy Checkers

    private void CheckAchieveEnterGameTrophy(string sceneName)
    {
        if (sceneName != MAIN_MENU_SCENE_NAME) return;

        Trophies.TryUnlock(ENTER_GAME_TROPHY_ID);
    }

    private void CheckAchieveLevel2Trophy(string sceneName)
    {
        if (sceneName != LEVEL2_SCENE_NAME) return;

        Trophies.TryUnlock(LEVEL2_GAME_TROPHY_ID);
    }

    private void CheckAchieveVictoryTrohphy(string sceneName)
    {
        if (sceneName != VICTORY_SCENE_NAME) return;

        Trophies.TryUnlock(VICTORY_GAME_TROPHY_ID);
    }

    private void CheckAchieve10EnemiesKilledTrophy(int enemiesKilled)
    {
        if (enemiesKilled < KILL_10_ENEMIES_KILL_COUNT) return;

        Trophies.TryUnlock(KILL_10_ENEMIES_TROPHY_ID);
    }

    private void CheckAchieve20EnemiesKilledTrophy(int enemiesKilled)
    {
        if (enemiesKilled < KILL_20_ENEMIES_KILL_COUNT) return;

        Trophies.TryUnlock(KILL_20_ENEMIES_TROPHY_ID);
    }
    #endregion

    #region Subscriptions

    private void SceneLoadChecker_OnSceneLoad(object sender, SceneLoadChecker.OnSceneLoadEventArgs e)
    {
        CheckAchieveEnterGameTrophy(e.sceneName);
        CheckAchieveLevel2Trophy(e.sceneName);
        CheckAchieveVictoryTrohphy(e.sceneName);
    }


    private void EnemiesKilledHandler_OnEnemyKilled(object sender, EnemiesKilledHandler.OnEnemyKilledEventArgs e)
    {
        CheckAchieve10EnemiesKilledTrophy(e.enemiesKilled);
        CheckAchieve20EnemiesKilledTrophy(e.enemiesKilled);
    }
    #endregion
}
