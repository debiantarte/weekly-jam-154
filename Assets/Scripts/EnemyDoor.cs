using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor : DoorAvatar
{
    public new void Die(GameObject killer)
    {
        if (killer.GetComponent<EnemySpawner>())
        {
            animator.SetTrigger("dead");
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
