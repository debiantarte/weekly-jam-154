using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public IAvatar owner;

    private void Start()
    {
        owner = GetComponentInParent<IAvatar>();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        IAvatar colAvatar = collision.gameObject.GetComponent<IAvatar>();
        if (colAvatar != null)
        {
            if (owner.GetElement() > colAvatar.GetElement())
            {
                colAvatar.Die(owner.GetObject());
            }
        }
    }
}
