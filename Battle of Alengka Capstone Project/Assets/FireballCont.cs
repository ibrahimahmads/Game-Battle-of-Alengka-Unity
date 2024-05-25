using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCont : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float destroyTime;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerStat player = collision.gameObject.GetComponent<PlayerStat>();
            player.TakeDamage(damage);
            Destroy(gameObject);

        }
       
    }
}
