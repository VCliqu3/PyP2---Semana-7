using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHasHealth
{
    public static PlayerHealth Instance { get; private set; }

    [Header("Settings")]
    [SerializeField,Range(10f,50f)] private int maxHealth;

    private int health;

    public static event EventHandler<OnPlayerHealthEventArgs> OnPlayerHealthInitialized;
    public static event EventHandler<OnPlayerHealthEventArgs> OnPlayerTakeDamage;
    public static event EventHandler OnPlayerDie;

    public class OnPlayerHealthEventArgs : EventArgs
    {
        public int health;
    }

    private void Awake()
    {
        SetSingleton();
    }

    private void Start()
    {
        InitializeVariables();
    }

    private void SetSingleton()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one PlayerHealth instance");
        }

        Instance = this;
    }

    private void InitializeVariables()
    {
        health = maxHealth;
        OnPlayerHealthInitialized?.Invoke(this, new OnPlayerHealthEventArgs { health = maxHealth });
    }

    #region IHasHealth Methods
    public int GetHealth() => health;

    public void IncreaseHealth(int quantity) => health = health + quantity > maxHealth ? maxHealth : health + quantity;

    public bool IsAlive() => health > 0;

    public void TakeDamage(int quantity)
    {
        health = (health - quantity) < 0 ? 0 : health - quantity;

        OnPlayerTakeDamage?.Invoke(this, new OnPlayerHealthEventArgs { health = health});

        if (!IsAlive())
        {
            Die();
        }
    }
    public void Die()
    {
        Debug.Log("PlayerHasDied");
        OnPlayerDie?.Invoke(this, EventArgs.Empty);
    }
    #endregion
}