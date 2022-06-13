using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityStandardAssets.Vehicles.Car;

public class Checkpoints : MonoBehaviour
{
    [HideInInspector]
    public GameObject CarPlayer;
    [HideInInspector]
    public GameObject AICarWhite;
    [HideInInspector]
    public GameObject AICarYellow;

    public GameObject Player;
    public GameObject AIWhite;
    public GameObject AIYellow;


    [HideInInspector]
    public int AIWhiteLap = 0, AIYellowLap = 0;
    public int lapTotal = 2;

    [HideInInspector]
    public int lapCurrent = 0;
    [HideInInspector]
    public int checkpoint = -1;
    int checkpointCount;
    int nextCheckpoint = 0;
    Dictionary<int, bool> visited = new Dictionary<int, bool>();
    public Text lapText;
    [HideInInspector]
    public bool missed = false;
    public GameObject PrevCheckpoint;

    [Header("Finish")]
    CheckpointSystem checkpointSystem;
    public Image image1;
    public Image image2;
    public Image image3;
    public Text textGold;
    public GameObject leaderBoard;

    AudioSource[] audioSources;
    // Start is called before the first frame update
    void Start()
    {
        CarPlayer = GameObject.FindGameObjectWithTag("Player");
        AICarWhite = GameObject.FindGameObjectWithTag("AIWhite");
        AICarYellow = GameObject.FindGameObjectWithTag("AIYellow");
        leaderBoard.SetActive(false);


        GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        checkpointCount = checkpoints.Length;
        foreach (GameObject chpoint in checkpoints)
        {
            if (chpoint.name == "0")
            {
                PrevCheckpoint = chpoint;
                break;
            }
        }

        foreach (GameObject cp in checkpoints)
        {
            visited.Add(Int32.Parse(cp.name), false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkpoint")
        {
            int checkpointCurrent = int.Parse(other.gameObject.name);
            if (checkpointCurrent == nextCheckpoint)
            {
                PrevCheckpoint = other.gameObject;
                visited[checkpointCurrent] = true;
                checkpoint = checkpointCurrent;

                //**************************************************
                if (checkpoint == 0 && gameObject.tag == "Player")
                {
                    lapCurrent++;
                    lapText.text = lapCurrent + " / " + lapTotal;
                }
                
                else if (checkpoint == 0 && gameObject.tag == "AIWhite")
                {
                    AIWhiteLap++;
                }
                else if (checkpoint == 0 && gameObject.tag == "AIYellow")
                {
                    AIYellowLap++;
                }
                //*****************************************************

                nextCheckpoint++;
                if (nextCheckpoint >= checkpointCount)
                {
                    var keys = new List<int>(visited.Keys);
                    foreach (int key in keys)
                    {
                        visited[key] = false;
                    }
                    nextCheckpoint = 0;
                }
            }
            else if (checkpointCurrent != nextCheckpoint && visited[checkpointCurrent] == false)
            {
                missed = true;
            }
        }

        //**************************************************************************************************
        if (other.gameObject.tag == "Finish")
        {
            if (lapCurrent == (lapTotal + 1) && gameObject.tag == "Player")
            {
                StopCar(Player);
                StopCar(AIWhite);
                StopCar(AIYellow);

                leaderBoard.SetActive(true);

                image1.gameObject.SetActive(true);
                image2.gameObject.SetActive(false);
                image3.gameObject.SetActive(false);
                textGold.text = "+ 200";
            }
            else if (AIWhiteLap == (lapTotal + 1) && gameObject.tag == "AIWhite")
            {
                StopCar(Player);
                StopCar(AIWhite);
                StopCar(AIYellow);
                leaderBoard.SetActive(true);

                if (checkpointSystem.YourPos == 2)
                {
                    image1.gameObject.SetActive(false);
                    image2.gameObject.SetActive(true);
                    image3.gameObject.SetActive(false);
                    textGold.text = "+ 100";
                }

                else if (checkpointSystem.YourPos == 3)
                {
                    image1.gameObject.SetActive(false);
                    image2.gameObject.SetActive(false);
                    image3.gameObject.SetActive(true);
                    textGold.text = "+ 50";
                }
            }
            else if (AIYellowLap == (lapTotal + 1) && gameObject.tag == "AIYellow")
            {
                StopCar(Player);
                StopCar(AIWhite);
                StopCar(AIYellow);
                leaderBoard.SetActive(true);

                if (checkpointSystem.YourPos == 2)
                {
                    image1.gameObject.SetActive(false);
                    image2.gameObject.SetActive(true);
                    image3.gameObject.SetActive(false);
                    textGold.text = "+ 100";
                }

                else if (checkpointSystem.YourPos == 3)
                {
                    image1.gameObject.SetActive(false);
                    image2.gameObject.SetActive(false);
                    image3.gameObject.SetActive(true);
                    textGold.text = "+ 50";
                }
            }
        }

    }

    public void StopCar(GameObject car)
    {
        audioSources = car.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.enabled = false;
        }
        if (car.GetComponent<CarUserControl>() != null)
            car.GetComponent<CarUserControl>().enabled = false;

        car.GetComponent<CarController>().enabled = false;

        if (car.GetComponent<CarAIControl>() != null)
            car.GetComponent<CarAIControl>().enabled = false;

        car.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        car.GetComponent<Rigidbody>().isKinematic = true;
    }

}
