using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start() {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }

    public void resume() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void mainmenu() {
        SceneManager.LoadScene("ChooseMapScene");
    }
}
