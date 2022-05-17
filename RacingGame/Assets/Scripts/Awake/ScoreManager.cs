using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class ScoreManager : MonoBehaviour
{
    public GameObject ScoreValue;
    public GameObject ScorePanel;

    GameObject Player;
    GameObject[] AIs;
    AudioSource[] audioSources;
    Checkpoints checkpoint;
    public int maxLaps = 1;
    public int CurrentScore;
    public int InternalScore;

    GameObject[] Reds;
    GameObject[] Blues;
    GameObject[] Greens;

    [Header("Coutdown")]
    public GameObject CountDown;
    public AudioSource Ready1;
    public AudioSource Ready2;
    public AudioSource Ready3;
    public AudioSource GoAudio;

    void Start()
    {
        Reds = GameObject.FindGameObjectsWithTag("RedScore");
        foreach (GameObject Red in Reds)
        {
            Red.gameObject.SetActive(true);
        }
        Blues = GameObject.FindGameObjectsWithTag("BlueScore");
        foreach (GameObject Blue in Blues)
        {
            Blue.gameObject.SetActive(true);
        }
        Greens = GameObject.FindGameObjectsWithTag("GreenScore");
        foreach (GameObject Green in Greens)
        {
            Green.gameObject.SetActive(true);
        }
        StartCoroutine(CountStart());
    }
    IEnumerator CountStart()
    {

        ScorePanel.gameObject.SetActive(true);
        ScoreValue.gameObject.SetActive(true);
        AIs = GameObject.FindGameObjectsWithTag("AI");
        Player = GameObject.FindGameObjectWithTag("Player");
        checkpoint = Player.GetComponent<Checkpoints>();


        foreach (GameObject AI in AIs)
        {
            AI.gameObject.SetActive(false);
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

        StartCar(Player);
    }
    void Update()
    {
        if (checkpoint.lap > maxLaps)
        {
            StopCar(Player);
            InternalScore = CurrentScore;
            ScoreValue.GetComponent<Text>().text = "" + InternalScore;
            SaveManager.instance.cash += InternalScore/10;
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

        audioSources = car.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.enabled = true;
        }
    }
    void StopCar(GameObject car)
    {
        car.GetComponent<CarController>().enabled = false;

        if (car.GetComponent<CarUserControl>() != null)
            car.GetComponent<CarUserControl>().enabled = false;

        if (car.GetComponent<resetCar>() != null)
            car.GetComponent<resetCar>().enabled = false;


        car.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        car.GetComponent<Rigidbody>().isKinematic = true;

        audioSources = car.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.enabled = false;
        }
    }

    void OnTriggerEnter()
    {
        Reds = GameObject.FindGameObjectsWithTag("RedScore");
        foreach (GameObject Red in Reds)
        {
            CurrentScore += 50;
            Red.gameObject.SetActive(false);

        }
        Blues = GameObject.FindGameObjectsWithTag("BlueScore");
        foreach (GameObject Blue in Blues)
        {
            CurrentScore += 100;
            Blue.gameObject.SetActive(false);
        }
        Greens = GameObject.FindGameObjectsWithTag("GreenScore");
        foreach (GameObject Green in Greens)
        {
            CurrentScore += 200;
            Green.gameObject.SetActive(false);
        }
    }

}
