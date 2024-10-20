using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour, ICanDealDamage
{
    [Header("Settings")]
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [Space]
    [SerializeField] private string targetTag;
    [Space]
    [SerializeField] private float lifeSpan;

    private void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    private void Update()
    {
        MoveBullet();
    }
    public void SetDirection(Vector3 dir) => direction = dir;

    private void MoveBullet()
    {
        Vector3 bulletMovementVector = speed * Time.deltaTime * direction;
        transform.Translate(bulletMovementVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(targetTag))
        {
            Destroy(gameObject);
            return;
        }

        if (other.TryGetComponent(out IHasHealth iHasHealth))
        {
            DoDamage(iHasHealth);
        }

        Destroy(gameObject);
    }

    public int GetDamage() => damage;

    public void DoDamage(IHasHealth iHasHealth) => iHasHealth.TakeDamage(damage);
}