using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossCont : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject fireball;
    public float cdAttack;
    float currentCD;
    public LayerMask playerLayer;
    public float distance;
    public bool playerNear;
    public Transform fireballSpawnPoint;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        CheckPlayer();
    }

    void Attack()
    {
        if (playerNear)
        {
            if (currentCD <= 0)
            {
                StartCoroutine(PerformAttack());
                currentCD = cdAttack;
            }
            else
            {
                currentCD -= Time.deltaTime;
            }
        }else{
            animator.SetBool("isAttacking", false);
        }
        
    }

    void CheckPlayer()
    {
        playerNear = Physics2D.Raycast(transform.position, Vector2.left, distance, playerLayer);
    }

    IEnumerator PerformAttack()
    {
        animator.SetBool("isAttacking", true);  // Aktifkan animasi serangan
        yield return new WaitForSeconds(0.01f);  // Tunggu sebentar untuk memastikan animasi dipicu
        Instantiate(fireball, fireballSpawnPoint.position, Quaternion.identity);
        audioManager.PlaySFX(audioManager.miniBoss);
        yield return new WaitForSeconds(0.8f);  // Tunggu lebih lama jika perlu untuk menyelesaikan animasi serangan
        animator.SetBool("isAttacking", false);  // Nonaktifkan animasi serangan setelah animasi selesai
    }
}
