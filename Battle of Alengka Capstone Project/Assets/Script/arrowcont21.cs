using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowcont21 : MonoBehaviour
{
    float arrowSpeed = 3;

    public bool col;


    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {

        Destroy(gameObject, 10);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(5, 0,0) * arrowSpeed * Time.deltaTime;
        Debug.Log("wowowowo");
    }
}
