using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class UIScripts : MonoBehaviour
{
    [Header("SpeedMeter")]
    public Image SpeedRing;
    public Text SpeedText;
    public float DisplaySpeed;

    [Header("Lap")]
    public Text TotalLapText;
    public Text currentLapText;
    public Text CurrentTimeText;
    public Text LastTimeText;
    public Text BestTimeText;

    [Header("Finish")]
    public GameObject FinishBoard;

    public GameObject ScoreModeObject;
    public GameObject TimeModeObject;
    public GameObject RaceModeObject;

    public GameObject Player;
    public GameObject AI;
    public GameObject ScoringObject;

    // Start is called before the first frame update
    void Start()
    {
        SpeedRing.fillAmount = 0;
        SpeedText.text = "0";
        currentLapText.text = "0";
        TotalLapText.text = "/ " + SaveManager.instance.currentTotalLap.ToString();
        CurrentTimeText.text = "00: 00";

        FinishBoard.SetActive(false);
        Player.GetComponent<Scoring>().enabled = false;
        ScoringObject.gameObject.SetActive(false);
        SaveManager.instance.CurrentScore = 0;
        SaveManager.instance.Save();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveManager.instance.currentMode == 2) {
            Player.GetComponent<Scoring>().enabled = true;
            ScoringObject.gameObject.SetActive(true);
        }
        #region Time Set
        if(SaveScript.LapChange == true) {
            SaveScript.LapChange = false;
            SaveScript.LapTimeMinutes = 0f;
            SaveScript.LapTimeSeconds = 0f;
        }

        if(SaveScript.LapNumber >= 1) {
            SaveScript.LapTimeSeconds = SaveScript.LapTimeSeconds + 1 * Time.deltaTime;
        }
        if(SaveScript.LapTimeSeconds > 59) {
            SaveScript.LapTimeSeconds = 0f;
            SaveScript.LapTimeMinutes++;
        }
        #endregion


        if(SaveManager.instance.currentMode == 0) {
            ScoreModeObject.gameObject.SetActive(false);
            TimeModeObject.gameObject.SetActive(false);
            RaceModeObject.gameObject.SetActive(true);
        }
        if(SaveManager.instance.currentMode == 1) {
            ScoreModeObject.gameObject.SetActive(false);
            TimeModeObject.gameObject.SetActive(true);
            RaceModeObject.gameObject.SetActive(false);
        }
        if(SaveManager.instance.currentMode == 2) {
            ScoreModeObject.gameObject.SetActive(true);
            TimeModeObject.gameObject.SetActive(false);
            RaceModeObject.gameObject.SetActive(false);
        }

        DisplaySpeed = SaveScript.CurrentSpeed/SaveScript.MaximumSpeed;
        SpeedRing.fillAmount = DisplaySpeed;
        SpeedText.text = (Mathf.Round(SaveScript.CurrentSpeed).ToString());

        currentLapText.text = SaveScript.LapNumber.ToString();


        //Current Time Display
        if(SaveScript.LapTimeMinutes <= 9 && SaveScript.LapTimeSeconds <= 9) {
            CurrentTimeText.text = "0" + Mathf.Round(SaveScript.LapTimeMinutes).ToString()
            +    ": 0" + Mathf.Round(SaveScript.LapTimeSeconds).ToString();
        }

        else if(SaveScript.LapTimeMinutes <= 9 && SaveScript.LapTimeSeconds >= 10) {
            CurrentTimeText.text = "0" + Mathf.Round(SaveScript.LapTimeMinutes).ToString()
            +    ": " + Mathf.Round(SaveScript.LapTimeSeconds).ToString();
        }

        else if(SaveScript.LapTimeMinutes >= 10 && SaveScript.LapTimeSeconds <= 9) {
            CurrentTimeText.text = Mathf.Round(SaveScript.LapTimeMinutes).ToString()
            +    ": 0" + Mathf.Round(SaveScript.LapTimeSeconds).ToString();
        }

        else if(SaveScript.LapTimeMinutes >= 10 && SaveScript.LapTimeSeconds >= 10) {
            CurrentTimeText.text = Mathf.Round(SaveScript.LapTimeMinutes).ToString()
            +    ": " + Mathf.Round(SaveScript.LapTimeSeconds).ToString();
        }

        //Last Time Display
        if(SaveManager.instance.RaceMin <= 9 && SaveManager.instance.RaceSec <= 9) {
            LastTimeText.text = "0" + Mathf.Round(SaveManager.instance.RaceMin).ToString()
            +    ": 0" + Mathf.Round(SaveManager.instance.RaceSec).ToString();
        }

        else if(SaveManager.instance.RaceMin <= 9 && SaveManager.instance.RaceSec >= 10) {
            LastTimeText.text = "0" + Mathf.Round(SaveManager.instance.RaceMin).ToString()
            +    ": " + Mathf.Round(SaveManager.instance.RaceSec).ToString();
        }

        else if(SaveManager.instance.RaceMin >= 10 && SaveManager.instance.RaceSec <= 9) {
            LastTimeText.text = Mathf.Round(SaveManager.instance.RaceMin).ToString()
            +    ": 0" + Mathf.Round(SaveManager.instance.RaceSec).ToString();
        }

        else if(SaveManager.instance.RaceMin >= 10 && SaveManager.instance.RaceSec >= 10) {
            LastTimeText.text = Mathf.Round(SaveManager.instance.RaceMin).ToString()
            +    ": " + Mathf.Round(SaveManager.instance.RaceSec).ToString();
        }

        if(SaveManager.instance.currentMode == 1) {
            //Best Time
            if(SaveManager.instance.currentMap == 0) {

                if(SaveManager.instance.RaceMin == SaveManager.instance.BestMinM1) {
                    if(SaveManager.instance.RaceSec < SaveManager.instance.BestSecM1) {
                        SaveManager.instance.BestSecM1 = Mathf.Round(SaveManager.instance.RaceSec);
                        SaveManager.instance.Save();
                    }
                }
                if(SaveManager.instance.RaceMin < SaveManager.instance.BestMinM1) {
                    SaveManager.instance.BestMinM1 = Mathf.Round(SaveManager.instance.RaceMin);
                    SaveManager.instance.BestSecM1 = Mathf.Round(SaveManager.instance.RaceSec);
                    SaveManager.instance.Save();
                }

                //bEST Time Display Map 1
                if(SaveManager.instance.RaceMin <= 9 && SaveManager.instance.RaceSec <= 9) {
                    BestTimeText.text = "0" + Mathf.Round(SaveManager.instance.BestMinM1).ToString()
                    +    ": 0" + Mathf.Round(SaveManager.instance.BestSecM1).ToString();
                }

                else if(SaveManager.instance.RaceMin <= 9 && SaveManager.instance.RaceSec >= 10) {
                BestTimeText.text = "0" + Mathf.Round(SaveManager.instance.BestMinM1).ToString()
                +    ": " + Mathf.Round(SaveManager.instance.BestSecM1).ToString();
                }

                else if(SaveManager.instance.RaceMin >= 10 && SaveManager.instance.RaceSec <= 9) {
                    BestTimeText.text = Mathf.Round(SaveManager.instance.BestMinM1).ToString()
                    +    ": 0" + Mathf.Round(SaveManager.instance.BestSecM1).ToString();
                }

                else if(SaveManager.instance.RaceMin >= 10 && SaveManager.instance.RaceSec >= 10) {
                    BestTimeText.text = Mathf.Round(SaveManager.instance.BestMinM1).ToString()
                    +    ": " + Mathf.Round(SaveManager.instance.BestSecM1).ToString();
                }
            }

            if(SaveManager.instance.currentMap == 1) {
                if(SaveManager.instance.RaceMin == SaveManager.instance.BestMinM2) {
                    if(SaveManager.instance.RaceSec < SaveManager.instance.BestSecM2) {
                        SaveManager.instance.BestSecM2 = Mathf.Round(SaveManager.instance.RaceSec);
                        SaveManager.instance.Save();
                    }
                }
                if(SaveManager.instance.RaceMin < SaveManager.instance.BestMinM2) {
                    SaveManager.instance.BestMinM2 = Mathf.Round(SaveManager.instance.RaceMin);
                    SaveManager.instance.BestSecM2 = Mathf.Round(SaveManager.instance.RaceSec);
                    SaveManager.instance.Save();
                }

                //bEST Time Display Map 2
                if(SaveManager.instance.RaceMin <= 9 && SaveManager.instance.RaceSec <= 9) {
                    BestTimeText.text = "0" + Mathf.Round(SaveManager.instance.BestMinM2).ToString()
                    +    ": 0" + Mathf.Round(SaveManager.instance.BestSecM2).ToString();
                }

                else if(SaveManager.instance.RaceMin <= 9 && SaveManager.instance.RaceSec >= 10) {
                BestTimeText.text = "0" + Mathf.Round(SaveManager.instance.BestMinM2).ToString()
                +    ": " + Mathf.Round(SaveManager.instance.BestSecM2).ToString();
                }

                else if(SaveManager.instance.RaceMin >= 10 && SaveManager.instance.RaceSec <= 9) {
                    BestTimeText.text = Mathf.Round(SaveManager.instance.BestMinM2).ToString()
                    +    ": 0" + Mathf.Round(SaveManager.instance.BestSecM2).ToString();
                }

                else if(SaveManager.instance.RaceMin >= 10 && SaveManager.instance.RaceSec >= 10) {
                    BestTimeText.text = Mathf.Round(SaveManager.instance.BestMinM2).ToString()
                    +    ": " + Mathf.Round(SaveManager.instance.BestSecM2).ToString();
                }
            }
        }

        
    }

    
}
