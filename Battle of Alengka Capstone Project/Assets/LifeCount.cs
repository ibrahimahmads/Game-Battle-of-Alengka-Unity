using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeCount : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public int life;
    PlayerStat player;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        player = FindAnyObjectByType<PlayerStat>();
    }
    private void Update()
    {
        CheckHealth();
    }

    public void LifeDecrease()
    {
        life--;
        scoreText.text = " X " + life;
    }

    public void CheckHealth()
    {
        life = player.health;
        scoreText.text = " X " + life;
    }
}
