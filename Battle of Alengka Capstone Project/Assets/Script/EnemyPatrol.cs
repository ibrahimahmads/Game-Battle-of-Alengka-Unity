using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    EnemyStat stat;
    public float patrolDistance = 5f;
    public float delayTime = 2f;  // Durasi delay
    private Transform player;  // Referensi ke transform pemain
    public float detectionRange = 1f;  // Jarak deteksi
    public float attackRange = 2f;  // Jarak serang
    public LayerMask playerLayer;
    private Vector2 startPosition;
    private bool movingRight = false;
    private bool isWaiting = false; // Apakah sedang menunggu
    private Animator animator;
    private bool isPaused = false;

    void Start()
    {
        startPosition = transform.position;
        stat = GetComponent<EnemyStat>();
        animator = GetComponent<Animator>();
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found. Make sure the player object has the 'Player' tag.");
        }
        //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isWaiting && !isPaused)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        float distanceToPlayer = Vector2.Distance(player.position,transform.position);
        if(distanceToPlayer > detectionRange)
        {
            if (movingRight)
            {
                transform.Translate(Vector2.right * stat.speed * Time.deltaTime);
                animator.SetBool("isWalking", true);
                if (Vector2.Distance(startPosition, transform.position) >= patrolDistance)
                {
                    StartCoroutine(WaitBeforeTurning());
                }
            }
            else
            {
                transform.Translate(Vector2.left * stat.speed * Time.deltaTime);
                animator.SetBool("isWalking", true);
                if (Vector2.Distance(startPosition, transform.position) >= patrolDistance)
                {
                    StartCoroutine(WaitBeforeTurning());
                }
            }

            FlipSprite();
        }else{
            ChasePlayer(distanceToPlayer);
        }
        
    }

    IEnumerator WaitBeforeTurning()
    {
        isWaiting = true;
        animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(delayTime);
        movingRight = !movingRight;
        startPosition = transform.position;  // Update startPosition saat berbalik
        isWaiting = false;
    }

    void FlipSprite()
    {
        // Membalik arah sprite berdasarkan arah gerakan
        Vector3 localScale = transform.localScale;
        if (movingRight)
        {
            localScale.x = -Mathf.Abs(localScale.x); // Menghadap ke kanan
        }
        else
        {
            localScale.x = Mathf.Abs(localScale.x); // Menghadap ke kiri
        }
        transform.localScale = localScale;
    }

    public void PausePatrol()
    {
        isPaused = true;
        animator.SetBool("isWalking", false); // Menghentikan animasi berjalan
    }

    public void ResumePatrol()
    {
        isPaused = false;
    }

    void ChasePlayer(float distanceToPlayer)
    {
        // Jika pemain berada dalam radius deteksi dan di sebelah kanan atau kiri musuh
        if (distanceToPlayer < detectionRange && distanceToPlayer > attackRange)
        {
            animator.SetBool("isWalking",true);
            transform.position = Vector2.MoveTowards(this.transform.position,player.position,stat.speed*Time.deltaTime);
            FlipSpriteTowardsPlayer();
            // Di sini kamu bisa menambahkan logika lain, seperti menyerang pemain jika jarak sudah cukup dekat
        }else if(distanceToPlayer <= attackRange)
        {
            StartCoroutine(AttackPlayer());
        }
    }

    IEnumerator AttackPlayer()
    {
        isWaiting = true;
        animator.SetTrigger("Attack");  // Trigger animasi serangan
        yield return new WaitForSeconds(1);
        PlayerStat playerStat = player.GetComponent<PlayerStat>();
        if (playerStat != null)
        {
            Debug.Log("Player hit!");
            playerStat.TakeDamage(stat.damage);
        }else
        {
            Debug.LogWarning("PlayerStat component not found on player.");
        }
        isWaiting = false;
    }
    void FlipSpriteTowardsPlayer()
    {
        Vector3 localScale = transform.localScale;
        if (player.position.x > transform.position.x)
        {
            localScale.x = -Mathf.Abs(localScale.x); // Menghadap ke kanan
        }
        else
        {
            localScale.x = Mathf.Abs(localScale.x); // Menghadap ke kiri
        }
        transform.localScale = localScale;
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

}
