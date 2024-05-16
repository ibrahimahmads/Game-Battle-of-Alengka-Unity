using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform playerSpawnPoint;
    public string spawnPointDirection = "left";
    public GameObject Player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); 
    }

    public void RespawnPlayer()
    {
        //GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawnPoint.position;
        Instantiate(Player, playerSpawnPoint.position, Quaternion.identity);
    }
}
