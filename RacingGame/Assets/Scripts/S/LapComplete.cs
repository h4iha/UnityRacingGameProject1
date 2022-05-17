using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{

    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public Text BestTimeText;
    public static int Lap = 0;

    void OnTriggerEnter()
    {
        //if(Lap > maxLap)
        if ((LapTimeManager.SecondCount >= 0 && LapTimeManager.SecondCount < 10) && (LapTimeManager.MinuteCount >= 0 && LapTimeManager.MinuteCount < 10))
        {
            BestTimeText.text = " Time:   0" + LapTimeManager.MinuteCount.ToString() + ": 0" + LapTimeManager.SecondCount.ToString() + ". 0" + LapTimeManager.MiliCount.ToString("F0");
        }
        else if ((LapTimeManager.SecondCount >= 10 && LapTimeManager.SecondCount <= 59) && (LapTimeManager.MinuteCount >= 0 && LapTimeManager.MinuteCount < 10))
        {
            BestTimeText.text = " Time:   " + LapTimeManager.MinuteCount.ToString() + ": " + LapTimeManager.SecondCount.ToString() + ". 0" + LapTimeManager.MiliCount.ToString("F0");
        }
        //min
        else if ((LapTimeManager.SecondCount >= 0 && LapTimeManager.SecondCount < 10) && (LapTimeManager.MinuteCount >= 10 && LapTimeManager.MinuteCount <= 59))
        {
            BestTimeText.text = " Time:   0" + LapTimeManager.MinuteCount.ToString() + ": 0" + LapTimeManager.SecondCount.ToString() + ". 0" + LapTimeManager.MiliCount.ToString("F0");
        }
        else if ((LapTimeManager.SecondCount >= 10 && LapTimeManager.SecondCount <= 59) && (LapTimeManager.MinuteCount >= 10))
        {
            BestTimeText.text = " Time:   " + LapTimeManager.MinuteCount.ToString() + ": " + LapTimeManager.SecondCount.ToString() + ". 0" + LapTimeManager.MiliCount.ToString("F0");
        }

        LapCompleteTrig.SetActive(false);
        HalfLapTrig.SetActive(true);

        Lap = Lap + 1;
    }

}
