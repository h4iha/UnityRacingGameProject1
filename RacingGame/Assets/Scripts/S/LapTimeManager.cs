using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MiliCount;

    public int min;
    public int sec;
    public float mili;

    public Text LapTimeText;

    // Update is called once per frame
    void Update()
    {
        mili = MiliCount;
        sec = SecondCount;
        min = MinuteCount;

        MiliCount = MiliCount + Time.deltaTime * 10;

        if (MiliCount > 9)
        {
            SecondCount = SecondCount + 1;
            MiliCount = 0;
        }

        if (SecondCount > 59)
        {
            MinuteCount = MinuteCount + 1;
            SecondCount = 0;
        }
        //sec
        if ((SecondCount >= 0 && SecondCount < 10) && (MinuteCount >= 0 && MinuteCount < 10))
        {
            LapTimeText.text = " Time:  0" + MinuteCount.ToString() + ": 0" + SecondCount.ToString() + ". 0" + MiliCount.ToString("F0");
        }
        if ((SecondCount >= 10 && SecondCount <= 59) && (MinuteCount >= 0 && MinuteCount < 10))
        {
            LapTimeText.text = " Time:  " + MinuteCount.ToString() + ": " + SecondCount.ToString() + ". 0" + MiliCount.ToString("F0");
        }
        //min
        if ((SecondCount >= 0 && SecondCount < 10) && (MinuteCount >= 10 && MinuteCount <= 59))
        {
            LapTimeText.text = " Time:  0" + MinuteCount.ToString() + ": 0" + SecondCount.ToString() + ". 0" + MiliCount.ToString("F0");
        }
        if ((SecondCount >= 10 && SecondCount <= 59) && (MinuteCount >= 10))
        {
            LapTimeText.text = " Time:  " + MinuteCount.ToString() + ": " + SecondCount.ToString() + ". 0" + MiliCount.ToString("F0");
        }
    }
}
