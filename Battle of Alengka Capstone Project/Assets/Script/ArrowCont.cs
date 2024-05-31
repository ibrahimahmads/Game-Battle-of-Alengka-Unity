using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCont : MonoBehaviour
{
    ShootCont shootCont;
    float arrowSpeed;
    Vector3 dir;
    Vector3 direction;
    
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        shootCont = FindFirstObjectByType<ShootCont>();
        arrowSpeed = shootCont.arrowSpeed;
        //rb.velocity = direction * arrowSpeed;
        ;
        Debug.Log("Direction:" + direction);
        Debug.Log("arrowspeed:" + arrowSpeed);
    }
    private void Awake()
    {

        Destroy(gameObject, 1);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += direction * arrowSpeed * Time.deltaTime;
        //CheckAngle();
    }

   

    public void DirectionCheck(Vector3 mouseP)
    {
          
          dir = mouseP - transform.position;
    //    float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0, 0, rotZ);
           direction = new Vector3(dir.x, 0).normalized;
    }



    //void CheckAngle()
    //{
    //    Vector2 direcction = rb.velocity;
    //    float angle = Mathf.Atan2(direcction.y, direcction.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyStat enemy = collision.gameObject.GetComponent<EnemyStat>();
            enemy.TakeDamage(damage);
            
        }
        Destroy(gameObject);
    }

}
