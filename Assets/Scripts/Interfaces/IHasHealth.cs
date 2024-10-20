using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasHealth
{
    public int GetHealth();
    public void IncreaseHealth(int quantity);
    public void TakeDamage(int quantity);
    public bool IsAlive();
    public void Die();
}
