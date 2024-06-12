using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KijangCont : MonoBehaviour
{
    public LayerMask player;
    bool PlayerNear;
    public float distancePlayer;
    public float speed;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    void PlayerCheck()
    {
        PlayerNear = Physics2D.Raycast(transform.position, Vector2.left, distancePlayer, player);
    }

    void Run()
    {
        PlayerCheck();
        if(PlayerNear == true)
        {
            transform.Translate(new Vector2(1,0) * speed * Time.deltaTime);
            animator.SetBool("Near", true);
        }
        else
        {
            animator.SetBool("Near",false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
