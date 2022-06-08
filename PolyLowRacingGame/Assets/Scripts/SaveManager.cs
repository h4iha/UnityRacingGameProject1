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
    public int currentLap;
    public bool[] mapsUnlocked = new bool[2] { true, false};

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
            currentLap = data.currentLap;
            currentMode = data.currentMode;
            mapsUnlocked = data.mapsUnlocked;

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
        data.currentLap = currentLap;
        data.currentMode = currentMode;
        data.mapsUnlocked = mapsUnlocked;

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
    public int currentLap;
    public int currentMode;
    public bool[] mapsUnlocked;
}