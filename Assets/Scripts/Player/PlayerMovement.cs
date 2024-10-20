using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField,Range(2f,10f)] private float speed;

    private Rigidbody _rigidbody;
    private Vector3 movementInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CalculateMovementInput();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }
    private void CalculateMovementInput()
    {
        Vector2 input = InputManager.Instance.GetMovementVectorNormalized();
        movementInput = new Vector3(input.x, 0f, input.y);
    }

    private void ApplyMovement()
    {   
        _rigidbody.velocity = movementInput * speed;
    }
}
