using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    private IInputSource input;
    private Rigidbody2D rb2d;
    private BoxCollider2D bodyCollider;

    private ContactFilter2D contactFilter;

    [SerializeField] private float minMoveDistance = 0.001f;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float skinWidth = 0.01f;

    private RaycastHit2D[] hitArray = new RaycastHit2D[16];

    private void Awake()
    {
        input = GetComponent<IInputSource>();
        rb2d = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
    }
    
    void Start()
    {

        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }
    
    void FixedUpdate()
    {
        Vector2 desiredMovement = input.OnMove() * speed * Time.fixedDeltaTime;
        Vector2 direction = Vector2.right * desiredMovement.x;
        Move(direction);
        direction = Vector2.up * desiredMovement.y;
        Move(direction);
    }

    public void Move(Vector2 direction)
    { 
        float distance = direction.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(direction, contactFilter, hitArray, distance + skinWidth);
            for (int i = 0; i < count; i++)
            {
                float realDistance = hitArray[i].distance - skinWidth;
                distance = (realDistance < distance) ? realDistance : distance;
            }
        }
      
      rb2d.position = rb2d.position + direction * distance;
    }
}
