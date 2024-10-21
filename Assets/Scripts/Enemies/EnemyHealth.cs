using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHasHealth
{
    [Header("Settings")]
    [SerializeField, Range(10f, 50f)] private int maxHealth;

    public int health;

    public static event EventHandler<OnEnemyTakeDamage> OnPlayerTakeDamage;
    public static event EventHandler OnEnemyDie;

    public class OnEnemyTakeDamage : EventArgs
    {
        public int health;
    }

    private void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        health = maxHealth;
    }

    #region IHasHealth Methods
    public int GetHealth() => health;

    public void IncreaseHealth(int quantity) => health = health + quantity > maxHealth ? maxHealth : health + quantity;

    public bool IsAlive() => health > 0;

    public void TakeDamage(int quantity)
    {
        health = (health - quantity) < 0 ? 0 : health - quantity;

        OnPlayerTakeDamage?.Invoke(this, new OnEnemyTakeDamage { health = health });

        if (!IsAlive())
        {
            Die();
        }
    }
    public void Die()
    {
        OnEnemyDie?.Invoke(this, EventArgs.Empty); 
        Destroy(gameObject);
    }
    #endregion
}

