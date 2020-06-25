using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoInput : MonoBehaviour, IInputSource
{
    private Animator animator;
    [SerializeField] private float attackInterval = 2.0f;
    private float attackTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public Vector2? OnAttack()
    {
        if (attackTimer >= attackInterval)
        {
            attackTimer = 0.0f;
            return Vector2.down;
        }
        else
            return null;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
    }

    public Vector2 OnMove()
    {
        animator.SetFloat("speed", 1);
        animator.SetFloat("X", 0);
        animator.SetFloat("Y", -1);
        return Vector2.zero;
    }


}
