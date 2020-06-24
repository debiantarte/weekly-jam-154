using UnityEngine;

public interface IInputSource
{
    Vector2 OnMove();
    Vector2? OnAttack();
}
