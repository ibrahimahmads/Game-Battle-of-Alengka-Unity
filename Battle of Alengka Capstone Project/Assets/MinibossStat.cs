using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossStat : MonoBehaviour
{
    AudioManager audioManager;
    public int health;
    public int damage;
    public int speed;
    private Animator animator;
    private bool isTakingDamage = false; // Flag untuk mengecek apakah sedang dalam keadaan terkena serangan
    private EnemyPatrol enemyPatrol;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (animator != null)
        {
            animator.SetTrigger("Hurt");
        }
        if (health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
        audioManager.PlaySFX(audioManager.miniBossDie);
        // Hancurkan objek setelah animasi selesai
        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Tunggu hingga animasi Death selesai
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        Destroy(gameObject,0.3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & playerLayer) != 0)
        {
            PlayerStat player = collision.gameObject.GetComponent<PlayerStat>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
