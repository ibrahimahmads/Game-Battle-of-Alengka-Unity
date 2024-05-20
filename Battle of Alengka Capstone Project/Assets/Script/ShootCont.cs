using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCont : MonoBehaviour
{
    PointerCont pointCont;
    public Vector3 mouseP;
    public Vector3 direction;
    public GameObject arrow;
    public float fixedSpeed;
    public float arrowSpeed;
    public float maxTimeChrg;
    public float speedModifier;
    public float timeChrg =0;
    public bool chrg;

    // Start is called before the first frame update
    void Start()
    {
        pointCont = FindAnyObjectByType<PointerCont>();
        arrowSpeed = fixedSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Charging();
        Attack();
    }


    public void Attack()
    {
        if (chrg == false)
        {
            arrowSpeed = fixedSpeed;
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
        }
        
    }

    void Charging()
    {

        if (chrg && timeChrg <= maxTimeChrg)
        {
            timeChrg += Time.deltaTime;
            arrowSpeed += Time.deltaTime * speedModifier;
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
