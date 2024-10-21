using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirePointPositioning : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform enemy;

    [Header("Settings")]
    [SerializeField] private float distanceFromEnemy;

    private void Start()
    {
        SetDistanceFromEnemy();
    }

    private void Update()
    {
        HandleFirePointPosition();
    }

    private void SetDistanceFromEnemy() => distanceFromEnemy = Vector3.Distance(transform.position, enemy.position);

    private void HandleFirePointPosition()
    {
        if (!PlayerHealth.Instance) return;

        transform.localPosition = new Vector3(distanceFromEnemy * GetFirePointDirection().x, transform.localPosition.y, distanceFromEnemy * GetFirePointDirection().z);
    }

    private Vector3 GetFirePointDirection()
    {
        Vector3 direction = (PlayerHealth.Instance.transform.position - enemy.position);
        direction.y = 0f;

        direction.Normalize();

        return direction;
    }
}
