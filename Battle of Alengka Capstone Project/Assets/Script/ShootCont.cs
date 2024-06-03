using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.Mathematics;
using UnityEngine;

public class ShootCont : MonoBehaviour
{
    AudioManager audioManager;
    PlayerStat stat;
    Player_Mov playerMov;
    public GameObject arrow;
    public Transform Bow;
    public float arrowSpeed;
    public float timeChrg =0.0f;
    float currentCD;
    private bool chrg = false;
    private bool att = false;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        currentCD = 0;
        stat = GetComponent<PlayerStat>();
        playerMov = GetComponent<Player_Mov>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    { 
        Attack();
    }

    void Attack()
    {
        if (!playerMov.isgrounded) return;
        currentCD -= Time.deltaTime;
        if(currentCD <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCharging();
            }
            if (Input.GetButton("Fire1") && chrg)
            {
                Charging();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                if(chrg)
                {
                    att = true;
                    animator.SetTrigger("LepasPanah");
                }
                chrg = false;
                animator.SetBool("TahanPanah", false);
                animator.SetBool("TahanPanahMove", false);
            }

            if(att)
            {
                if(timeChrg>= 1)
                {
                    ChargedAtt();
                    audioManager.PlaySFX(audioManager.panah);
                }else{
                    RegularShoot();
                    audioManager.PlaySFX(audioManager.panah);
                }

                att = false;
                currentCD = stat.cdAttack;
            }
        }
    }

    void StartCharging()
    {
        timeChrg = 0f;
        chrg = true;
        arrowSpeed = stat.arrowFixedSpeed;
        animator.SetTrigger("TakeBow");
    }

    void Charging()
    {
        timeChrg += Time.deltaTime;
            
        if (timeChrg > stat.maxTimeChrg)
        {
            timeChrg = stat.maxTimeChrg;
        }
        animator.SetBool("TahanPanah", true);
    }

    void RegularShoot()
    {
        float speed = stat.arrowFixedSpeed;
        FireArrow(speed);
    }

    void ChargedAtt()
    {
        float speed = stat.arrowFixedSpeed * 2;
        FireArrow(speed);
    }

    public void FireArrow(float speed)
    {
        if (arrow != null && Bow != null)
        {
            GameObject newArrow = Instantiate(arrow, Bow.position, Quaternion.identity);
            ArrowCont arrowCont = newArrow.GetComponent<ArrowCont>();
            if (arrowCont != null)
            {
                arrowCont.Initialize(MouseCheck(), speed);
            }
            // Tambahkan kecepatan ke anak panah
            Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                 if (transform.localScale.x > 0) // Character is facing right
                {
                    rb.velocity = transform.right * speed; // Untuk arah ke kanan
                }
                else 
                {
                    rb.velocity = -transform.right * speed; // Untuk arah ke kiri
                }
            }
        }
    }
    Vector3 MouseCheck()
    {
        Vector3 mouseP = stat.mousePos;
        return mouseP;
    }

    void UpdateMovementAnimation()
    {
        if (chrg)
        {
            if (animator != null)
            {
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    animator.SetBool("TahanPanahMove", true);
                }
                else
                {
                    animator.SetBool("TahanPanahMove", false);
                }
            }
        }
    }

}