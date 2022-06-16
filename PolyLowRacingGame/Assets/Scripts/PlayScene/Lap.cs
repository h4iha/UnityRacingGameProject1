using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class Lap : MonoBehaviour
{
    public GameObject Player;
    public GameObject AI;
    AudioSource[] audioSources;

    public GameObject ScoringObject;

    public GameObject FinishBoard;
    public GameObject HalfTriggerObject;
    public GameObject FinishTriggerObject;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {

            HalfTriggerObject.gameObject.SetActive(true);
            FinishTriggerObject.gameObject.SetActive(false);

            SaveScript.LapNumber++;
            SaveScript.LapChange = true;
            if(SaveScript.LapNumber == 2) {
                //finish Time Mode
                if(SaveManager.instance.currentMode == 1){
                    StopCar(Player);
                    if(SaveManager.instance.currentMap == 0) {
                        SaveManager.instance.RaceMin = SaveScript.LapTimeMinutes;
                        SaveManager.instance.RaceSec = SaveScript.LapTimeSeconds;
                        SaveManager.instance.Save();
                    }
                    FinishBoard.gameObject.SetActive(true);
                }

                //finish Score Mode
                if(SaveManager.instance.currentMode == 2) {
                    StopCar(Player);
                    FinishBoard.gameObject.SetActive(true);
                }
            }
            if(SaveManager.instance.currentMode == 0) {
                if(SaveManager.instance.currentTotalLap == 1) {
                    if(SaveScript.LapNumber == 2) {
                        SaveScript.finishPosition = "1st";
                        StopCar(Player);
                        StopCar(AI);
                        FinishBoard.gameObject.SetActive(true);
                    }

                }
                if(SaveManager.instance.currentTotalLap == 2) {
                    if(SaveScript.LapNumber == 3) {
                        SaveScript.finishPosition = "1st";
                        StopCar(Player);
                        StopCar(AI);
                        FinishBoard.gameObject.SetActive(true);
                    }
                }
                if(SaveManager.instance.currentTotalLap == 3) {
                    if(SaveScript.LapNumber == 4) {
                        SaveScript.finishPosition = "1st";
                        StopCar(Player);
                        StopCar(AI);
                        FinishBoard.gameObject.SetActive(true);
                    }
                }
            }
        }
        if(other.gameObject.CompareTag("AI")) {
            SaveScript.LapAINumber++;

            if(SaveManager.instance.currentMode == 0) {
                if(SaveManager.instance.currentTotalLap == 1) {
                    if(SaveScript.LapAINumber == 2) {
                        SaveScript.finishPosition = "2nd";
                        StopCar(Player);
                        StopCar(AI);
                        FinishBoard.gameObject.SetActive(true);
                    }

                }
                if(SaveManager.instance.currentTotalLap == 2) {
                    if(SaveScript.LapAINumber == 3) {
                        SaveScript.finishPosition = "2nd";
                        StopCar(Player);
                        StopCar(AI);
                        FinishBoard.gameObject.SetActive(true);
                    }
                }
                if(SaveManager.instance.currentTotalLap == 3) {
                    if(SaveScript.LapAINumber == 4) {
                        SaveScript.finishPosition = "2nd";
                        StopCar(Player);
                        StopCar(AI);
                        FinishBoard.gameObject.SetActive(true);
                    }
                }
            }
        }
        
    }
 
    void Start() {
        
    }

    void Update()
    {
        
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
