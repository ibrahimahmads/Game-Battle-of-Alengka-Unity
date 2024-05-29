using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public int health;
    public int damage;
    public int speed;
    private Animator animator;
    private bool isTakingDamage = false; // Flag untuk mengecek apakah sedang dalam keadaan terkena serangan
    private bool isDead = false;
    private EnemyPatrol enemyPatrol;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyPatrol = GetComponent<EnemyPatrol>();
    }

    // Update is called once per frame
    void Update()
    {

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
        }else
        {
            if (!isTakingDamage)
            {
                StartCoroutine(HandleDamage());
            }
        }
    }

     private IEnumerator HandleDamage()
    {
        isTakingDamage = true;
        if (enemyPatrol != null)
        {
            enemyPatrol.PausePatrol(); // Menghentikan patrol sementara
        }

        // Tunggu hingga animasi Hurt selesai
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        if (enemyPatrol != null)
        {
            enemyPatrol.ResumePatrol(); // Melanjutkan patrol
        }
        isTakingDamage = false;
    }

    public void Kill()
    {
        isDead = true; // Set flag isDead menjadi true
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
        
        // Menghentikan semua logika enemy
        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = false;
        }

        // Hancurkan objek setelah animasi selesai
        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Tunggu hingga animasi Death selesai
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        Destroy(gameObject,0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            PlayerStat player = collision.gameObject.GetComponent<PlayerStat>();
            player.TakeDamage(damage);
        }
    }
}
