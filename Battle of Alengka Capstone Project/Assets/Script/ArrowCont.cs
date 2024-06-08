using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCont : MonoBehaviour
{
    float arrowSpeed;
    Vector3 dir;
    Vector3 direction;
    public int damage;
    private void Awake()
    {
        Destroy(gameObject, 0.3f);
    }
    void Update()
    {
        transform.position += direction * arrowSpeed * Time.deltaTime;
    }
    public void Initialize(Vector3 mouseP, float speed)
    {
        arrowSpeed = speed;
        direction = (mouseP - transform.position).normalized;
        direction.y = 0; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger")||collision.CompareTag("SecretRoom") )
        {
            return;
        }
        if (collision.CompareTag("Enemy"))
        {
            EnemyStat enemy = collision.gameObject.GetComponent<EnemyStat>();
            enemy.TakeDamage(damage);
            
        }
        if (collision.CompareTag("Boss"))
        {
            MinibossStat boss = collision.gameObject.GetComponent<MinibossStat>();
            boss.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
