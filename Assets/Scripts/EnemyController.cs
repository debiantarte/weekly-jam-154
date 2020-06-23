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

    private Vector3 randomDestination;
    [SerializeField] private float destinationReachedThreshold = 0.01f;

    private void Start()
    {
        player = FindObjectOfType<PlayerAvatar>().transform;
    }

    public Vector2 OnMove()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= triggerDistance)
            {
                return (player.position - transform.position).normalized;
            }
            else
            {
                return RandomMove();
            }
        }
        else
        {
            PlayerAvatar newPlayer = FindObjectOfType<PlayerAvatar>();
            player = (newPlayer) ? newPlayer.transform : null;
            return RandomMove();
        }
    }

    private Vector2 RandomMove()
    {
        float distance = Vector3.Distance(transform.position, randomDestination);
        return (distance > destinationReachedThreshold) ? (randomDestination - transform.position).normalized : Vector3.zero;
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
    }

    private void ChangeDestination()
    {
        randomDestination.x = Random.Range(transform.position.x - maxDeviation, transform.position.x + maxDeviation);
        randomDestination.y = Random.Range(transform.position.y - maxDeviation, transform.position.y + maxDeviation);
    }

    
}
