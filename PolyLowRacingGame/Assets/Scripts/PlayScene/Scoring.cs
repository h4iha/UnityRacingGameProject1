using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text CurrentScore;
    public Text BestScore;

    // Start is called before the first frame update
    void Start()
    {
        CurrentScore.text = "0";
        if(SaveManager.instance.currentMap == 0)
            BestScore.text = SaveManager.instance.BestScoreM1.ToString();
        if(SaveManager.instance.currentMap == 1)
            BestScore.text = SaveManager.instance.BestScoreM2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScore.text = SaveManager.instance.CurrentScore.ToString();
        if(SaveManager.instance.currentMap == 0) {
            if(SaveManager.instance.CurrentScore > SaveManager.instance.BestScoreM1) {
                SaveManager.instance.BestScoreM1 = SaveManager.instance.CurrentScore;
                SaveManager.instance.Save();
                BestScore.text = SaveManager.instance.BestScoreM1.ToString();
            }
        }
        if (SaveManager.instance.currentMap == 1) {
            if(SaveManager.instance.CurrentScore > SaveManager.instance.BestScoreM2) {
                SaveManager.instance.BestScoreM2 = SaveManager.instance.CurrentScore;
                SaveManager.instance.Save();
                BestScore.text = SaveManager.instance.BestScoreM2.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "RedScore") {
            
            Destroy(other.gameObject);
            SaveManager.instance.CurrentScore += 500;
            SaveManager.instance.Save();
        }
        if(other.tag == "BlueScore") {

            Destroy(other.gameObject);
            SaveManager.instance.CurrentScore += 200;
            SaveManager.instance.Save();
        }
        if(other.tag == "YellowScore") {
            
            Destroy(other.gameObject);
            SaveManager.instance.CurrentScore += 100;
            SaveManager.instance.Save();
        }
    }
}
;