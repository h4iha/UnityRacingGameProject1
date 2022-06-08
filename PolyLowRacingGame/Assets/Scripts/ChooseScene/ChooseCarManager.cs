using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseCarManager : MonoBehaviour
{
    public int totalCar;
    public int currentCar;
    public int currentColor;

    public GameObject CarPlayer;
    AudioSource[] audioSources;

    public Text nameCarCurentText;
    public Text totalMoneyText;
    public Text priceCarCurrentText;

    public Button nextButton;
    public Button buyButton;

    [Header("Car Attributes")]
    [SerializeField] private string[] carNames;
    [SerializeField] private int[] carPrices;

    [Header("Mazda")]
    public Image MazdaLogo;
    public GameObject MazdaBody;
    public GameObject MazdaRed;
    public GameObject MazdaYellow;
    public GameObject MazdaGreen;
    public GameObject MazdaBlue;
    public GameObject MazdaBlack;
    public GameObject MazdaOrange;

    [Header("Peugeot")]
    public Image PeugeotLogo;
    public GameObject PeugeotBody;
    public GameObject PeugeotRed;
    public GameObject PeugeotYellow;
    public GameObject PeugeotGreen;
    public GameObject PeugeotBlue;
    public GameObject PeugeotBlack;
    public GameObject PeugeotOrange;


    [Header("Chevrolet")]
    public Image ChevroletLogo;
    public GameObject ChevroletBody;
    public GameObject ChevroletRed;
    public GameObject ChevroletYellow;
    public GameObject ChevroletGreen;
    public GameObject ChevroletBlue;
    public GameObject ChevroletBlack;
    public GameObject ChevroletOrange;

    void Start() {
        totalMoneyText.text = SaveManager.instance.totalMoney.ToString();
        currentCar = SaveManager.instance.currentCar;
        currentColor = SaveManager.instance.currentColor;
        SelectCar(currentCar);
    }

    // Update is called once per frame
    void Update() {
        audioSources = CarPlayer.GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.enabled = false;
        }

        totalMoneyText.text = SaveManager.instance.totalMoney.ToString();
        if (buyButton.gameObject.activeInHierarchy)
            buyButton.interactable = (SaveManager.instance.totalMoney >= carPrices[currentCar]);
    }

    public void ChangeCar(int _change) {
        currentCar += _change;

        if (currentCar > totalCar - 1)
            currentCar = 0;
        else if (currentCar < 0)
            currentCar = totalCar - 1;
        SaveManager.instance.currentCar = currentCar;
        SaveManager.instance.Save();
        SelectCar(currentCar);
    }
    private void SelectCar(int _index) {

        UpdateUI();

        if(_index == 0) {
            MazdaLogo.gameObject.SetActive(true);
            PeugeotLogo.gameObject.SetActive(false);
            ChevroletLogo.gameObject.SetActive(false);

            MazdaBody.gameObject.SetActive(true);
            PeugeotBody.gameObject.SetActive(false);
            ChevroletBody.gameObject.SetActive(false);
        }
        else if(_index == 1) {
            MazdaLogo.gameObject.SetActive(false);
            PeugeotLogo.gameObject.SetActive(true);
            ChevroletLogo.gameObject.SetActive(false);

            MazdaBody.gameObject.SetActive(false);
            PeugeotBody.gameObject.SetActive(true);
            ChevroletBody.gameObject.SetActive(false);
        }
        else if(_index == 2) {
            MazdaLogo.gameObject.SetActive(false);
            PeugeotLogo.gameObject.SetActive(false);
            ChevroletLogo.gameObject.SetActive(true);

            MazdaBody.gameObject.SetActive(false);
            PeugeotBody.gameObject.SetActive(false);
            ChevroletBody.gameObject.SetActive(true);
        }
    }

    private void UpdateUI() {
        nameCarCurentText.text = carNames[currentCar].ToString();

        //If current car unlocked show the play button
        if (SaveManager.instance.carsUnlocked[currentCar] == true)
        {
            buyButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);
        }
        //If not show the buy button and set the price
        else
        {
            buyButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
            priceCarCurrentText.text = "Buy " + carPrices[currentCar].ToString() + " $";
        }
    }

    public void BuyButton() {
        SaveManager.instance.totalMoney -= carPrices[currentCar];
        SaveManager.instance.carsUnlocked[currentCar] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }

    public void BackButton() {
        SceneManager.LoadScene("MainScene");
    }

    public void NextButton() {
        SceneManager.LoadScene("ChooseMapScene");
    }

    #region Color
    public void ColorRed() {
        currentColor = 0;
        SaveManager.instance.currentColor = currentColor;
        SaveManager.instance.Save();
        
        MazdaRed.gameObject.SetActive(true);
        MazdaYellow.gameObject.SetActive(false);
        MazdaGreen.gameObject.SetActive(false);
        MazdaBlue.gameObject.SetActive(false);
        MazdaBlack.gameObject.SetActive(false);
        MazdaOrange.gameObject.SetActive(false);

        PeugeotRed.gameObject.SetActive(true);
        PeugeotYellow.gameObject.SetActive(false);
        PeugeotGreen.gameObject.SetActive(false);
        PeugeotBlue.gameObject.SetActive(false);
        PeugeotBlack.gameObject.SetActive(false);
        PeugeotOrange.gameObject.SetActive(false);

        ChevroletRed.gameObject.SetActive(true);
        ChevroletYellow.gameObject.SetActive(false);
        ChevroletGreen.gameObject.SetActive(false);
        ChevroletBlue.gameObject.SetActive(false);
        ChevroletBlack.gameObject.SetActive(false);
        ChevroletOrange.gameObject.SetActive(false);
    }
    public void ColorYellow() {
        currentColor = 1;
        SaveManager.instance.currentColor = currentColor;
        SaveManager.instance.Save();

        MazdaRed.gameObject.SetActive(false);
        MazdaYellow.gameObject.SetActive(true);
        MazdaGreen.gameObject.SetActive(false);
        MazdaBlue.gameObject.SetActive(false);
        MazdaBlack.gameObject.SetActive(false);
        MazdaOrange.gameObject.SetActive(false);

        PeugeotRed.gameObject.SetActive(false);
        PeugeotYellow.gameObject.SetActive(true);
        PeugeotGreen.gameObject.SetActive(false);
        PeugeotBlue.gameObject.SetActive(false);
        PeugeotBlack.gameObject.SetActive(false);
        PeugeotOrange.gameObject.SetActive(false);

        ChevroletRed.gameObject.SetActive(false);
        ChevroletYellow.gameObject.SetActive(true);
        ChevroletGreen.gameObject.SetActive(false);
        ChevroletBlue.gameObject.SetActive(false);
        ChevroletBlack.gameObject.SetActive(false);
        ChevroletOrange.gameObject.SetActive(false);
    }
    public void ColorGreen() {
        currentColor = 2;
        SaveManager.instance.currentColor = currentColor;
        SaveManager.instance.Save();
        
        MazdaRed.gameObject.SetActive(false);
        MazdaYellow.gameObject.SetActive(false);
        MazdaGreen.gameObject.SetActive(true);
        MazdaBlue.gameObject.SetActive(false);
        MazdaBlack.gameObject.SetActive(false);
        MazdaOrange.gameObject.SetActive(false);

        PeugeotRed.gameObject.SetActive(false);
        PeugeotYellow.gameObject.SetActive(false);
        PeugeotGreen.gameObject.SetActive(true);
        PeugeotBlue.gameObject.SetActive(false);
        PeugeotBlack.gameObject.SetActive(false);
        PeugeotOrange.gameObject.SetActive(false);

        ChevroletRed.gameObject.SetActive(false);
        ChevroletYellow.gameObject.SetActive(false);
        ChevroletGreen.gameObject.SetActive(true);
        ChevroletBlue.gameObject.SetActive(false);
        ChevroletBlack.gameObject.SetActive(false);
        ChevroletOrange.gameObject.SetActive(false);
    }
    public void ColorBlue() {
        currentColor = 3;
        SaveManager.instance.currentColor = currentColor;
        SaveManager.instance.Save();

        MazdaRed.gameObject.SetActive(false);
        MazdaYellow.gameObject.SetActive(false);
        MazdaGreen.gameObject.SetActive(false);
        MazdaBlue.gameObject.SetActive(true);
        MazdaBlack.gameObject.SetActive(false);
        MazdaOrange.gameObject.SetActive(false);

        PeugeotRed.gameObject.SetActive(false);
        PeugeotYellow.gameObject.SetActive(false);
        PeugeotGreen.gameObject.SetActive(false);
        PeugeotBlue.gameObject.SetActive(true);
        PeugeotBlack.gameObject.SetActive(false);
        PeugeotOrange.gameObject.SetActive(false);

        ChevroletRed.gameObject.SetActive(false);
        ChevroletYellow.gameObject.SetActive(false);
        ChevroletGreen.gameObject.SetActive(false);
        ChevroletBlue.gameObject.SetActive(true);
        ChevroletBlack.gameObject.SetActive(false);
        ChevroletOrange.gameObject.SetActive(false);
    }
    public void ColorBlack() {
        currentColor = 4;
        SaveManager.instance.currentColor = currentColor;
        SaveManager.instance.Save();

        MazdaRed.gameObject.SetActive(false);
        MazdaYellow.gameObject.SetActive(false);
        MazdaGreen.gameObject.SetActive(false);
        MazdaBlue.gameObject.SetActive(false);
        MazdaBlack.gameObject.SetActive(true);
        MazdaOrange.gameObject.SetActive(false);

        PeugeotRed.gameObject.SetActive(false);
        PeugeotYellow.gameObject.SetActive(false);
        PeugeotGreen.gameObject.SetActive(false);
        PeugeotBlue.gameObject.SetActive(false);
        PeugeotBlack.gameObject.SetActive(true);
        PeugeotOrange.gameObject.SetActive(false);

        ChevroletRed.gameObject.SetActive(false);
        ChevroletYellow.gameObject.SetActive(false);
        ChevroletGreen.gameObject.SetActive(false);
        ChevroletBlue.gameObject.SetActive(false);
        ChevroletBlack.gameObject.SetActive(true);
        ChevroletOrange.gameObject.SetActive(false);
    }
    public void ColorOrange() {
        currentColor = 5;
        SaveManager.instance.currentColor = currentColor;
        SaveManager.instance.Save();

        MazdaRed.gameObject.SetActive(false);
        MazdaYellow.gameObject.SetActive(false);
        MazdaGreen.gameObject.SetActive(false);
        MazdaBlue.gameObject.SetActive(false);
        MazdaBlack.gameObject.SetActive(false);
        MazdaOrange.gameObject.SetActive(true);

        PeugeotRed.gameObject.SetActive(false);
        PeugeotYellow.gameObject.SetActive(false);
        PeugeotGreen.gameObject.SetActive(false);
        PeugeotBlue.gameObject.SetActive(false);
        PeugeotBlack.gameObject.SetActive(false);
        PeugeotOrange.gameObject.SetActive(true);

        ChevroletRed.gameObject.SetActive(false);
        ChevroletYellow.gameObject.SetActive(false);
        ChevroletGreen.gameObject.SetActive(false);
        ChevroletBlue.gameObject.SetActive(false);
        ChevroletBlack.gameObject.SetActive(false);
        ChevroletOrange.gameObject.SetActive(true);
    }
    #endregion
}
