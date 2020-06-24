using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    private IInputSource input;
    private Rigidbody2D rb2d;
    private BoxCollider2D bodyCollider;
    Collider2D[] attachedColliders;

    private ContactFilter2D contactFilter;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float skinWidth = 0.01f;

    private RaycastHit2D[] hitArray = new RaycastHit2D[16];

    private void Awake()
    {
        input = GetComponent<IInputSource>();
        rb2d = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
        attachedColliders = new Collider2D[rb2d.attachedColliderCount];
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
        /*Vector2 direction = Vector2.right * desiredMovement.x;
        Move(direction);
        direction = Vector2.up * desiredMovement.y;
        Move(direction);*/
        Move(desiredMovement);
    }

    public void Move(Vector2 direction)
    { 
        float distance = direction.magnitude;

        for (int col = 0; col < rb2d.GetAttachedColliders(attachedColliders); col++)
        {
            if (!attachedColliders[col].isTrigger)
            {
                // we cast each non-trigger collider in the direction of movement and handle collisions for each one
                int count = attachedColliders[col].Cast(direction, contactFilter, hitArray, distance + skinWidth);
                for (int i = 0; i < count; i++)
                {
                    float realDistance = hitArray[i].distance - skinWidth;
                    distance = (realDistance < distance) ? realDistance : distance;
                }
            }
        }
  
        rb2d.position = rb2d.position + direction * distance;
    }
}
