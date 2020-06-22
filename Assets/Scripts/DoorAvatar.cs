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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerAvatar player = collision.gameObject.GetComponent<PlayerAvatar>();
            Debug.Log("door of type : " + ownElement.type + " attacked by player of type : " + player.playerElement.type);
            if (ownElement < player.playerElement)
            {
                Debug.Log("player won");
                player.ChangeElement(ownElement);
                Destroy(gameObject);
            }
        }
    }
}
