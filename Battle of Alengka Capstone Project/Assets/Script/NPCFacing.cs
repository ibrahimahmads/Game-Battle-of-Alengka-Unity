using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFacing : MonoBehaviour
{
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        //if player left to enemy then scale =1 
        if(Player != null)
        if(Player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        //if player right to enemy then scale = -1 
        if(Player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
    }
}
