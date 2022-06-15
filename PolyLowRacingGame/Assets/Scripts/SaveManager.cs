using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }

    //What we want to save
    public int totalMoney;
    public int currentCar;
    public int currentColor;
    public bool[] carsUnlocked = new bool[3] { true, false, false};

    public int currentMap;
    public int currentMode;
    public int currentTotalLap;
    public bool[] mapsUnlocked = new bool[2] { true, false};


    public float RaceMin;
    public float RaceSec;
    //Map 1
    public float BestMinM1;
    public float BestSecM1;

    //Map 2
    public float BestMinM2;
    public float BestSecM2;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            totalMoney = data.totalMoney;
            currentCar = data.currentCar;
            currentColor = data.currentColor;
            carsUnlocked = data.carsUnlocked;

            currentMap = data.currentMap;
            currentTotalLap = data.currentTotalLap;
            currentMode = data.currentMode;
            mapsUnlocked = data.mapsUnlocked;

            RaceMin = data.RaceMin;
            RaceSec = data.RaceSec;
            //Best Time Map 1
            BestMinM1 = data.BestMinM1;
            BestSecM1 = data.BestSecM1;

            //Best Time Map 2
            BestMinM2 = data.BestMinM2;
            BestSecM2 = data.BestSecM2;

            if (data.carsUnlocked ==  null)
                carsUnlocked = new bool[3] { true, false, false};
            if (data.mapsUnlocked ==  null)
                mapsUnlocked = new bool[2] { true, false};

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.totalMoney = totalMoney;
        data.currentCar = currentCar;
        data.currentColor = currentColor;
        data.carsUnlocked = carsUnlocked;
        
        data.currentMap = currentMap;
        data.currentTotalLap = currentTotalLap;
        data.currentMode = currentMode;
        data.mapsUnlocked = mapsUnlocked;

        data.RaceMin = RaceMin;
        data.RaceSec = RaceSec;
        //Best Time Map 1
        data.BestMinM1 = BestMinM1;
        data.BestSecM1 = BestSecM1;

        //Best Time Map 2
        data.BestMinM2 = BestMinM2;
        data.BestSecM2 = BestSecM2;

        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class PlayerData_Storage
{
    public int totalMoney;

    public int currentCar;
    public int currentColor;
    public bool[] carsUnlocked;

    public int currentMap;
    public int currentTotalLap;
    public int currentMode;
    public bool[] mapsUnlocked;

    public float RaceMin;
    public float RaceSec;
    //Map 1
    public float BestMinM1;
    public float BestSecM1;

    //Map 2
    public float BestMinM2;
    public float BestSecM2;

}