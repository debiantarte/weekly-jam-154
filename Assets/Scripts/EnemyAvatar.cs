using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : MonoBehaviour
{

    public Element ownElement;

    private SpriteRenderer sprite;
    public Color neutralColor;
    public Color rockColor;
    public Color paperColor;
    public Color scissorColor;

    private void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();

        switch (ownElement.type)
        {
            case Type.Rock:
                sprite.color = rockColor;
                break;
            case Type.Paper:
                sprite.color = paperColor;
                break;
            case Type.Scissor:
                sprite.color = scissorColor;
                break;
            default:
                sprite.color = neutralColor;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerAvatar player = collision.gameObject.GetComponent<PlayerAvatar>();
            
            if (ownElement < player.playerElement)
            {
                Destroy(gameObject);
            }
            else if (ownElement > player.playerElement)
            {
                Destroy(player.gameObject);
            }
        }
    }
}
