using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    EnemyStat stat;
    public float patrolDistance = 5f;
    public float delayTime = 2f;  // Durasi delay

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
}
