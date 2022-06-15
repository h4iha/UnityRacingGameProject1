using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarStart : MonoBehaviour
{
    public int currentCar;
    public int currentColor;
    [Header("Mazda")]
    public GameObject MazdaBody;
    public GameObject MazdaRed;
    public GameObject MazdaYellow;
    public GameObject MazdaGreen;
    public GameObject MazdaBlue;
    public GameObject MazdaBlack;
    public GameObject MazdaOrange;

    [Header("Peugeot")]
    public GameObject PeugeotBody;
    public GameObject PeugeotRed;
    public GameObject PeugeotYellow;
    public GameObject PeugeotGreen;
    public GameObject PeugeotBlue;
    public GameObject PeugeotBlack;
    public GameObject PeugeotOrange;


    [Header("Chevrolet")]
    public GameObject ChevroletBody;
    public GameObject ChevroletRed;
    public GameObject ChevroletYellow;
    public GameObject ChevroletGreen;
    public GameObject ChevroletBlue;
    public GameObject ChevroletBlack;
    public GameObject ChevroletOrange;

    
    // Start is called before the first frame update
    void Start()
    {
        currentCar = SaveManager.instance.currentCar;
        currentColor = SaveManager.instance.currentColor;
        
        SelectCar(currentCar);
        SelectColor(currentColor);
    }

    // Update is called once per frame
    void Update()
    {
        SelectCar(currentCar);
        SelectColor(currentColor);
    }

    private void SelectCar(int _index) {

        if(_index == 0) {
            MazdaBody.gameObject.SetActive(true);
            PeugeotBody.gameObject.SetActive(false);
            ChevroletBody.gameObject.SetActive(false);
        }
        else if(_index == 1) {
            MazdaBody.gameObject.SetActive(false);
            PeugeotBody.gameObject.SetActive(true);
            ChevroletBody.gameObject.SetActive(false);
        }
        else if(_index == 2) {
            MazdaBody.gameObject.SetActive(false);
            PeugeotBody.gameObject.SetActive(false);
            ChevroletBody.gameObject.SetActive(true);
        }
    }

    private void SelectColor(int _index) {

        if(_index == 0) {
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
        else if(_index == 1) {
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
        else if(_index == 2) {
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
        else if(_index == 3) {
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
        else if(_index == 4) {
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
        else if(_index == 5) {
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
    }

}
