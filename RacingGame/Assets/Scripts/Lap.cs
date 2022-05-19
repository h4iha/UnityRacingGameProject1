using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SaveSystem.WWTextReset = true;
            StartCoroutine(WrongWayReset());

            if (SaveSystem.HalfWayActivated == true) {
                SaveSystem.HalfWayActivated = false;
                SaveSystem.WWTextReset = true;
                SaveSystem.LastLapTimeMinutes = SaveSystem.LapTimeMinutes;
                SaveSystem.LastLapTimeSeconds = SaveSystem.LapTimeSeconds;
                SaveSystem.LastLapTimeMilis = SaveSystem.LapTimeMilis;
                SaveSystem.LapNumber++;
                SaveSystem.LapChange = true;

                if (SaveSystem.LapNumber == 2)
                {
                    SaveSystem.BestLapTimeMinutes = SaveSystem.LastLapTimeMinutes;
                    SaveSystem.BestLapTimeSeconds = SaveSystem.LastLapTimeSeconds;
                    SaveSystem.BestLapTimeMilis = SaveSystem.LastLapTimeMilis;
                    SaveSystem.NewRecord = true;
                }

                SaveSystem.CheckPointPass1 = false;
                SaveSystem.CheckPointPass2 = false;
                SaveSystem.LastCheckPoint1 = SaveSystem.ThisCheckPoint1;
                SaveSystem.LastCheckPoint2 = SaveSystem.ThisCheckPoint2;
            }
        }
    }

    IEnumerator WrongWayReset()
    {
        yield return new WaitForSeconds(1.5f);
        SaveSystem.WWTextReset = false;
    }
}
