using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatuGelindingCont : MonoBehaviour
{
    public GameObject Batu;
    bool entered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && entered  == false)
        {
            Instantiate(Batu);
            entered = true;
        }
    }
}
