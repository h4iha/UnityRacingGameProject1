using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CounterDown : MonoBehaviour
{

    public GameObject LapTimerManager;

    [Header("Coutdown")]
    public GameObject Countdown;
    public AudioSource Ready1;
    public AudioSource Ready2;
    public AudioSource Ready3;
    public AudioSource GoAudio;

    [Header("Car")]
    GameObject Player;
    GameObject[] AIs;
    AudioSource[] audioSourcesWheels;


    void Start()
    {
        StartCoroutine( CountStart());
    }

    IEnumerator CountStart()
    {
        AIs = GameObject.FindGameObjectsWithTag("AI");
        Player = GameObject.FindGameObjectWithTag("Player");

        yield return new WaitForSeconds(0.5f);
        Countdown.GetComponent<Text>().text = "3";
        Ready3.Play();
        Countdown.SetActive(true);

        yield return new WaitForSeconds(1);
        Countdown.SetActive(false);
        Countdown.GetComponent<Text>().text = "2";
        Ready2.Play();
        Countdown.SetActive(true);

        yield return new WaitForSeconds(1);
        Countdown.SetActive(false);
        Countdown.GetComponent<Text>().text = "1";
        Ready1.Play();
        Countdown.SetActive(true);

        yield return new WaitForSeconds(1);
        Countdown.SetActive(false);
        GoAudio.Play();

        LapTimerManager.gameObject.SetActive(true);
        StartCar(Player);
        foreach (GameObject AI in AIs)
        {
            if (CarShopManager.RaceMode == 0)
            {
                StartCar(AI);
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

        if (car.GetComponent<CarAudio>() != null)
            car.GetComponent<CarAudio>().enabled = true;

        if (car.GetComponent<CarController>() != null)
            car.GetComponent<CarController>().enabled = true;

        car.GetComponent<Rigidbody>().isKinematic = false;

        audioSourcesWheels = car.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSourcesWheels)
        {
            audioSource.enabled = true;
        }
    }
}