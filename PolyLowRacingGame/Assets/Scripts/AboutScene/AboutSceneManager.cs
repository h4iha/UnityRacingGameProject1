using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutSceneManager : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
