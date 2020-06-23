using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour, IInputSource
{
    public Vector2 MoveDirection = Vector2.zero;

    public Vector2 OnMove()
    {
        MoveDirection.x = Input.GetAxis("Horizontal");
        MoveDirection.y = Input.GetAxis("Vertical");

        return MoveDirection.normalized;
    }

    
}
