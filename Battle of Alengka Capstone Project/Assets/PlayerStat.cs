using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    LifeCount m_LifeCount;
    GameManager m_GameManager;

    public float speed;
    public float jumpPower;
    public int health;

    public float cdAttack;
    public float arrowFixedSpeed;
    public float maxTimeChrg;
    public float maxArrowSpeed;

    [Header("I-frame")]
    SpriteRenderer color;
    private Color originalColor;
    public float invincibilityDur;
    float currentInvincibility;
    bool isInvincible;
    public GameOverManager gameOverManager;

    private Camera mainCam;
    public Vector3 mousePos;
    private Vector3 dir;

    private void Start()
    {
        color = GetComponent<SpriteRenderer>();
        originalColor = color.color;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        m_LifeCount = FindObjectOfType<LifeCount>();
        m_LifeCount.life = health;
        m_GameManager = FindAnyObjectByType<GameManager>();
    }
    private void Update()
    {
        Invincible();
        MouseCheck();

    }


    
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            m_LifeCount.LifeDecrease();
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
            AchievementBase1 achievement = collision.GetComponent<AchievementBase1>();
            if(achievement != null)
            {
                achievement.Unlock();
            }
            
        }
    }

    void MouseCheck()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePos - transform.position;
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.localScale = gameObject.transform.localScale;
    }

}
