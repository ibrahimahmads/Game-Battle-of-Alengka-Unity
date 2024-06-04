using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Cont : MonoBehaviour
{
    public GameObject achievement1;
    public GameObject position1;

    void Start()
    {
        if(GameManager.instance != null)
        {
            if(GameManager.instance.achievement1 != true)
            {
                Instantiate(achievement1, position1.transform.position,Quaternion.identity);
            }
        }
    }
}
