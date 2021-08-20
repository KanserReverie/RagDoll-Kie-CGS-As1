using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movething : MonoBehaviour
{
    [SerializeField] private Rigidbody myRB;

    public bool usingPosition;
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (usingPosition)
        {
            if (myRB.position.x < 10)
            {
                myRB.velocity = new Vector3(100.1f, 0, 0);
            }
            else
            {
                myRB.velocity = new Vector3(0, 0, 0);
            }
        }
        
        else if (!usingPosition)
        {
            if (myRB.transform.position.x < 10)
            {
                myRB.velocity = new Vector3(100.1f, 0, 0);
            }
            else
            {
                myRB.velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
