using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CountDown : MonoBehaviour
{
    public GameObject Player;
    public GameObject AI;
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UIGO;
    
    AudioSource[] audioSources;

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
        AI.gameObject.SetActive(false);
        if(SaveManager.instance.currentMode == 0) AI.gameObject.SetActive(true);
        StopCar(Player);
        StopCar(AI);
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
        audioGo.Play();
        yield return new WaitForSeconds(0.5f);
        UIGO.SetActive(false);

        audioSongTheme1.Play();
        StartCar(Player);
        StartCar(AI);
    }

    public void StartCar(GameObject car)
    {
        audioSources = car.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.enabled = true;
        }
        car.GetComponent<CarController>().enabled = true;

        if (car.GetComponent<CarUserControl>() != null)
            car.GetComponent<CarUserControl>().enabled = true;

        if (car.GetComponent<CarAIControl>() != null)
            car.GetComponent<CarAIControl>().enabled = true;

        car.GetComponent<Rigidbody>().isKinematic = false;
    }
    public void StopCar(GameObject car)
    {
        audioSources = car.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.enabled = false;
        }
        car.GetComponent<CarController>().enabled = false;

        if (car.GetComponent<CarUserControl>() != null)
            car.GetComponent<CarUserControl>().enabled = false;

        if (car.GetComponent<CarAIControl>() != null)
            car.GetComponent<CarAIControl>().enabled = false;

        car.GetComponent<Rigidbody>().isKinematic = true;
    }
}
