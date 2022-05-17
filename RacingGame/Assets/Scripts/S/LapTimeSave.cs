using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeSave : MonoBehaviour
{
    public  int MinCount;
    public  int SecCount;
    public  float MiliCount;
    public Text BestTimeText;
    // Start is called before the first frame update
    void Start()
    {
        MinCount = PlayerPrefs.GetInt("MinSave");
        SecCount = PlayerPrefs.GetInt("SecSave");
        MiliCount = PlayerPrefs.GetInt("MiliSave");

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
