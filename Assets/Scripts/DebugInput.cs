using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour
{
    public GameObject playerPrefab;

    public bool OnDebugEnemySpawn()
    {
        return Input.GetButtonDown("Fire3");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            OnDebugPlayerRespawn();
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }

    public void OnDebugPlayerRespawn()
    {
        if (!FindObjectOfType<PlayerAvatar>())
            Instantiate(playerPrefab);
    }
}
