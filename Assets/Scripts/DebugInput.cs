using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour
{
    public GameObject playerPrefab;
    public Type lastPlayerType;
    public Transform lastPlayerSpawn;

    public bool OnDebugEnemySpawn()
    {
        //return Input.GetButtonDown("Fire3");
        return false;
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
        {
            GameObject player = Instantiate(playerPrefab, lastPlayerSpawn.position, Quaternion.identity);
            player.GetComponent<PlayerAvatar>().startingType = lastPlayerType;
            player.GetComponent<PlayerAvatar>().globalInput = this;
        }
    }
}
