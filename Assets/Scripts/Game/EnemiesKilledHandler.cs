using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemiesKilledHandler : MonoBehaviour
{
    private static int enemiesKilled = 0;

    public static event EventHandler<OnEnemyKilledEventArgs> OnEnemyKilled;

    public class OnEnemyKilledEventArgs : EventArgs
    {
        public int enemiesKilled;
    }

    private void OnEnable()
    {
        EnemyHealth.OnEnemyDie += EnemyHealth_OnEnemyDie;
    }

    private void OnDisable()
    {
        EnemyHealth.OnEnemyDie -= EnemyHealth_OnEnemyDie;
    }

    private void IncreaseEnemiesKilled()
    {
        enemiesKilled++;
        OnEnemyKilled?.Invoke(this, new OnEnemyKilledEventArgs { enemiesKilled = enemiesKilled });
    }

    public static void ResetEnemiesKilled() => enemiesKilled = 0;

    private void EnemyHealth_OnEnemyDie(object sender, System.EventArgs e)
    {
        IncreaseEnemiesKilled();
    }
}
