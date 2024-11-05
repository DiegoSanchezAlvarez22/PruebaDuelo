using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] PlayerInput _input;

    private InputAction _walk;
    private InputAction _jump;

    [SerializeField] private Vector2 _direction;

    Rigidbody _rb;

    [SerializeField] private float _movSpeed;
    [SerializeField] private float _jumpForce;

    private void Awake()
    {
        _walk = _input.actions["Walk"];
        _jump = _input.actions["Jump"];

        _rb = this.gameObject.GetComponent<Rigidbody>();
    }

    private void inputEnabled()
    {
        _jump.started += Jump;
        _jump.performed += Jump;
        _jump.canceled += Jump;
    }

    private void inputDisabled()
    {
        _jump.started -= Jump;
        _jump.performed -= Jump;
        _jump.canceled -= Jump;
    }

    private void Update()
    {
        _direction = _walk.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2 (_direction.x * _movSpeed, _rb.velocity.y);
    }

    void Jump(InputAction.CallbackContext context)
    {
        _rb.AddForce(new Vector2(0, _jumpForce));
        Debug.Log(context.phase);
    }
}
