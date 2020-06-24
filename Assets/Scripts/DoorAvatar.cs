using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAvatar : MonoBehaviour, IAvatar
{
    public Type ownType;

    [SerializeField] private Element ownElement;

    // Start is called before the first frame update
    void Start()
    {
        ownElement = new Element(ownType);
    }

    public Element GetElement()
    {
        return ownElement;
    }

    public void Die(GameObject killer)
    {
        if (killer.CompareTag("Player"))
        {
            PlayerAvatar player = killer.GetComponent<PlayerAvatar>();
            player.ChangeElement(ownElement);
            Destroy(gameObject);
        }
    }

    public GameObject GetObject()
    {
        return gameObject;
    }

}
