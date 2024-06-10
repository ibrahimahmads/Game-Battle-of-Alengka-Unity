using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCont : MonoBehaviour
{
    public Transform destinasi;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position)>0.3f)
            {
                player.transform.position = destinasi.transform.position;
            }
        }
    }

}
