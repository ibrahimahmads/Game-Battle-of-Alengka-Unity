using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossCont : MonoBehaviour
{
    public GameObject fireball;
    public float cdAttack;
    float currentCD;
    public LayerMask playerLayer;
    public float distance;
    public bool playerNear;
    // Start is called before the first frame update
    void Start()
    {
        
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
                Instantiate(fireball, transform.position, Quaternion.identity);
                currentCD = cdAttack;
            }
            else
            {
                currentCD -= Time.deltaTime;
            }
        }
        
    }

    void CheckPlayer()
    {
        playerNear = Physics2D.Raycast(transform.position, Vector2.left, distance, playerLayer);
    }
}
