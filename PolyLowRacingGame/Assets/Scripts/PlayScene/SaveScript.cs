using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class SaveScript : MonoBehaviour
{
    public static float MaximumSpeed;
    public static float CurrentSpeed;
    public static int LapNumber;
    public static int LapAINumber;
    public static int TotalLap;

    public static string finishPosition;

    public static bool LapChange = false;

    public static float LapTimeMinutes;
    public static float LapTimeSeconds;

    public static float BestTimeMinutes;
    public static float BestTimeSeconds;

    public static float LastTimeMinutes;
    public static float LastTimeSeconds;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}