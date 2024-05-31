using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeTrig : MonoBehaviour
{
    public GameObject spike;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(SceneManager.GetActiveScene().name == "Scene1")
        {
            if (collision.CompareTag("Player"))
            {
                Vector3 position = new Vector3(transform.position.x +3, transform.position.y -0.5f, transform.position.z);
                Vector3 position2 = new Vector3(transform.position.x + 5, transform.position.y-0.5f, transform.position.z);
                Instantiate(spike, position , Quaternion.identity);
                Instantiate(spike, position2, Quaternion.identity);
            }
        }else if(SceneManager.GetActiveScene().name == "Scene2")
        {
            if(collision.CompareTag("Player"))
            {
                Vector3 position = new Vector3(transform.position.x+1.4f, transform.position.y-0.2f, transform.position.z);
                Quaternion rotation = Quaternion.Euler(0, 0, 90);
                Instantiate(spike, position , rotation);
            }
        }
        
    }
}
