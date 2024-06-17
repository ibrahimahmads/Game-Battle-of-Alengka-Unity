using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Scene3Cont : MonoBehaviour
{
    public GameObject achievement3;
    public GameObject position3;

    public GameObject dialogPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.achievement[3] != true)
            {
                Instantiate(achievement3, position3.transform.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogPanel.activeSelf == true)
        {
            GameManager.instance.UnlockNextLevel(3);
        }
    }
}
