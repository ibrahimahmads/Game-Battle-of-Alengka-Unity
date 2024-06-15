using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KijangCont : MonoBehaviour
{
    public LayerMask player;
    bool PlayerNear;
    bool runs;
    public float distancePlayer;
    public float speed;
    public float lastPosition;

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
        if(PlayerNear == true)
        {
            runs = true;
        }
    }

    void Run()
    {
        PlayerCheck();
        if(runs == true && transform.position.x< lastPosition)
        {
            transform.Translate(new Vector2(1,0) * speed * Time.deltaTime);
            animator.SetBool("Near", true);
        }
        else
        {
            animator.SetBool("Near",false);
        }
    }

    
}
