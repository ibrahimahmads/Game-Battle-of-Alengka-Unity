using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahChapter : MonoBehaviour
{
    private void UnpauseGame()
    {
        Time.timeScale = 1.0f;  // Mengatur waktu berjalan normal
        // Pastikan pause menu UI disembunyikan jika ada
        // pauseMenuUI.SetActive(false);
    }
    public void pindahChapter1()
    {
        UnpauseGame();
        SceneManager.LoadScene("Scene1");
    }

    public void pindahChapter2()
    {
        UnpauseGame();
        SceneManager.LoadScene("Scene2");
    }
    
    public void pindahChapter3()
    {
        UnpauseGame();
        SceneManager.LoadScene("Scene3");
    }
}
