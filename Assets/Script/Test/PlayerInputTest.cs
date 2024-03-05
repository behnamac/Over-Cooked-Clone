using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputTest : MonoBehaviour
{
    [SerializeField] private InputReaderTest input;
    [SerializeField] private float force = 2;
    [SerializeField] private float speed = 2;
    private Rigidbody rb;
    private Vector3 previewsMovement;

    private void OnEnable()
    {
        input.OnJumpEvent += Jumping;
        input.OnMoveEvent += HandleMoving;
    }

    private void OnDisable()
    {
        input.OnJumpEvent -= Jumping;
        input.OnMoveEvent -= HandleMoving;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }


    private void Jumping(bool isJump)
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);

    }

    private void HandleMoving(Vector2 value)
    {
        previewsMovement = value;
    }

    private void Movement()
    {
        Vector3 inputValue = new Vector3(previewsMovement.x, 0, previewsMovement.y) * speed * Time.deltaTime;
        rb.AddForce(-inputValue, ForceMode.Impulse);
    }









}
