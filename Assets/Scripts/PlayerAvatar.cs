using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAvatar : MonoBehaviour, IAvatar
{
    private Element playerElement;

    private SpriteRenderer sprite;

    private Animator animator;

    public Sprite RockWeapon;
    public Sprite PaperWeapon;
    public Sprite ScissorWeapon;

    [SerializeField] private SpriteRenderer WeaponSprite;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponentInChildren<Animator>();
        playerElement = new Element(Type.Rock);
        sprite = GetComponentInChildren<SpriteRenderer>();
        UpdateColor();
    }

    // Update is called once per frame
    public void UpdateColor()
    {
        switch (playerElement.type)
        {
            case Type.Rock:
                animator.SetInteger("element", 1);
                WeaponSprite.sprite = RockWeapon;
                break;
            case Type.Paper:
                animator.SetInteger("element", 2);
                WeaponSprite.sprite = PaperWeapon;
                break;
            case Type.Scissor:
                animator.SetInteger("element", 3);
                WeaponSprite.sprite = ScissorWeapon;
                break;
            default:
                Debug.LogError("Unrecognized element on player!");
                break;
        }
            
    }

    public void ChangeElement(Element newElement)
    {
        playerElement = newElement;
        UpdateColor();
    }

    public Element GetElement()
    {
        return playerElement;
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
