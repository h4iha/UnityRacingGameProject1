using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("ChooseCarScene");
    }
    public void AboutButton()
    {
        SceneManager.LoadScene("AboutScene");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
