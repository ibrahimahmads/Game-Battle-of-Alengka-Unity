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
    public bool[] achievement = new bool[4];
    public bool[] currentLevel = new bool[4];

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

        currentLevel[0] = true;
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

    public void UnlockNextLevel(int value)
    {
        currentLevel[value] = true;
    }
}
