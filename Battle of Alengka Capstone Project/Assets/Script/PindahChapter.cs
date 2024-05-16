using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahChapter : MonoBehaviour
{
    public void pindahChapter1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void pindahChapter2()
    {
        SceneManager.LoadScene("Scene2");
    }
    
    public void pindahChapter3()
    {
        SceneManager.LoadScene("Scene3");
    }
}
