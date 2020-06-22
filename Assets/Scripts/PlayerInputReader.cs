using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputReader : MonoBehaviour, IInputSource
{
    public Vector2 MoveDirection = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 OnMove()
    {
        MoveDirection.x = Input.GetAxis("Horizontal");
        MoveDirection.y = Input.GetAxis("Vertical");
        MoveDirection.Normalize();

        return MoveDirection;
    }
}
