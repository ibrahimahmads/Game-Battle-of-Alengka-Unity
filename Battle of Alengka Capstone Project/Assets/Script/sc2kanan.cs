using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc2kanan : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.spawnPointDirection = "left";
            GameManager.instance.LoadScene(2);
        }
    }
}
