using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    GameObject Player;
    public GameObject missedcheckpointText;
    public GameObject pauseGameMenu;
    public GameObject positionText;
    public GameObject lapText;
    Checkpoints checkpoints;
    public Text finalPosText;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        checkpoints = Player.GetComponent<Checkpoints>();
    }

    void Update()
    {
        if (checkpoints.checkPoint == 0)
        {
            lapText.GetComponent<Text>().text = "Lap: " + checkpoints.lap;
        }
        positionText.GetComponent<Text>().text = "Position: " + CalculatePositions.GetPositions(Player.name);
        if(Player.GetComponent<Checkpoints>().missed == true)
        {
            StartCoroutine(showmissedCheckpointtext());
            Player.GetComponent<Checkpoints>().missed = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGameMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator showmissedCheckpointtext()
    {
        missedcheckpointText.SetActive(true);
        yield return new WaitForSeconds(2);
        missedcheckpointText.SetActive(false);
    }

    public void ResumeGame()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void showfinalPos()
    {
        if(CalculatePositions.GetPositions(Player.name) == "1st")
        {
            SaveManager.instance.cash += 1000;
        }
        else if(CalculatePositions.GetPositions(Player.name) == "2nd")
        {
            SaveManager.instance.cash += 500;
        }
        else if (CalculatePositions.GetPositions(Player.name) == "3rd")
        {
            SaveManager.instance.cash += 200;
        }
        else if (CalculatePositions.GetPositions(Player.name) == "4th")
        {
            SaveManager.instance.cash += 100;
        }



        finalPosText.text = "Your Position: " + CalculatePositions.GetPositions(Player.name);

        
    }
    public void loadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
