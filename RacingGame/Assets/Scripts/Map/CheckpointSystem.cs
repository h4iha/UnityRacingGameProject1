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
    public Transform Car04;


    float First;
    float Fourth;
    float Second;
    float Third;

    [Header("UI")]
    public Text name1;
    public Text name2;
    public Text name3;
    public Text name4;

    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;

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
        DistanceArrays[3] = Vector3.Distance(transform.position, Car04.position);

        Array.Sort(DistanceArrays);

        First = DistanceArrays[0];
        Second = DistanceArrays[1];
        Third = DistanceArrays[2];
        Fourth = DistanceArrays[3];

        float Car01Dist = Vector3.Distance(transform.position, Car01.position);
        float Car02Dist = Vector3.Distance(transform.position, Car02.position);
        float Car03Dist = Vector3.Distance(transform.position, Car03.position);
        float Car04Dist = Vector3.Distance(transform.position, Car04.position);

        #region Car01UI
        if (Car01Dist == First)
        {
            name1.text = "You";
            image1.gameObject.SetActive(true);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(false);
            image4.gameObject.SetActive(false);
        }
        if (Car01Dist == Second)
        {
            name2.text = "You";
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(true);
            image3.gameObject.SetActive(false);
            image4.gameObject.SetActive(false);
        }
        if (Car01Dist == Third)
        {
            name3.text = "You";
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(true);
            image4.gameObject.SetActive(false);
        }
        if (Car01Dist == Fourth)
        {
            name4.text = "You";
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(false);
            image4.gameObject.SetActive(true);
        }
        #endregion

        #region Car02UI
        if (Car02Dist == First)
        {
            name1.text = "BMW Black";
        }
        if (Car02Dist == Second)
        {
            name2.text = "BMW Black";
        }
        if (Car02Dist == Third)
        {
            name3.text = "BMW Black";
        }
        if (Car02Dist == Fourth)
        {
            name4.text = "BMW Black";
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
        if (Car03Dist == Fourth)
        {
            name4.text = "BMW White";
        }
        #endregion

        #region Car04UI
        if (Car04Dist == First)
        {
            name1.text = "BMW Yellow";
        }
        if (Car04Dist == Second)
        {
            name2.text = "BMW Yellow";
        }
        if (Car04Dist == Third)
        {
            name3.text = "BMW Yellow";
        }
        if (Car04Dist == Fourth)
        {
            name4.text = "BMW Yellow";
        }
        #endregion

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            NextCheckPoint.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}