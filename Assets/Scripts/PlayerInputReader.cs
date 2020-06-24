using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour, IInputSource
{
    private Vector2 lastMoveDirection = Vector2.zero;
    private Vector2 inputDirection = Vector2.zero;
    [SerializeField] private float minMoveDistance = 0.001f;

    public Vector2 OnMove()
    {
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.y = Input.GetAxis("Vertical");

        if (inputDirection.magnitude >= minMoveDistance)
        {
            lastMoveDirection = inputDirection.normalized;
            return inputDirection.normalized;
        }
        else
        {
            return Vector2.zero;
        }
    }

    public Vector2? OnAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            return lastMoveDirection;
        }
        else
        {
            return null;
        }
    }
}
