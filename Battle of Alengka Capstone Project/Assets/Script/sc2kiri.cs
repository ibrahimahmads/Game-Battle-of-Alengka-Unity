using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc2kiri : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.spawnPointDirection = "right";
            GameManager.instance.LoadScene(0);
        }
    }
}
