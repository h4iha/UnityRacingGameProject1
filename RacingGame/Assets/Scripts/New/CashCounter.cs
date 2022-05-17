using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CashCounter : MonoBehaviour
{
    private Text cashAmount;

    private void Awake()
    {
        cashAmount = GetComponent<Text>();
    }
    private void Update()
    {
        cashAmount.text ="Cash: " + SaveManager.instance.cash;
    }
}
