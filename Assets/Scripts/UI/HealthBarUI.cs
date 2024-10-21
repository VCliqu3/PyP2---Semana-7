using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Image healthBarImage;

    private int maxHealth;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerHealthInitialized += PlayerHealth_OnPlayerHealthInitialized;
        PlayerHealth.OnPlayerTakeDamage += PlayerHealth_OnPlayerTakeDamage;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerHealthInitialized -= PlayerHealth_OnPlayerHealthInitialized;
        PlayerHealth.OnPlayerTakeDamage -= PlayerHealth_OnPlayerTakeDamage;
    }

    private void SetMaxHealth(int health) => maxHealth = health;
    private void UpdateHealthBar(int newHealh)
    {
        float ratio = (float)newHealh/maxHealth;
        healthBarImage.fillAmount = ratio;
    }

    private void PlayerHealth_OnPlayerHealthInitialized(object sender, PlayerHealth.OnPlayerHealthEventArgs e)
    {
        SetMaxHealth(e.health);
    }

    private void PlayerHealth_OnPlayerTakeDamage(object sender, PlayerHealth.OnPlayerHealthEventArgs e)
    {
        UpdateHealthBar(e.health);
    }

}
