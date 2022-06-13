using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CountDown : MonoBehaviour
{
    public GameObject Player;
    public GameObject AIWhite;
    public GameObject AIYellow;
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UIGO;

    public AudioSource audioCount1;
    public AudioSource audioCount2;
    public AudioSource audioCount3;
    public AudioSource audioGo;
    public AudioSource audioSongTheme1;


    // Start is called before the first frame update
    void Start()
    {
        UI1.SetActive(false);
        UI2.SetActive(false);
        UI3.SetActive(false);
        UIGO.SetActive(false);
        StopCar(Player);
        StopCar(AIWhite);
        StopCar(AIYellow);
        StartCoroutine(CountStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);

        UI3.SetActive(true);
        audioCount3.Play();
        yield return new WaitForSeconds(0.5f);
        UI3.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        UI2.SetActive(true);
        audioCount2.Play();
        yield return new WaitForSeconds(0.5f);
        UI2.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        UI1.SetActive(true);
        audioCount1.Play();
        yield return new WaitForSeconds(0.5f);
        UI1.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        UIGO.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        audioGo.Play();
        UIGO.SetActive(false);

        audioSongTheme1.Play();

        StartCar(Player);
        StartCar(AIWhite);
        StartCar(AIYellow);
    }

    public void StartCar(GameObject car)
    {
        car.GetComponent<CarController>().enabled = true;

        if (car.GetComponent<CarUserControl>() != null)
            car.GetComponent<CarUserControl>().enabled = true;

        if (car.GetComponent<CarAIControl>() != null)
            car.GetComponent<CarAIControl>().enabled = true;

        car.GetComponent<Rigidbody>().isKinematic = false;
    }
    public void StopCar(GameObject car)
    {
        car.GetComponent<CarController>().enabled = false;

        if (car.GetComponent<CarUserControl>() != null)
            car.GetComponent<CarUserControl>().enabled = false;

        if (car.GetComponent<CarAIControl>() != null)
            car.GetComponent<CarAIControl>().enabled = false;

        car.GetComponent<Rigidbody>().isKinematic = true;
    }
}
