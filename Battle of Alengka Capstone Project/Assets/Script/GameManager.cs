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
    public bool achievement1 = false;
    public bool achievement2 = false;
    public bool achievement3 = false;
    public bool[] achievement = new bool[3];

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
        achievement[0] = achievement1;
        achievement[1] = achievement2;
        achievement[2] = achievement3;
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
