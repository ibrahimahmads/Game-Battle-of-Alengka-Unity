using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.Mathematics;
using UnityEngine;

public class ShootCont : MonoBehaviour
{

    PlayerStat stat;
    public GameObject arrow;
     public Transform Bow;
  
    public float arrowSpeed;


    public float timeChrg =0;

    float currentCD;
    public bool chrg;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
        currentCD = 0;
        stat = GetComponent<PlayerStat>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Attack();

    }

    void Attack()
    {
        currentCD -= Time.deltaTime;
        if(currentCD <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCharging();
            }
            else if (Input.GetButton("Fire1"))
            {
                Charging();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                ExecuteAttack();
            }
        }
        
    }

    void StartCharging()
    {
        timeChrg = 0f;
        chrg = true;
        arrowSpeed = stat.arrowFixedSpeed;

        animator.SetTrigger("StartAnimation1");
        

    }

    void Charging()
    {
        if(chrg == true)
        {
            timeChrg += Time.deltaTime;
            
            if (timeChrg > stat.maxTimeChrg)
            {
                timeChrg = stat.maxTimeChrg;
            }
        }
       
    }

    void ExecuteAttack()
    {
        chrg = false;
        arrowSpeed = Mathf.Lerp(stat.arrowFixedSpeed,stat.maxArrowSpeed,timeChrg/stat.maxTimeChrg);
        animator.SetTrigger("BowRelease");
    }


    public void Shoot()
    {
        
        GameObject SpwndArrow = Instantiate(arrow, Bow.position, Quaternion.identity);
        SpwndArrow.GetComponent<ArrowCont>().DirectionCheck(MouseCheck());
        
    }

    Vector3 MouseCheck()
    {
        Vector3 mouseP = stat.mousePos;
        return mouseP;
    }



}
//void Update()
//{
//    Attack();
//}

//void Attack()
//{
//    if (Input.GetButtonDown("Fire1"))
//    {
//        StartCharging();
//    }
//    if (Input.GetButton("Fire1"))
//    {
//        ContinueCharging();
//    }
//    if (Input.GetButtonUp("Fire1"))
//    {
//        ExecuteAttack();
//    }
//}

//void StartCharging()
//{
//    isCharging = true;
//    chargingTime = 0.0f;
//}

//void ContinueCharging()
//{
//    if (isCharging)
//    {
//        chargingTime += Time.deltaTime;
//        if (chargingTime > maxChargeTime)
//        {
//            chargingTime = maxChargeTime;
//        }
//    }
//}

//void ExecuteAttack()
//{
//    if (isCharging)
//    {
//        isCharging = false;

//    }
//}

//void PerformAttack(float power)
//{

//}
//} 

//public void Attack()
//{
//    if (currentCD > 0)
//    {
//        currentCD -= Time.deltaTime;
//    }
//    else{

//    if (chrg == false)
//    {
//        arrowSpeed = stat.arrowFixedSpeed;
//        if (Input.GetMouseButtonDown(0))
//        {
//          chrg = true;
//          animator.SetTrigger("StartAnimation1");
//        }

//    }

//        else if (Input.GetButtonUp("Fire1"))
//        {
//            Invoke(nameof(Shoot), 0.5f);
//            chrg = false;
//            timeChrg = 0;
//            currentCD = stat.cdAttack;
//            animator.SetFloat("PressDuration", timeChrg);
//            animator.SetBool("LoopAnimation2", false);
//            if (timeChrg < 0.5)
//            {
//                animator.SetBool("Animation1Completed", true);
//            }



//        }

//    }

//}

//void Charging()
//{

//    if (chrg)
//    {
//        Debug.Log("1");
//        if (timeChrg < stat.maxTimeChrg)
//        {
//            timeChrg += Time.deltaTime;
//            arrowSpeed += Time.deltaTime * stat.speedModifier;
//            animator.SetFloat("PressDuration", timeChrg);
//            animator.SetBool("LoopAnimation2", true);
//            animator.SetBool("Animation1Completed", false);
//        }
//    }

//}
//void Animation()
//{
//    if (animator.GetCurrentAnimatorStateInfo(0).IsName("Player_take_bow") &&
//           animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
//    {
//        animator.SetBool("Animation1Completed", true);
//    }
//}