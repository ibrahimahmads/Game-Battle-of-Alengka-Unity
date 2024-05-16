using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Cont : MonoBehaviour
{
    public Transform playerSpawnPointLeft;
    public Transform playerSpawnPointRight;

    void Start()
    {
        if (GameManager.instance.spawnPointDirection == "left")
        {
            GameManager.instance.playerSpawnPoint = playerSpawnPointLeft;
            //GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawnPointLeft.position;
            GameManager.instance.RespawnPlayer();
        }
        else if (GameManager.instance.spawnPointDirection == "right")
        {
            GameManager.instance.playerSpawnPoint = playerSpawnPointRight;
            //GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawnPointRight.position;
            GameManager.instance.RespawnPlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
