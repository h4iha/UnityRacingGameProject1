using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SaveSystem : MonoBehaviour
{
    public static float speed;
    public static float TopSpeed;
    public static int Gear;

    public static int LapNumber;
    public static bool LapChange = false;

    public static float LapTimeMinutes;
    public static float LapTimeSeconds;
    public static float LapTimeMilis;

    public static float RaceTimeMinutes;
    public static float RaceTimeSeconds;
    public static float RaceTimeMilis;

    public static float BestLapTimeMinutes;
    public static float BestLapTimeSeconds;
    public static float BestLapTimeMilis;

    public static float LastLapTimeMinutes;
    public static float LastLapTimeSeconds;
    public static float LastLapTimeMilis;

    public static float GameTime;

    public static float LastCheckPoint1;
    public static float ThisCheckPoint1;
    public static float LastCheckPoint2;
    public static float ThisCheckPoint2;
    public static bool CheckPointPass1 = false;
    public static bool CheckPointPass2 = false;

    public static bool NewRecord = false;
    public static bool WrongWay = false;
    public static bool HalfWayActivated = true;
    public static bool WWTextReset = false;

    public static bool RaceStart = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LapChange == true)
        {
            LapChange = false;
            LapTimeMilis = 0f;
            LapTimeMinutes = 0f;
            LapTimeSeconds = 0f;
            GameTime = 0f;
        }
        if(LapNumber >= 1)
        {
            LapTimeMilis = LapTimeMilis + Time.deltaTime*10;
            RaceTimeMilis = RaceTimeMilis + Time.deltaTime * 10;
            GameTime = GameTime + Time.deltaTime * 1;
        }

        //Milis
        if (LapTimeMilis > 9)
        {
            LapTimeMilis = 0f;
            LapTimeSeconds++;
        }
        if (RaceTimeMilis > 9)
        {
            RaceTimeMilis = 0f;
            RaceTimeSeconds++;
        }

        //Seconds
        if (LapTimeSeconds > 59)
        {
            LapTimeSeconds = 0f;
            LapTimeMinutes++;
        }
        if (RaceTimeSeconds > 59)
        {
            RaceTimeSeconds = 0f;
            RaceTimeMinutes++;
        }
        

    }
}
