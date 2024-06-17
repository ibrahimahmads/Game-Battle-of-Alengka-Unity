using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    public GameObject[] level;
    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < GameManager.instance.currentLevel.Length; i++)
        {
            if (GameManager.instance.currentLevel[i] == true)
            {

                level[i].SetActive(true);
            }
            if (GameManager.instance.currentLevel[3] == true)
            {
                GameManager.instance.LoadScene(8);
                GameManager.instance.currentLevel[3] = false;
            }
           
        }
            

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
