using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAvatar : MonoBehaviour
{
    public Type ownType;

    [SerializeField] private Element ownElement;

    // Start is called before the first frame update
    void Start()
    {
        ownElement = new Element(ownType);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerAvatar player = collision.gameObject.GetComponent<PlayerAvatar>();
            if (ownElement < player.playerElement)
            {
                player.ChangeElement(ownElement);
                Destroy(gameObject);
            }
        }
    }
}
