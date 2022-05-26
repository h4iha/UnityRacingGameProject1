using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu UI")]
    public GameObject MainmenuUI;

    [Header("Creit UI")]
    public GameObject CreditUI;

    [Header("Mode UI")]
    public GameObject SelectModeUI;
    public static int RaceMode;

    [Header("Map UI")]
    public GameObject SelectMapUI;

    [Header("Car UI")]
    public GameObject SelectCarUI;
    public Text CashText;
    public Text PriceText;
    public Text NameText;
    public Button CarBuy;
    public Button CarStart;
    public GameObject CarBlock;

    [Header("Car Attributes")]
    [SerializeField] private string[] carNames;
    [SerializeField] private int[] carPrices;
    private int currentCar;

    private void Update()
    {
        CashText.text = SaveManager.instance.cash + "$";
        //Check if we have enough money
        if (CarBuy.gameObject.activeInHierarchy)
            CarBuy.interactable = (SaveManager.instance.cash >= carPrices[currentCar]);
    }

    //Main Menu
    public void MenuPlayButton()
    {
        CashText.text =SaveManager.instance.cash.ToString() + "$";
        MainmenuUI.SetActive(false);
        CreditUI.SetActive(false);
        SelectModeUI.SetActive(false);
        SelectMapUI.SetActive(false);
        SelectCarUI.SetActive(true);
    }

    public void MenuCreditButton()
    {
        MainmenuUI.SetActive(false);
        CreditUI.SetActive(true);
        SelectModeUI.SetActive(false);
        SelectMapUI.SetActive(false);
        SelectCarUI.SetActive(false);
    }
    public void MenuQuitButton()
    {
        Application.Quit();
    }

    //Credit
    public void CreditBackButton()
    {
        MainmenuUI.SetActive(true);
        CreditUI.SetActive(false);
        SelectModeUI.SetActive(false);
        SelectMapUI.SetActive(false);
        SelectCarUI.SetActive(false);
    }

    //Car
    private void Start()
    {
        MainmenuUI.SetActive(true);
        CreditUI.SetActive(false);
        SelectModeUI.SetActive(false);
        SelectMapUI.SetActive(false);
        SelectCarUI.SetActive(false);

        currentCar = SaveManager.instance.currentCar;
        SelectCar(currentCar);
    }
    private void SelectCar(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);

        UpdateUI();
    }
    private void UpdateUI()
    {
        NameText.text = carNames[currentCar];

        //If current car unlocked show the play button
        if (SaveManager.instance.carsUnlocked[currentCar] == true)
        {
            CarStart.gameObject.SetActive(true);
            CarBlock.gameObject.SetActive(false);
            CarBuy.gameObject.SetActive(false);
            PriceText.text = "Owned";
        }
        //If not show the buy button and set the price
        else
        {
            CarStart.gameObject.SetActive(false);
            CarBlock.gameObject.SetActive(true);
            CarBuy.gameObject.SetActive(true);
            PriceText.text = carPrices[currentCar] + "$";
        }
    }
    public void CarStartButton()
    {
        MainmenuUI.SetActive(false);
        CreditUI.SetActive(false);
        SelectModeUI.SetActive(true);
        SelectMapUI.SetActive(false);
        SelectCarUI.SetActive(false);
    }

    public void CarBuyButton()
    {
        SaveManager.instance.cash -= carPrices[currentCar];
        SaveManager.instance.carsUnlocked[currentCar] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }
    public void ChangeCar(int _change)
    {
        currentCar += _change;

        if (currentCar > transform.childCount - 1)
            currentCar = 0;
        else if (currentCar < 0)
            currentCar = transform.childCount - 1;

        SaveManager.instance.currentCar = currentCar;
        SaveManager.instance.Save();
        SelectCar(currentCar);
    }
    public void CarBackButton()
    {
        MainmenuUI.SetActive(true);
        CreditUI.SetActive(false);
        SelectModeUI.SetActive(false);
        SelectMapUI.SetActive(false);
        SelectCarUI.SetActive(false);
    }

    //Mode
    public void RaceModeButton()
    {
        RaceMode = 0;
        MainmenuUI.SetActive(false);
        CreditUI.SetActive(false);
        SelectModeUI.SetActive(false);
        SelectMapUI.SetActive(true);
        SelectCarUI.SetActive(false);
    }
    public void ScoreModeButton()
    {
        RaceMode = 1;
        MainmenuUI.SetActive(false);
        CreditUI.SetActive(false);
        SelectModeUI.SetActive(false);
        SelectMapUI.SetActive(true);
        SelectCarUI.SetActive(false);
    }
    public void TimeModeButton()
    {
        RaceMode = 2;
        MainmenuUI.SetActive(false);
        CreditUI.SetActive(false);
        SelectModeUI.SetActive(false);
        SelectMapUI.SetActive(true);
        SelectCarUI.SetActive(false);
    }
    public void ModeBackButton()
    {
        MainmenuUI.SetActive(true);
        CreditUI.SetActive(false);
        SelectModeUI.SetActive(false);
        SelectMapUI.SetActive(false);
        SelectCarUI.SetActive(false);
    }

    //Map
    public void Map1Button()
    {
        SceneManager.LoadScene("Map1Scene");
    }
    public void Map2Button()
    {
        SceneManager.LoadScene("Map2Scene");
    }
    public void Map3Button()
    {
        SceneManager.LoadScene("Map3Scene");
    }
    public void MapBackButton()
    {
        MainmenuUI.SetActive(true);
        CreditUI.SetActive(false);
        SelectModeUI.SetActive(false);
        SelectMapUI.SetActive(false);
        SelectCarUI.SetActive(false);
    }
}
