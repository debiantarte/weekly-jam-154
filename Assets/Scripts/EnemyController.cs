using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class EnemyController : MonoBehaviour, IInputSource
{
    public Transform player;
    [SerializeField] private float changeDestinationInterval = 2.0f;
    private float changeDestinationTimer = 0.0f;
    [SerializeField] private float maxDeviation = 3.0f;
    [SerializeField] private float triggerDistance = 6.0f;
    [SerializeField] private float attackDistance = 3.0f;

    private Vector3 randomDestination;
    [SerializeField] private float destinationReachedThreshold = 0.01f;

    private Vector2 moveDirection = Vector2.zero;

    [SerializeField] private float attackInvterval = 2.0f;
    private float attackTimer = 0.0f;

    private void Start()
    {
        FindPlayer();
    }

    public Vector2 OnMove()
    {
        if (player)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= triggerDistance)
            {
                return (moveDirection = player.position - transform.position).normalized;
            }
            else
            {
                return (moveDirection = RandomMove()).normalized;
            }
        }
        else
        {
            FindPlayer();
            return (moveDirection = RandomMove()).normalized;
        }
    }

    public Vector2? OnAttack()
    {
        if (attackTimer >= attackInvterval)
        {
            attackTimer = 0.0f;
            return moveDirection;
        }
        else
        {
            return null;
        }
    }

    private void FindPlayer()
    {
        PlayerAvatar newPlayer = FindObjectOfType<PlayerAvatar>();
        player = (newPlayer) ? newPlayer.transform : null;
    }

    private Vector2 RandomMove()
    {
        float distance = Vector3.Distance(transform.position, randomDestination);
        return (distance > destinationReachedThreshold) ? (randomDestination - transform.position) : Vector3.zero;
    }

    private void Update()
    {
        if (changeDestinationTimer >= changeDestinationInterval)
        {
            ChangeDestination();
            changeDestinationTimer = 0.0f;
        }
        else
        {
            changeDestinationTimer += Time.deltaTime;
        }
        if (player && Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            attackTimer += Time.deltaTime;
        }

    }

    private void ChangeDestination()
    {
        randomDestination.x = Random.Range(transform.position.x - maxDeviation, transform.position.x + maxDeviation);
        randomDestination.y = Random.Range(transform.position.y - maxDeviation, transform.position.y + maxDeviation);
    }

    
}
