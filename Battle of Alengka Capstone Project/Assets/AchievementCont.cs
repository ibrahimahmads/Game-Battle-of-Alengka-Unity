using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementCont : MonoBehaviour
{
    GameManager gameManager;
    public Image[] setArr;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HasBeenTaken();
    }

    void HasBeenTaken()
    {
        for (int i = 0; i < setArr.Length; i++)
        {
            Color color = setArr[i].color;
            color.a = 0;
            setArr[i].color = color;
            if (gameManager.achievement[i] == true)
            {
                color.a = 255;
                setArr[i].color = color;
            }
        }

    }
}
