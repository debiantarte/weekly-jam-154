using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : MonoBehaviour, IAvatar
{

    public Element ownElement;
    public Type ownType;
    public EnemySpawner spawner;

    private SpriteRenderer sprite;

    private void Start()
    {
        if (ownType > 0) ownElement = new Element(ownType);
        sprite = GetComponentInChildren<SpriteRenderer>();
        
    }

    public void UpdateColor()
    {
        /* DEPRECATED
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
        */
    }

    public Element GetElement()
    {
        return ownElement;
    }

    public void Die(GameObject killer)
    {
        if (spawner != null) spawner.killCount++;
        Destroy(gameObject);
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}
