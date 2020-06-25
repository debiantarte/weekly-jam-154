using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public bool IsLevelExit;
    public string NextScene;
    public Transform Destination;
    public GameObject[] ToDisable;
    public GameObject[] ToEnable;
    public DebugInput input;

    private void Start()
    {
        if (!input)
        {
            input = FindObjectOfType<DebugInput>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (IsLevelExit)
            {
                SceneManager.LoadScene(NextScene);
            }
            else
            {
                foreach (GameObject obj in ToDisable)
                {
                    obj.SetActive(false);
                }
                collision.gameObject.transform.position = Destination.position;
                input.lastPlayerSpawn = Destination;
                foreach (GameObject obj in ToEnable)
                {
                    obj.SetActive(true);
                }
            }
        }
    }
}
