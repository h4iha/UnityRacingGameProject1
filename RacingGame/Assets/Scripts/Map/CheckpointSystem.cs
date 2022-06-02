using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckpointSystem : MonoBehaviour
{
   
    public float[] DistanceArrays;

    [Header("Cars Car01 = Player Car")]
    public Transform Car01;
    public Transform Car02;
    public Transform Car03;

    public int YourPos = 1;

    float First;
    float Second;
    float Third;

    [Header("UI")]
    public Text name1;
    public Text name2;
    public Text name3;

    public Image image1;
    public Image image2;
    public Image image3;

    public GameObject NextCheckPoint;

    void Start()
    {
        NextCheckPoint.SetActive(false);
    }


    void Update()
    {
        DistanceArrays[0] = Vector3.Distance(transform.position, Car01.position);
        DistanceArrays[1] = Vector3.Distance(transform.position, Car02.position);
        DistanceArrays[2] = Vector3.Distance(transform.position, Car03.position);

        Array.Sort(DistanceArrays);

        First = DistanceArrays[0];
        Second = DistanceArrays[1];
        Third = DistanceArrays[2];

        float Car01Dist = Vector3.Distance(transform.position, Car01.position);
        float Car02Dist = Vector3.Distance(transform.position, Car02.position);
        float Car03Dist = Vector3.Distance(transform.position, Car03.position);

        #region Car01UI
        if (Car01Dist == First)
        {
            name1.text = "You";
            image1.gameObject.SetActive(true);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(false);
            YourPos = 1;
        }
        if (Car01Dist == Second)
        {
            name2.text = "You";
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(true);
            image3.gameObject.SetActive(false);
            YourPos = 2;
        }
        if (Car01Dist == Third)
        {
            name3.text = "You";
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(true);
            YourPos = 3;
        }
        #endregion

        #region Car02UI
        if (Car02Dist == First)
        {
            name1.text = "BMW Yellow";
        }
        if (Car02Dist == Second)
        {
            name2.text = "BMW Yellow";
        }
        if (Car02Dist == Third)
        {
            name3.text = "BMW Yellow";
        }
        #endregion

        #region Car03UI
        if (Car03Dist == First)
        {
            name1.text = "BMW White";
        }
        if (Car03Dist == Second)
        {
            name2.text = "BMW White";
        }
        if (Car03Dist == Third)
        {
            name3.text = "BMW White";
        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CarBody")
        {
            NextCheckPoint.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}