using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Cont : MonoBehaviour
{
    public GameObject achievement2;
    public GameObject position2;

    public GameObject dialogPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.achievement[1] != true)
            {
                Instantiate(achievement2, position2.transform.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogPanel.activeSelf == true)
        {
            GameManager.instance.UnlockNextLevel(2);
        }
    }
}
