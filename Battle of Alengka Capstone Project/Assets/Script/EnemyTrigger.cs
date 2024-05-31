using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject Enemy;
    private bool hasTriggered = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!hasTriggered && collision.CompareTag("Player"))
        {
            hasTriggered = true;
            Vector3 position = new Vector3(transform.position.x +5, transform.position.y -0.5f, transform.position.z);
            Instantiate(Enemy, position , Quaternion.identity);
        }
    }
}
