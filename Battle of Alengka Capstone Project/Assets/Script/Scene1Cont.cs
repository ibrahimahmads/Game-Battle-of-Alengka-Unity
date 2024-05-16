using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Cont : MonoBehaviour
{
    public Transform playerSpawnPointRight;
    public Transform playerSpawnPointFirst;


    void Start()
    {
        if (GameManager.instance.spawnPointDirection == "right")
        {
            GameManager.instance.playerSpawnPoint = playerSpawnPointRight;
            //GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawnPointLeft.position;
            GameManager.instance.RespawnPlayer();
        }
        if (GameManager.instance.spawnPointDirection == "left")
        {
            GameManager.instance.playerSpawnPoint = playerSpawnPointFirst;
            //GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawnPointLeft.position;
            GameManager.instance.RespawnPlayer();
        }



    }
}
