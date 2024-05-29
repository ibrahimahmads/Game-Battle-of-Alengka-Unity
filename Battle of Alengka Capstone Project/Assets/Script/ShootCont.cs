using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class ShootCont : MonoBehaviour
{
    PlayerStat stat;
    PointerCont pointCont;
    public Vector3 mouseP;
    public Vector3 direction;
    public GameObject arrow;
  
    public float arrowSpeed;
    public float timeChrg =0;

    float currentCD;
    public bool chrg;

    // Start is called before the first frame update
    void Start()
    {
        pointCont = FindAnyObjectByType<PointerCont>();
        currentCD = 0;
        stat = GetComponent<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {
        Charging();
        Attack();
        
    }


    public void Attack()
    {
        if (currentCD > 0)
        {
            currentCD -= Time.deltaTime;
        }
        else{

        if (chrg == false)
        {
            arrowSpeed = stat.arrowFixedSpeed;
        }
        if (Input.GetButtonDown("Fire1"))
        {
           chrg = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            Shoot();
            chrg = false;
            timeChrg = 0;
            currentCD = stat.cdAttack;
        }
        }
        
    }

    void Charging()
    {

        if (chrg && timeChrg <= stat.maxTimeChrg)
        {
            timeChrg += Time.deltaTime;
            arrowSpeed += Time.deltaTime * stat.speedModifier;
        }
        
    }
    void Shoot()
    {
       GameObject SpwndArrow = Instantiate(arrow, transform.position, Quaternion.identity);
        SpwndArrow.transform.position = transform.position;
        SpwndArrow.GetComponent<ArrowCont>().DirectionCheck(MouseCheck());
    }

    Vector3 MouseCheck()
    {
        mouseP = pointCont.mousePos;
        return mouseP;
    }
    
}
