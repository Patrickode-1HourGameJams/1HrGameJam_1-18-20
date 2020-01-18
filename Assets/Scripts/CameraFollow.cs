using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 playerPos;
    private Vector3 camOffset;

    private void Start()
    {
        playerPos = player.transform.position;
        camOffset = transform.position - playerPos;
    }

    void Update()
    {
        if (player)
        {
            playerPos = player.transform.position;

            transform.position = new Vector3(playerPos.x, playerPos.y + camOffset.y, playerPos.z + camOffset.z);
            transform.LookAt(player.transform);
        }
    }
}
