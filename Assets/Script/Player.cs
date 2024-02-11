using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private bool isWalking;
    [SerializeField] private InputReader input;
    private Vector2 previousMovementInput;


    private void OnEnable()
    {
        input.MoveAction += HandleMovement;
    }

    private void OnDisable()
    {
        input.MoveAction -= HandleMovement;
    }

    private void Update()
    {
        Movement();
    }


    public bool IsWalking()
    {
        return isWalking;
    }

    private void Movement()
    {
        var moveDir = new Vector3(previousMovementInput.x, 0, previousMovementInput.y);
        transform.position += moveDir * speed * Time.deltaTime;
        float speedRotate = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, speedRotate * Time.deltaTime);
        isWalking = moveDir != Vector3.zero;
    }

    private void HandleMovement(Vector2 value)
    {
        previousMovementInput = -value;
    }
}
