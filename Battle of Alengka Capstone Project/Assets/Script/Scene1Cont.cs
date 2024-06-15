using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Cont : MonoBehaviour
{
    public GameObject achievement1;
    public GameObject position1;

    public GameObject tutorialPanel;
    public Image image1;
    public Image image2;
    private int currentImageIndex = 0;

    ShootCont shoot_player;

    void Start()
    {
        shoot_player = FindAnyObjectByType<ShootCont>();
        // Set gambar pertama aktif dan gambar kedua tidak aktif
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(false);

        // Tampilkan panel tutorial
        tutorialPanel.SetActive(true);

        if (GameManager.instance != null)
        {
            if (GameManager.instance.achievement[0] != true)
            {
                Instantiate(achievement1, position1.transform.position, Quaternion.identity);
            }
        }
        if(shoot_player != null)
        {
            shoot_player.enabled = false;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Mengecek klik kiri mouse
        {
            currentImageIndex++;
            if (currentImageIndex == 1)
            {
                // Gambar pertama sudah ditampilkan, sekarang tampilkan gambar kedua
                image1.gameObject.SetActive(false);
                image2.gameObject.SetActive(true);
            }
            else if (currentImageIndex == 2)
            {
                // Gambar kedua sudah ditampilkan, sekarang mulai permainan
                StartGame();
            }
        }
    }
    void StartGame()
    {
        // Sembunyikan panel tutorial
        tutorialPanel.SetActive(false);
        shoot_player.enabled = true;

        // Mulai permainan, misalnya dengan memuat scene baru atau mengaktifkan objek permainan
        // SceneManager.LoadScene("NamaScenePermainan"); // Contoh jika ingin memuat scene baru
    }
}
