using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class LapAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject AI;
    AudioSource[] audioSources;
    public GameObject FinishBoard;

    private void OnTriggerEnter(Collider other) {
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
