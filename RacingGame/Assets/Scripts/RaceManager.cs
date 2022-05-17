using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class RaceManager : MonoBehaviour
{
    GameObject Player;
    GameObject[] AIs;
    AudioSource[] audioSources;
    Checkpoints checkpoint;
    public int maxLaps = 1;

    [Header("Coutdown")]
    public GameObject CountDown;
    public AudioSource Ready1;
    public AudioSource Ready2;
    public AudioSource Ready3;
    public AudioSource GoAudio;
    public AudioSource ThemeAudio1;
    public AudioSource ThemeAudio2;
    public AudioSource ThemeAudio3;
    public AudioSource ThemeAudio4;
    public AudioSource ThemeAudio5;
    public AudioSource finishAudio;

     [Header("Race")]
    public Text PositionText;

    [Header("Score")]
    public GameObject ScoreValue;
    public GameObject ScorePanel;
    GameObject[] Reds;
    GameObject[] Blues;
    GameObject[] Greens;
    public static int CurrentScore;
    public static int InternalScore;
    public GameObject PointScore;

    [Header("Time")]
    public Text timeLabel;
    public Text bestLabel;
    public GameObject LapTimePanel;
    [HideInInspector]
    public int min;
    public int sec;
    public float mili;
    public int minL;
    public int secL;
    public float miliL;

    public GameObject Black;
    public GameObject Blue;
    public GameObject Green;
    public GameObject Yellow;
    public GameObject White;
    public GameObject Red;

    public GameObject allCam;
    public Camera finishCam;

    void Start()
    {
        StartCoroutine(CountStart());
    }
    IEnumerator CountStart()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        checkpoint = Player.GetComponent<Checkpoints>();
        if(SaveManager.instance.currentCarIndex == 0)
        {
            Black.gameObject.SetActive(true);
        }
        if (SaveManager.instance.currentCarIndex == 1)
        {
            Blue.gameObject.SetActive(true);
        }
        if (SaveManager.instance.currentCarIndex == 2)
        {
            Green.gameObject.SetActive(true);
        }
        if (SaveManager.instance.currentCarIndex == 3)
        {
            Yellow.gameObject.SetActive(true);
        }

        if (SaveManager.instance.currentCarIndex == 4)
        {
            White.gameObject.SetActive(true);
        }
        if (SaveManager.instance.currentCarIndex == 5)
        {
            Red.gameObject.SetActive(true);
        }



        AIs = GameObject.FindGameObjectsWithTag("AI");

        if (CarShopManager.RaceMode == 0)
        {
            PositionText.gameObject.SetActive(true);
            foreach (GameObject AI in AIs)
            {
                AI.gameObject.SetActive(true);
            }
        }
        if (CarShopManager.RaceMode == 1)
        {
            ScoreValue.gameObject.SetActive(true);
            ScorePanel.gameObject.SetActive(true);
            foreach (GameObject AI in AIs)
            {
                AI.gameObject.SetActive(false);
            }
            PointScore.gameObject.SetActive(true);
        }

        if (CarShopManager.RaceMode == 2)
        {
            timeLabel.gameObject.SetActive(true);
            bestLabel.gameObject.SetActive(true);
            LapTimePanel.gameObject.SetActive(true);
            foreach (GameObject AI in AIs)
            {
                AI.gameObject.SetActive(false);
            }
        }

        yield return new WaitForSeconds(0.5f);
        CountDown.GetComponent<Text>().text = "3";
        Ready3.Play();
        CountDown.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "2";
        Ready2.Play();
        CountDown.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "1";
        Ready1.Play();
        CountDown.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        GoAudio.Play();

        ThemeAudio1.Play();

        StartCar(Player);

        if (CarShopManager.RaceMode == 0)
        {
            foreach (GameObject AI in AIs)
            {
                StartCar(AI);
                yield return new WaitForSeconds(1);
            }
        }
        yield return new WaitForSeconds(215);
        ThemeAudio2.Play();
        yield return new WaitForSeconds(175);
        ThemeAudio3.Play();
        yield return new WaitForSeconds(225);
        ThemeAudio4.Play();
        yield return new WaitForSeconds(260);
        ThemeAudio5.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (CarShopManager.RaceMode == 2)
        {
            StopCar(Player);
            loadTime();
            mili = mili + Time.deltaTime * 10;

            #region StartTime
            if (mili > 9)
            {
                sec = sec + 1;
                mili = 0;
            }

            if (sec > 59)
            {
                min = min + 1;
                sec = 0;
            }
            //sec
            if (sec >= 0 && sec < 10)
            {
                timeLabel.text = "  Time:          " + min.ToString() + ": " + sec.ToString() + ". 0" + mili.ToString("F0");
            }
            else if (sec >= 10 && sec <= 59)
            {
                timeLabel.text = "  Time:          " + min.ToString() + ": " + sec.ToString() + ". " + mili.ToString("F0");
            }
            //min
            if (min >= 0 && min < 10)
            {
                timeLabel.text = "  Time:          " + min.ToString() + ": 0" + sec.ToString() + ". " + mili.ToString("F0");
            }
            else if (min >= 10 && min <= 59)
            {
                timeLabel.text = "  Time:          " + min.ToString() + ": " + sec.ToString() + ". " + mili.ToString("F0");
            }

            if (sec >= 0 && sec < 10 && min >= 0 && min < 10)
            {
                timeLabel.text = "  Time:          " + min.ToString() + ": 0" + sec.ToString() + ". 0" + mili.ToString("F0");
            }
            else if (sec >= 10 && sec <= 59 && min >= 10 && min <= 59)
            {
                timeLabel.text = "  Time:          " + min.ToString() + ": " + sec.ToString() + ". " + mili.ToString("F0");
            }
            #endregion

            if (checkpoint.lap > maxLaps)
            {
                if (CarShopManager.RaceMode == 2)
                {
                    endTime();
                }
            }
        }
        if (CarShopManager.RaceMode == 0)
        {
            if  (checkpoint.lap > maxLaps)
            {
                StopCar(Player);
                foreach (GameObject AI in AIs)
                {
                    if (AI.GetComponent<Checkpoints>().lap > maxLaps)
                        StopCar(AI);
                }
            }
            
        }
        if (CarShopManager.RaceMode == 1)
        {
            if (checkpoint.lap > maxLaps)
            {
                StopCar(Player);
                InternalScore = CurrentScore;
                ScoreValue.GetComponent<Text>().text = "" + InternalScore;
                SaveManager.instance.cash += InternalScore / 10;
            }
            
        }



    }
    void StartCar(GameObject car)
    {
        car.GetComponent<CarController>().enabled = true;

        if (car.GetComponent<CarUserControl>() != null)
            car.GetComponent<CarUserControl>().enabled = true;

        if (car.GetComponent<CarAIControl>() != null)
            car.GetComponent<CarAIControl>().enabled = true;

        if (car.GetComponent<resetCar>() != null)
            car.GetComponent<resetCar>().enabled = true;

        if (car.GetComponent<CarAudio>() != null)
            car.GetComponent<CarAudio>().enabled = true;

        if (car.GetComponent<CarController>() != null)
            car.GetComponent<CarController>().enabled = true;

        car.GetComponent<Rigidbody>().isKinematic = false;

        audioSources = car.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.enabled = true;
        }
    }
    void StopCar(GameObject car)
    {
        finishCam.GetComponent<Rotator>().enabled = true;
        allCam.GetComponent<Rotator>().enabled = false;
        car.GetComponent<CarController>().enabled = false;

        if (car.GetComponent<CarUserControl>() != null)
            car.GetComponent<CarUserControl>().enabled = false;

        if (car.GetComponent<CarAIControl>() != null)
            car.GetComponent<CarAIControl>().enabled = false;

        if (car.GetComponent<resetCar>() != null)
            car.GetComponent<resetCar>().enabled = false;

        car.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        car.GetComponent<Rigidbody>().isKinematic = true;
    }


    void loadTime()
    {
        minL = PlayerPrefs.GetInt("MinSave");
        secL = PlayerPrefs.GetInt("SecSave");
        miliL = PlayerPrefs.GetFloat("MiliSave");
        if (sec >= 0 && sec < 10)
        {
            bestLabel.text = "  Best:         " + minL.ToString() + ": " + secL.ToString() + ". 0" + miliL.ToString("F0");
        }
        else if (sec >= 10 && sec <= 59)
        {
            bestLabel.text = "  Best:         " + minL.ToString() + ": " + secL.ToString() + ". " + miliL.ToString("F0");
        }
        //min
        if (min >= 0 && min < 10)
        {
            bestLabel.text = "  Best:         " + minL.ToString() + ": 0" + secL.ToString() + ". " + miliL.ToString("F0");
        }
        else if (min >= 10 && min <= 59)
        {
            bestLabel.text = "  Best:         " + minL.ToString() + ": " + secL.ToString() + ". " + miliL.ToString("F0");
        }

        if (sec >= 0 && sec < 10 && min >= 0 && min < 10)
        {
            bestLabel.text = "  Best:         " + minL.ToString() + ": 0" + secL.ToString() + ". 0" + miliL.ToString("F0");
        }
        else if (sec >= 10 && sec <= 59 && min >= 10 && min <= 59)
        {
            bestLabel.text = "  Best:         " + minL.ToString() + ": " + secL.ToString() + ". " + miliL.ToString("F0");
        }

    }

    void endTime()
    {
        PlayerPrefs.SetInt("MinSave", min);
        PlayerPrefs.SetInt("SecSave", sec);
        PlayerPrefs.SetFloat("MiliSave", mili);
        if (sec >= 0 && sec < 10)
        {
            bestLabel.text = "  Best:         " + min.ToString() + ": " + sec.ToString() + ". 0" + mili.ToString("F0");
        }
        else if (sec >= 10 && sec <= 59)
        {
            bestLabel.text = "  Best:         " + min.ToString() + ": " + sec.ToString() + ". " + mili.ToString("F0");
        }
        //min
        if (min >= 0 && min < 10)
        {
            bestLabel.text = "  Best:         " + min.ToString() + ": 0" + sec.ToString() + ". " + mili.ToString("F0");
        }
        else if (min >= 10 && min <= 59)
        {
            bestLabel.text = "  Best:         " + min.ToString() + ": " + sec.ToString() + ". " + mili.ToString("F0");
        }

        if (sec >= 0 && sec < 10 && min >= 0 && min < 10)
        {
            bestLabel.text = "  Best:         " + min.ToString() + ": 0" + sec.ToString() + ". 0" + mili.ToString("F0");
        }
        else if (sec >= 10 && sec <= 59 && min >= 10 && min <= 59)
        {
            bestLabel.text = "  Best:         " + min.ToString() + ": " + sec.ToString() + ". " + mili.ToString("F0");
        }
        mili = 0;
        sec = 0;
        min = 0;
    }

}
