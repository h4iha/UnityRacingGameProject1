using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashAdd : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SaveManager.instance.cash += 200;
            SaveManager.instance.Save();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            SaveManager.instance.cash -= 200;
            SaveManager.instance.Save();
        }
    }
}
