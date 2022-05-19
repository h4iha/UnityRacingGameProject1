using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CounterDown : MonoBehaviour
{
    [Header("Coutdown")]
    public GameObject Countdown;
    public AudioSource Ready1;
    public AudioSource Ready2;
    public AudioSource Ready3;
    public AudioSource GoAudio;

    [Header("Car")]
    public GameObject Player;


    void Start()
    {
        Player.GetComponent<CarUserControl>().enabled = false;
        StartCoroutine( CountStart());
    }

    IEnumerator CountStart()
    {

        yield return new WaitForSeconds(0.5f);

        Countdown.GetComponent<Text>().text = "3";
        Ready3.Play();
        Countdown.SetActive(true);
        yield return new WaitForSeconds(1);
        Countdown.SetActive(false);
        GoAudio.Play();

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

        Player.GetComponent<CarUserControl>().enabled = true;
        SaveSystem.RaceStart = true;

    }
}