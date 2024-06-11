using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
     public GameObject gameOverPanel;
     public GameObject pausePanel;
     public GameObject questPanel;

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        pausePanel.SetActive(false);
        if(questPanel != null){
            questPanel.SetActive(false);
        }
        
        
    }
}
