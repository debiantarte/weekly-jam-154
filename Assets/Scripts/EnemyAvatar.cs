using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : MonoBehaviour, IAvatar
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
        //UpdateColor();
    }

    public void UpdateColor()
    {
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

    public Element GetElement()
    {
        return ownElement;
    }

    public void Die(GameObject killer)
    {
        Destroy(gameObject);
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}
