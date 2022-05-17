using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    public GameObject Player;
    public float CarX;
    public float CarY;
    public float CarZ;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CarX = Player.transform.eulerAngles.x;
        CarY = Player.transform.eulerAngles.y;
        CarZ = Player.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(CarX - CarX, CarY, CarZ - CarZ);
    }
}
