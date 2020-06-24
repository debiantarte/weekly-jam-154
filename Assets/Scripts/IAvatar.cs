using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAvatar
{
    Element GetElement();
    void Die(GameObject killer);
    GameObject GetObject();
}
