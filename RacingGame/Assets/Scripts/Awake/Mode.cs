using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode : MonoBehaviour
{

    public GameObject RaceManager;
    public GameObject TimeManager;
    public GameObject ScoreManager;
    void Start()
    {
        if (CarShopManager.RaceMode == 0)
        {
            RaceManager.gameObject.SetActive(true);
            TimeManager.gameObject.SetActive(false);
            ScoreManager.gameObject.SetActive(false);
        }

        else if (CarShopManager.RaceMode == 1)
        {
            RaceManager.gameObject.SetActive(false);
            TimeManager.gameObject.SetActive(false);
            ScoreManager.gameObject.SetActive(true);
        }

        else if (CarShopManager.RaceMode == 2)
        {
            RaceManager.gameObject.SetActive(false);
            TimeManager.gameObject.SetActive(true);
            ScoreManager.gameObject.SetActive(false);
        }
    }
}
