using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetCar : MonoBehaviour
{
    float elapsedtime = 0;
    Checkpoints checkPoints;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        checkPoints = GetComponent<Checkpoints>();

    }
    private void Update()
    {
        if(rb.velocity.magnitude<=1)
        {
            elapsedtime = elapsedtime + Time.deltaTime;

        }
        else
        {
            elapsedtime = 0;
        }
        if (elapsedtime > 5)
        {
            gameObject.transform.position = checkPoints.prevCheckpoint.transform.position;
        }
    }
}
