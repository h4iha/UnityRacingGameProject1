using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{

    public float distance = 6.0f;
    public float height = 3.0f;
    public GameObject Player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.GetComponent<Transform>().position;
        transform.position = transform.position - Player.GetComponent<Transform>().rotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        transform.LookAt(Player.GetComponent<Transform>());
    }
}
