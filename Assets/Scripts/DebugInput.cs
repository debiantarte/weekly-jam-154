using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour
{
    public GameObject playerPrefab;

    public bool OnDebugEnemySpawn()
    {
        return Input.GetButtonDown("Fire1");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            OnDebugPlayerRespawn();
        }
    }

    public void OnDebugPlayerRespawn()
    {
        Instantiate(playerPrefab);
    }
}
