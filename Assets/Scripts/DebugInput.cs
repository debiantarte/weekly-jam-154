﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetButtonDown("Fire2") && lastPlayerSpawn)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reset level completely
        /*
        if (!FindObjectOfType<PlayerAvatar>())
        {
            GameObject player = Instantiate(playerPrefab, lastPlayerSpawn.position, Quaternion.identity);
            player.GetComponent<PlayerAvatar>().startingType = lastPlayerType;
            player.GetComponent<PlayerAvatar>().globalInput = this;
        }
        */
    }
}
