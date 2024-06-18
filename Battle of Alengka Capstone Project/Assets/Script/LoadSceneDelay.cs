using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadSceneDelay : MonoBehaviour
{

    [Header("Main Settings")]
    public string TargetScene;
    public float Delay;
    VideoPlayer player;

    void LoadScene()
    {
        Time.timeScale = 1.0f;
        //Melakukan perpindahan antar scene. Catatan: Scene yang dipanggil sudah didaftarkan di Build Setting
        SceneManager.LoadScene(TargetScene);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<VideoPlayer>();
        if(player != null)
        {
            if(GameManager.instance != null)
            {
                player.SetDirectAudioVolume(0, GameManager.instance.volmsc);

            }
            else
            {
                player.SetDirectAudioVolume(0,1);
            }
        }
        Invoke("LoadScene", Delay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void skip(){
        SceneManager.LoadScene(TargetScene);
    }
}
