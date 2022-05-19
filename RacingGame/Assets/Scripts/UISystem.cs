using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    public Image needle;
    public Text SpeedText;
    public Text GearText;
    public Text LapNumberText;
    public Text TotalLapsText;

    public Text LapTimeMinutesText;
    public Text LapTimeSecondsText;
    public Text LapTimeMilisText;

    public Text RaceTimeMinutesText;
    public Text RaceTimeSecondsText;
    public Text RaceTimeMilisText;

    public Text BestLapTimeMinutesText;
    public Text BestLapTimeSecondsText;
    public Text BestLapTimeMilisText;

    public Text CheckPointTime;
    public GameObject CheckPointDisplay;

    public GameObject NewLapRecord;

    public GameObject WrongWayText;
    public Text WrongWayT;

    private float DisplaySpeed;
    public int TotalLaps = 3;
    void Start()
    {
        needle.fillAmount = 0;
        SpeedText.text = "0";
        GearText.text = "1";
        LapNumberText.text = "0";
        TotalLapsText.text = "/ " + TotalLaps.ToString();

        CheckPointDisplay.SetActive(false);
        NewLapRecord.SetActive(false);
        WrongWayText.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //Speed Meter
        DisplaySpeed = SaveSystem.speed / SaveSystem.TopSpeed;
        needle.fillAmount = DisplaySpeed;
        SpeedText.text = (Mathf.Round(SaveSystem.speed).ToString());
        GearText.text = (SaveSystem.Gear + 1).ToString();


        //Lap Count
        LapNumberText.text = SaveSystem.LapNumber.ToString();

        #region Lap Time
        //Lap Time Milis
        LapTimeMilisText.text = (Mathf.Round(SaveSystem.LapTimeMilis).ToString());

        //Lap Time Seconds
        if (SaveSystem.LapTimeSeconds >= 10)
        {
            LapTimeSecondsText.text = (Mathf.Round(SaveSystem.LapTimeSeconds).ToString()) + ".";
        }
        if (SaveSystem.LapTimeSeconds <= 9)
        {
            LapTimeSecondsText.text = "0" + (Mathf.Round(SaveSystem.LapTimeSeconds).ToString()) + ".";
        }

        //Lap Time Minutes
        if (SaveSystem.LapTimeMinutes <= 9)
        {
            LapTimeMinutesText.text = "0" + (Mathf.Round(SaveSystem.LapTimeMinutes).ToString()) + ":";
        }
        if (SaveSystem.LapTimeMinutes >= 10)
        {
            LapTimeMinutesText.text = (Mathf.Round(SaveSystem.LapTimeMinutes).ToString()) + ":";
        }
        #endregion

        #region Race Time
        //Lap Time Milis
        RaceTimeMilisText.text = (Mathf.Round(SaveSystem.RaceTimeMilis).ToString());

        //Lap Time Seconds
        if (SaveSystem.RaceTimeSeconds >= 10)
        {
            RaceTimeSecondsText.text = (Mathf.Round(SaveSystem.RaceTimeSeconds).ToString()) + ".";
        }
        if (SaveSystem.RaceTimeSeconds <= 9)
        {
            RaceTimeSecondsText.text = "0" + (Mathf.Round(SaveSystem.RaceTimeSeconds).ToString()) + ".";
        }

        //Lap Time Minutes
        if (SaveSystem.RaceTimeMinutes <= 9)
        {
            RaceTimeMinutesText.text = "0" + (Mathf.Round(SaveSystem.RaceTimeMinutes).ToString()) + ":";
        }
        if (SaveSystem.RaceTimeMinutes >= 10)
        {
            RaceTimeMinutesText.text = (Mathf.Round(SaveSystem.RaceTimeMinutes).ToString()) + ":";
        }
        #endregion

        #region Calculate Best Lap Time

        if(SaveSystem.LastLapTimeMinutes == SaveSystem.BestLapTimeMinutes)
        {
            if(SaveSystem.LastLapTimeSeconds == SaveSystem.BestLapTimeSeconds)
            {
                if (SaveSystem.LastLapTimeMilis < SaveSystem.BestLapTimeMilis)
                {
                    SaveSystem.BestLapTimeMilis = SaveSystem.LastLapTimeMilis;
                    SaveSystem.NewRecord = true;
                }                  
                
            }
            else if (SaveSystem.LastLapTimeSeconds < SaveSystem.BestLapTimeSeconds)
            {
                SaveSystem.BestLapTimeMilis = SaveSystem.LastLapTimeMilis;
                SaveSystem.BestLapTimeSeconds = SaveSystem.LastLapTimeSeconds;
                SaveSystem.NewRecord = true;
            }
        }
        else if(SaveSystem.LastLapTimeMinutes < SaveSystem.BestLapTimeMinutes)
        {
            SaveSystem.BestLapTimeMilis = SaveSystem.LastLapTimeMilis;
            SaveSystem.BestLapTimeSeconds = SaveSystem.LastLapTimeSeconds;
            SaveSystem.BestLapTimeMinutes = SaveSystem.LastLapTimeMinutes;
            SaveSystem.NewRecord = true;

        }

        #endregion

        #region Best Lap Time
        //Lap Time Milis
        BestLapTimeMilisText.text = (Mathf.Round(SaveSystem.BestLapTimeMilis).ToString());

        //Lap Time Seconds
        if (SaveSystem.BestLapTimeSeconds >= 10)
        {
            BestLapTimeSecondsText.text = (Mathf.Round(SaveSystem.BestLapTimeSeconds).ToString()) + ".";
        }
        if (SaveSystem.BestLapTimeSeconds <= 9)
        {
            BestLapTimeSecondsText.text = "0" + (Mathf.Round(SaveSystem.BestLapTimeSeconds).ToString()) + ".";
        }

        //Lap Time Minutes
        if (SaveSystem.BestLapTimeMinutes <= 9)
        {
            BestLapTimeMinutesText.text = "0" + (Mathf.Round(SaveSystem.BestLapTimeMinutes).ToString()) + ":";
        }
        if (SaveSystem.BestLapTimeMinutes >= 10)
        {
            BestLapTimeMinutesText.text = (Mathf.Round(SaveSystem.BestLapTimeMinutes).ToString()) + ":";
        }
        #endregion

        if(SaveSystem.NewRecord == true)
        {
            NewLapRecord.SetActive(true);
            StartCoroutine(LapRecordOff());
        }

        //CheckPoint1 Working
        if(SaveSystem.CheckPointPass1 == true)
        {
            SaveSystem.CheckPointPass1 = false;
            if(SaveSystem.LapNumber > 1) {
                CheckPointDisplay.SetActive(true);

                if (SaveSystem.ThisCheckPoint1 > SaveSystem.LastCheckPoint1)
                {
                    CheckPointTime.color = Color.red;
                    CheckPointTime.text = "-" + (SaveSystem.ThisCheckPoint1 - SaveSystem.LastCheckPoint1).ToString();
                    StartCoroutine(CheckPointOff());
                }

                if (SaveSystem.ThisCheckPoint1 < SaveSystem.LastCheckPoint1)
                {
                    CheckPointTime.color = Color.green;
                    CheckPointTime.text = "+" + (SaveSystem.ThisCheckPoint1 - SaveSystem.LastCheckPoint1).ToString();
                    StartCoroutine(CheckPointOff());
                }
            }
        }
        //CheckPoint2 Working
        if (SaveSystem.CheckPointPass2 == true)
        {
            SaveSystem.CheckPointPass2 = false;
            if (SaveSystem.LapNumber > 1)
            {
                CheckPointDisplay.SetActive(true);


                if (SaveSystem.ThisCheckPoint2 > SaveSystem.LastCheckPoint2)
                {
                    CheckPointTime.color = Color.red;
                    CheckPointTime.text = "-" + (SaveSystem.ThisCheckPoint2 - SaveSystem.LastCheckPoint2).ToString();
                    StartCoroutine(CheckPointOff());
                }

                if (SaveSystem.ThisCheckPoint2 < SaveSystem.LastCheckPoint2)
                {
                    CheckPointTime.color = Color.green;
                    CheckPointTime.text = "+" + (SaveSystem.ThisCheckPoint2 - SaveSystem.LastCheckPoint2).ToString();
                    StartCoroutine(CheckPointOff());
                }
            }
        }

        //Wrong way message

        if(SaveSystem.WrongWay == true)
        {
            WrongWayText.SetActive(true);
        }
        if (SaveSystem.WrongWay == false)
        {
            WrongWayText.SetActive(false);
        }
        //Wrong Way reset Text 
        if(SaveSystem.WWTextReset == false)
        {
            WrongWayT.text = "WRONG WAY!!!";
        }
        if (SaveSystem.WWTextReset == true)
        {
            WrongWayT.text = " ";
        }
    }

    IEnumerator CheckPointOff()
    {
        yield return new WaitForSeconds(2);
        CheckPointDisplay.SetActive(false);

    }

    IEnumerator LapRecordOff()
    {
        yield return new WaitForSeconds(2);
        SaveSystem.NewRecord = false;
        NewLapRecord.SetActive(false);
    }

}
