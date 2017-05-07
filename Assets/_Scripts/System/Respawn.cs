using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour{

    [SerializeField]
    private GameObject player;

    void OnTriggerEnter2D()
    {
            if (player.GetComponent<PlayerHealth>().respawnPoint != null)
            {
                player.GetComponent<PlayerHealth>().respawnPoint.GetChild(0).gameObject.SetActive(false);
            }
            transform.GetChild(0).gameObject.SetActive(true);
            player.GetComponent<PlayerHealth>().respawnPoint = transform;
            
    }
}
