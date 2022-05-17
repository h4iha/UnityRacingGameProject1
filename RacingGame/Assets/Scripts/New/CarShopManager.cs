using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

public class CarShopManager : MonoBehaviour
{

    [Header("Car")]
    public int currentCarIndex = 0;
    [SerializeField] private GameObject[] carColors;
    [SerializeField] private CarBluePrint[] cars;
    [SerializeField] private GameObject Body;

    [SerializeField] private Button buyButton;
    [SerializeField] private Image priceCarCoinIcon;
    [SerializeField] private Button chooseMap;

    [SerializeField] private Text carName;
    [SerializeField] private Text priceCarText;



    [Header("Menu")]
    [SerializeField] private Button clickButton;
    [SerializeField] private GameObject buttonObject;
    [SerializeField] private GameObject menuUIoObject;
    [SerializeField] private GameObject carshopUIObject;
    [SerializeField] private GameObject mapshopUIObject;
    [SerializeField] private GameObject modeUIUIObject;

    [Header("Map")]

    [SerializeField] private GameObject modeUI;
    [SerializeField] private Button raceButton;
    [SerializeField] private Button timeButton;
    [SerializeField] private Button scoreButton;

    [SerializeField] private Button playMoutain;
    [SerializeField] private Button playSnow;

    [Header("Mode")]
    public static int RaceMode; //0=Race, 1=Score, 2=Time
    public GameObject Play;

    void Start()
    {

        menuUIoObject.gameObject.SetActive(true);
        clickButton.gameObject.SetActive(true);
        buttonObject.gameObject.SetActive(false);
        carshopUIObject.gameObject.SetActive(false);
        mapshopUIObject.gameObject.SetActive(false);

        carName.text = cars[currentCarIndex].name + "";
        currentCarIndex = SaveManager.instance.currentCarIndex;
        SelectCar(currentCarIndex);
    }

    private void SelectCar(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);
        UpdateUI();
    }
    void Update()
    {

    }

    public void ChangeCar(int _change)
    {
        currentCarIndex += _change;

        if (currentCarIndex > transform.childCount - 1)
            currentCarIndex = 0;
        else if (currentCarIndex < 0)
            currentCarIndex = transform.childCount - 1;

        SaveManager.instance.currentCarIndex = currentCarIndex;
        SaveManager.instance.Save();
        SelectCar(currentCarIndex);
    }
    public void UnLockCar()
    {
        SaveManager.instance.cash -= cars[currentCarIndex].price;
        SaveManager.instance.carsUnlocked[currentCarIndex] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }
    public void ChooseMap()
    {
        mapshopUIObject.gameObject.SetActive(true);
        carshopUIObject.gameObject.SetActive(false);
        menuUIoObject.gameObject.SetActive(false);
    }
    public void BackToMenu()
    {
        menuUIoObject.gameObject.SetActive(true);
        clickButton.gameObject.SetActive(false);
        buttonObject.gameObject.SetActive(true);
        carshopUIObject.gameObject.SetActive(false);
    }
    public void UpdateUI()
    {
        carName.text = cars[currentCarIndex].name + "";
        if (SaveManager.instance.carsUnlocked[currentCarIndex]==true)
        {
            chooseMap.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
            priceCarCoinIcon.gameObject.SetActive(false);
            priceCarText.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            priceCarCoinIcon.gameObject.SetActive(true);
            priceCarText.gameObject.SetActive(true);
            priceCarText.text = cars[currentCarIndex].price + "";
            chooseMap.gameObject.SetActive(false);
        }
    }


    //Menu
    public void clickAnWhereButton()
    {
        buttonObject.gameObject.SetActive(true);
        clickButton.gameObject.SetActive(false);
    }
    public void playButton()
    {
        carshopUIObject.gameObject.SetActive(true);
        menuUIoObject.gameObject.SetActive(false);
        mapshopUIObject.gameObject.SetActive(false);
    }
    public void creditButton()
    {
        SceneManager.LoadScene("CreditScene");
    }
    public void exitButton()
    {
        Application.Quit();
    }

    //Map
    public void ChooseMode()
    {
        modeUI.gameObject.SetActive(true);
    }
    public void BackToCarShop()
    {
        mapshopUIObject.gameObject.SetActive(false);
        carshopUIObject.gameObject.SetActive(true);
        menuUIoObject.gameObject.SetActive(false);
    }

    public void ChooseMountain()
    {
        modeUI.gameObject.SetActive(true);
        playMoutain.gameObject.SetActive(true);
        playSnow.gameObject.SetActive(false);
    }

    public void ChooseSnow()
    {
        modeUI.gameObject.SetActive(true);
        playMoutain.gameObject.SetActive(false);
        playSnow.gameObject.SetActive(true);
    }

    public void Mountain()
    {
        SceneManager.LoadScene("MountainMap");
    }
    public void Snow()
    {
        SceneManager.LoadScene("SnowMap");
    }

    public void TheRaceMode()
    {
        RaceMode = 0;
        Play.gameObject.SetActive(true);
    }
    public void ScoreMode()
    {
        RaceMode = 1;
        Play.gameObject.SetActive(true);
    }
    public void TimeMode()
    {
        RaceMode = 2;
        Play.gameObject.SetActive(true);
    }
}
