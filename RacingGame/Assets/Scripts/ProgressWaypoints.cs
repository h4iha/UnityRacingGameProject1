using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressWaypoints : MonoBehaviour
{
    public int WPNumber;
    public int CarTracking = 0;
    public bool PenaltyOption = false;
    public int PenaltyWaypoint ;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Progress"))
        {
            CarTracking = other.GetComponent<ProgressTracker>().CurrentWp;
            if(CarTracking < WPNumber)
            {
                other.GetComponent<ProgressTracker>().CurrentWp = WPNumber;

            }

            if(CarTracking > WPNumber)
            {
                other.GetComponent<ProgressTracker>().LastWPNumer = WPNumber;
            }
            if(PenaltyOption == true)
            {
                if(CarTracking < PenaltyWaypoint)
                {
                    Debug.Log("Penalty");       
                }
            }
        }
    }
}
