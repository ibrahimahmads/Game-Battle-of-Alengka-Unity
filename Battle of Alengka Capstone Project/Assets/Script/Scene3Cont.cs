using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Cont : MonoBehaviour
{
    public Transform playerSpawnPoint;


    void Start()
    {
        if (GameManager.instance.spawnPointDirection == "right")
        {
            GameManager.instance.playerSpawnPoint = playerSpawnPoint;
            //GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawnPointLeft.position;
            GameManager.instance.RespawnPlayer();
        }
        if (GameManager.instance.spawnPointDirection == "left")
        {
            GameManager.instance.playerSpawnPoint = playerSpawnPoint;
            //GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawnPointLeft.position;
            GameManager.instance.RespawnPlayer();
        }



    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.playerSpawnPoint = playerSpawnPoint;
            GameManager.instance.spawnPointDirection = "left";
            GameManager.instance.LoadScene(2);
        }
    }
}
