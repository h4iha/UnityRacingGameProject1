using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rotator : MonoBehaviour
{
    //public GameObject CarContainer;
    public float rotationSpeed = 50;
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R)) { };

        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        
    }
}
