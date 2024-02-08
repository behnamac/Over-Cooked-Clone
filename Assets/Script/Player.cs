using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3;

    private void Update()
    {
        LegacyMovement();
    }

    private void LegacyMovement()
    {
        Vector2 currentPos = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            currentPos.y = -1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            currentPos.y = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentPos.x = 1;

        }
        if (Input.GetKey(KeyCode.D))
        {
            currentPos.x = -1;
        }
        currentPos = currentPos.normalized;
        var moveDir = new Vector3(currentPos.x, 0, currentPos.y);
        transform.position += moveDir * speed * Time.deltaTime;
    }
}
