using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    int x = 0;
    [HideInInspector]
    GameObject Player;
    [HideInInspector]
    GameObject[] AIs;

    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        AIs = GameObject.FindGameObjectsWithTag("AI");
        
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(x == 0)
            {
                Player.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 0;
                Player.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 0;
                foreach (GameObject AI in AIs)
                {
                    AI.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 0;
                    AI.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 0;
                }
                Time.timeScale = 0;
                x = 1;
                pauseMenu.SetActive(true);
            }
            else if (x == 1)
            {
                Player.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 1;
                Player.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 5; 
                foreach (GameObject AI in AIs)
                {
                    AI.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 1;
                    AI.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 5;
                }
                Time.timeScale = 1;
                x = 0;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void resume()
    {
        Player.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 1;
        Player.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 5;
        foreach (GameObject AI in AIs)
        {
            AI.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMin = 1;
            AI.GetComponent<UnityStandardAssets.Vehicles.Car.CarAudio>().lowPitchMax = 5;
        }
        Time.timeScale = 1;
        x = 0;
        pauseMenu.SetActive(false);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("MainmenuScene");
    }
}
