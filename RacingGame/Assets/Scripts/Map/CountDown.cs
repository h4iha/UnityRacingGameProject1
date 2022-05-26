using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CountDown : MonoBehaviour
{
    [HideInInspector]
    GameObject Player;
    [HideInInspector]
    GameObject AIcar1;
    [HideInInspector]
    GameObject AIcar2;
    [HideInInspector]
    GameObject AIcar3;
    public GameObject CountdownUI;
    public AudioSource audioCount1;
    public AudioSource audioCount2;
    public AudioSource audioCount3;
    public AudioSource audioGo;
    public AudioSource audioSongTheme1;
    public AudioSource audioSongTheme2;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AIcar1 = GameObject.FindGameObjectWithTag("AIcar1");
        AIcar2 = GameObject.FindGameObjectWithTag("AIcar2");
        AIcar3 = GameObject.FindGameObjectWithTag("AIcar3");

        CountdownUI.SetActive(false);

        StartCoroutine(CountStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);

        CountdownUI.GetComponent<Text>().text = "3";
        CountdownUI.SetActive(true);
        audioCount3.Play();
        CountdownUI.SetActive(false);
        yield return new WaitForSeconds(1.0f);

        CountdownUI.GetComponent<Text>().text = "2";
        CountdownUI.SetActive(true);
        audioCount2.Play();
        CountdownUI.SetActive(false);
        yield return new WaitForSeconds(1.0f);

        CountdownUI.GetComponent<Text>().text = "1";
        CountdownUI.SetActive(true);
        audioCount1.Play();
        CountdownUI.SetActive(false);
        yield return new WaitForSeconds(1.0f);

        CountdownUI.GetComponent<Text>().text = "GO";
        CountdownUI.SetActive(true);
        audioGo.Play();
        CountdownUI.SetActive(false);

        audioSongTheme1.Play();

        Player.GetComponent<CarController>().enabled = true;
        Player.GetComponent<CarUserControl>().enabled = true;
        Player.GetComponent<Rigidbody>().isKinematic = false;
        /*
        AIcar1.GetComponent<CarAIControl>().enabled = true;
        AIcar1.GetComponent<CarController>().enabled = true;
        AIcar2.GetComponent<CarAIControl>().enabled = true;
        AIcar2.GetComponent<CarController>().enabled = true;
        AIcar3.GetComponent<CarAIControl>().enabled = true;
        AIcar3.GetComponent<CarController>().enabled = true;*/
    }
}
