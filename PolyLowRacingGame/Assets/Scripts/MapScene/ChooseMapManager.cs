using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseMapManager : MonoBehaviour
{
    public int totalMap;
    public int currentMap;
    public int currentMode;
    public int currentLap;

    public Text nameMapCurentText;
    public Text totalMoneyText;
    public Text priceMapCurrentText;
    public Text currentLapText;
    public Text currentModeText;

    public Button startButton;
    public Button buyButton;

    [Header("Map Attributes")]
    [SerializeField] private string[] mapNames;
    [SerializeField] private int[] mapPrices;

    [Header("Map 1")]
    public Image Map1;
    public Image Path1;

    [Header("Map 2")]
    public Image Map2;
    public Image Path2;

    void Start() {
        totalMoneyText.text = SaveManager.instance.totalMoney.ToString();
        currentMap = SaveManager.instance.currentMap;
        currentMode = SaveManager.instance.currentMode;

        currentLapText.text = currentLap.ToString();

        if (currentMode == 0) currentModeText.text = "Time";
        if (currentMode == 1) currentModeText.text = "Race";
        if (currentMode == 2) currentModeText.text = "Score";
        SelectMap(currentMap);
    }

    // Update is called once per frame
    void Update() {
        totalMoneyText.text = SaveManager.instance.totalMoney.ToString();
        
        if (buyButton.gameObject.activeInHierarchy)
            buyButton.interactable = (SaveManager.instance.totalMoney >= mapPrices[currentMap]);
    }

    public void ChangeMap(int _change) {
        currentMap += _change;

        if (currentMap > totalMap - 1)
            currentMap = 0;
        else if (currentMap < 0)
            currentMap = totalMap - 1;
        SaveManager.instance.currentMap = currentMap;
        SaveManager.instance.Save();
        SelectMap(currentMap);
    }
    private void SelectMap(int _index) {

        UpdateUI();

        if(_index == 0) {
            Map1.gameObject.SetActive(true);
            Map2.gameObject.SetActive(false);

            Path1.gameObject.SetActive(true);
            Path2.gameObject.SetActive(false);
        }
        else if(_index == 1) {
            Map1.gameObject.SetActive(false);
            Map2.gameObject.SetActive(true);

            Path1.gameObject.SetActive(false);
            Path2.gameObject.SetActive(true);
        }
    }

    private void UpdateUI() {
        nameMapCurentText.text = mapNames[currentMap].ToString();

        //If current car unlocked show the play button
        if (SaveManager.instance.mapsUnlocked[currentMap] == true)
        {
            buyButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
        }
        //If not show the buy button and set the price
        else
        {
            buyButton.gameObject.SetActive(true);
            startButton.gameObject.SetActive(false);
            priceMapCurrentText.text = mapPrices[currentMap].ToString() + "$";
        }
    }

    public void BuyButton() {
        SaveManager.instance.totalMoney -= mapPrices[currentMap];
        SaveManager.instance.mapsUnlocked[currentMap] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }

    public void BackButton() {
        SceneManager.LoadScene("ChooseCarScene");
    }

    public void StartButton() {
        if(currentMap == 0) {
            SceneManager.LoadScene("Map1");
        }
        else if(currentMap == 1) {
            SceneManager.LoadScene("Map2");    
        }
    }

    public void ChangeLap() {
        currentLap += 1;
        if (currentLap > 3) currentLap = 1;

        currentLapText.text = currentLap.ToString();

        SaveManager.instance.currentLap = currentLap;
        SaveManager.instance.Save();
    }

    public void ChangeMode() {
        currentMode += 1;
        if (currentMode > 2) currentMode = 0;

        if (currentMode == 0) currentModeText.text = "Time";
        if (currentMode == 1) currentModeText.text = "Race";
        if (currentMode == 2) currentModeText.text = "Score";

        SaveManager.instance.currentMode = currentMode;
        SaveManager.instance.Save();
    }
}
