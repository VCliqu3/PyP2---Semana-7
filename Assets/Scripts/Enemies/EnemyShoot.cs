using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float fireRate;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform bulletPrefab;
    [Space]
    [SerializeField] private float timeToStartShooting;

    private float shootTimer;

    private void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        shootTimer = timeToStartShooting;
    }

    private void Update()
    {
        CheckShoot();
        HandleShootCooldown();
    }

    private void CheckShoot()
    {
        if (!PlayerHealth.Instance) return;
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
        Vector3 direction = (PlayerHealth.Instance.transform.position - firePoint.position);
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
