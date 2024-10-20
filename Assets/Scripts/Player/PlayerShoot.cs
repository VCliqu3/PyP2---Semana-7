using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int fireRate;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform bulletPrefab;

    private float shootTimer;

    private void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        shootTimer = 0f;
    }

    private void Update()
    {
        CheckShoot();
        HandleShootCooldown();
    }

    private bool GetFireInput() => InputManager.Instance.GetFireInput();

    private void CheckShoot()
    {
        if (!GetFireInput()) return;
        if (ShootOnCooldown()) return;

        FireBullet();
        ResetTimer();
    }

    private void FireBullet()
    {
        Transform prefab = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        prefab.GetComponent<BulletHandler>().SetDirection(GetShootDirection());
    }

    private Vector3 GetShootDirection()
    {
        Vector3 direction = (firePoint.position - transform.position);
        direction.y = 0;

        direction.Normalize();

        return direction;
    }

    private void HandleShootCooldown()
    {
        if (shootTimer < 0) return;

        shootTimer -= Time.deltaTime;
    }

    private bool ShootOnCooldown() => shootTimer > 0f;
    private void ResetTimer() => shootTimer = 1f / fireRate;
}