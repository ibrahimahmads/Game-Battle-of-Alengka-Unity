using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public int health;

    public float cdAttack;
    public float arrowFixedSpeed;
    public float maxTimeChrg;
    public float speedModifier;

    [Header("I-frame")]
    SpriteRenderer color;
    private Color originalColor;
    public float invincibilityDur;
    float currentInvincibility;
    bool isInvincible;
    public GameOverManager gameOverManager;

    private void Start()
    {
        color = GetComponent<SpriteRenderer>();
        originalColor = color.color;
    }
    private void Update()
    {
        Invincible();
    }
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            currentInvincibility = invincibilityDur;
            isInvincible = true;
            if (health <= 0)
            {
                Kill();
            }
        }

    }
    public void Kill()
    {
        Debug.Log("die");
        gameOverManager.ShowGameOver();
        Destroy(gameObject);
    }

    void Invincible()
    {
        if (currentInvincibility > 0)
        {
            currentInvincibility -= Time.deltaTime;
            ChangeOp();
        }
        else if (isInvincible)
        {
            isInvincible = false;
            color.color = originalColor;
        }
    }

    void ChangeOp()
    {
        Color newColor = originalColor;
        newColor.a = 0.5f; // Mengatur alpha menjadi 0 untuk membuatnya transparan
        color.color = newColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
            TakeDamage(3);
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Achievement" )&& Input.GetKeyDown(KeyCode.F))
        {
            Destroy(collision.gameObject);
        }
    }

}
