using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAvatar : MonoBehaviour
{
    // pregenerating elements, because we will change elements a lot
    private readonly Element Rock = new Element(Type.Rock);
    private readonly Element Paper = new Element(Type.Paper);
    private readonly Element Scissor = new Element(Type.Scissor);
    private readonly Element Neutral = new Element(Type.Neutral);

    public Element playerElement;

    private SpriteRenderer sprite;
    public Color neutralColor;
    public Color rockColor;
    public Color paperColor;
    public Color scissorColor;


    // Start is called before the first frame update
    void Start()
    {
        playerElement = Rock;
        sprite = GetComponentInChildren<SpriteRenderer>();
        UpdateColor();
    }

    // Update is called once per frame
    void UpdateColor()
    {
        switch (playerElement.type)
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

    public void ChangeElement(Element newElement)
    {
        playerElement = newElement;
        UpdateColor();
    }
}
