using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }


    [Header("Cash")]
    public int cash;

    [Header("Car")]
    public int currentCarIndex = 0;

    public bool[] carsUnlocked = new bool[6] { true, false, false, false, false, false };

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
        if (File.Exists(Application.persistentDataPath + "/mySave.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/mySave.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            //Cash
            cash = data.cash;
            //Car
            currentCarIndex = data.currentCarIndex;
            carsUnlocked = data.carsUnlocked;

            if (data.carsUnlocked == null)
                carsUnlocked = new bool[6] { true, false, false, false, false, false };
    //Map


    file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/mySave.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.cash = cash;
        data.currentCarIndex = currentCarIndex;
        data.carsUnlocked = carsUnlocked;

        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class PlayerData_Storage
{
    [Header("Cash")]
    public int cash;

    [Header("Car")]
    public int currentCarIndex = 0;

    public bool[] carsUnlocked = new bool[6] { true, false, false, false, false, false };

}
