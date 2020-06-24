using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAvatar : MonoBehaviour, IAvatar
{
    public Type ownType;

    [SerializeField] private Element ownElement;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ownElement = new Element(ownType);
        animator = GetComponent<Animator>();
    }

    public Element GetElement()
    {
        return ownElement;
    }

    public void Die(GameObject killer)
    {
        if (killer.CompareTag("Player"))
        {
            animator.SetTrigger("dead");
            PlayerAvatar player = killer.GetComponent<PlayerAvatar>();
            player.ChangeElement(ownElement);
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);

        }
    }

    public GameObject GetObject()
    {
        return gameObject;
    }

}
