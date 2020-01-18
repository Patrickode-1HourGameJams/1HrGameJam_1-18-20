using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDetection : MonoBehaviour
{
    public GameObject player;
    public GameObject deathPlane;

    void Update()
    {
        if (player.transform.position.y <= deathPlane.transform.position.y)
        {
            Destroy(player);
        }
    }
}