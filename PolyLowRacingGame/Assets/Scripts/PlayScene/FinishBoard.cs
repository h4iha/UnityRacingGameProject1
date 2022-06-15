using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishBoard : MonoBehaviour
{

    public Text Text1;
    public Text Text2;
    // Update is called once per frame
    void Update()
    {
        if(SaveManager.instance.currentMode == 0) {
            Text1.text = "Your Position";
            Text2.text = SaveScript.finishPosition;
            if(SaveScript.finishPosition == "1st"){
                if(SaveManager.instance.currentTotalLap==1){
                    SaveManager.instance.totalMoney += 100;
                }
                else if(SaveManager.instance.currentTotalLap==2){
                    SaveManager.instance.totalMoney += 200;
                }
                else if(SaveManager.instance.currentTotalLap==3){
                    SaveManager.instance.totalMoney += 300;
                }
            }
            else if(SaveScript.finishPosition == "2nd"){
                if(SaveManager.instance.currentTotalLap==1){
                    SaveManager.instance.totalMoney += 50;
                }
                else if(SaveManager.instance.currentTotalLap==2){
                    SaveManager.instance.totalMoney += 100;
                }
                else if(SaveManager.instance.currentTotalLap==3){
                    SaveManager.instance.totalMoney += 150;
                }
            }
            
        }
        else if(SaveManager.instance.currentMode == 1) {
            Text1.text = "Your Time";
            if(SaveManager.instance.RaceMin <= 9 && SaveManager.instance.RaceSec <= 9) {
                Text2.text = "0" + Mathf.Round(SaveManager.instance.RaceMin).ToString()
                +    ": 0" + Mathf.Round(SaveManager.instance.RaceSec).ToString();
            }

            else if(SaveManager.instance.RaceMin <= 9 && SaveManager.instance.RaceSec >= 10) {
                Text2.text = "0" + Mathf.Round(SaveManager.instance.RaceMin).ToString()
                +    ": " + Mathf.Round(SaveManager.instance.RaceSec).ToString();
            }

            else if(SaveManager.instance.RaceMin >= 10 && SaveManager.instance.RaceSec <= 9) {
                Text2.text = Mathf.Round(SaveManager.instance.RaceMin).ToString()
                +    ": 0" + Mathf.Round(SaveManager.instance.RaceSec).ToString();
            }

            else if(SaveManager.instance.RaceMin >= 10 && SaveManager.instance.RaceSec >= 10) {
                Text2.text = Mathf.Round(SaveManager.instance.RaceMin).ToString()
                +    ": " + Mathf.Round(SaveManager.instance.RaceSec).ToString();
            }
            SaveManager.instance.totalMoney += 100;
        }
        else if(SaveManager.instance.currentMode == 2) {
            Text1.text = "Your Score";
            SaveManager.instance.totalMoney += 100;
        }
    }

    public void OkButton() {
        SceneManager.LoadScene("ChooseMapScene");
    }
}
