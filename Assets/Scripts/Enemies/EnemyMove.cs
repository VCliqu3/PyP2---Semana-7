using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float distanceToStall;

    private GameObject player;
    private Rigidbody _rigidbody;


    private const string PLAYER_TAG = "Player";

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(PLAYER_TAG);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < distanceToStall)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }

        Vector3 movementDirection = player.transform.position - transform.position;
        movementDirection.y = 0f;
        movementDirection.Normalize();

        _rigidbody.velocity = movementDirection * speed;
    }
}
