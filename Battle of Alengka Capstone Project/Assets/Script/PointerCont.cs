using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerCont : MonoBehaviour
{
    private Camera mainCam;
    GameObject Player;
    public Vector3 mousePos;
    private Vector3 dir;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frames
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePos - transform.position;
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        transform.localScale = Player.transform.localScale;
        
    }

    
}
