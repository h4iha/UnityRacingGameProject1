using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public int CurrentWp = 0;
    public int ThisWPNumber;
    public int LastWPNumer;
    void Start()
    {
        
    }

    private void Update()
    {
        if(CurrentWp > LastWPNumer)
        {
            StartCoroutine(CheckDirection());
        }
        if(LastWPNumer > ThisWPNumber)
        {
            SaveSystem.WrongWay = false;
        }
        if(LastWPNumer < ThisWPNumber)
        {
            SaveSystem.WrongWay = true;
        }
    }

    IEnumerator CheckDirection()
    {
        yield return new WaitForSeconds(0.5f);
        ThisWPNumber = LastWPNumer;
    }
}
