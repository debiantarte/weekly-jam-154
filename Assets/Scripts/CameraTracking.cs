using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0, 0, -10);

    private void Start()
    {
        player = FindObjectOfType<PlayerAvatar>().transform;
    }

    void Update()
    {
        if (player == null)
        {
            PlayerAvatar newPlayer = FindObjectOfType<PlayerAvatar>();
            player = (newPlayer) ? newPlayer.transform : null;
        }
        else
        {
            transform.position = player.position + offset;
        }
    }
}
