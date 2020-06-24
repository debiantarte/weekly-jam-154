using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Weapon
{
    private Rigidbody2D rb2d;
    [SerializeField] private float lifetime = 2.0f;

    private void Start()
    {
        owner = FindObjectOfType<PlayerAvatar>();
        Destroy(gameObject, lifetime);
    }

    protected new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Destroy(gameObject);
    }
}
