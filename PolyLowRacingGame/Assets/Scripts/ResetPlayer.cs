using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    Checkpoints checkpoints;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        checkpoints = GetComponent<Checkpoints>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.transform.position = checkpoints.PrevCheckpoint.transform.position;
        }
    }
}
