using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool CheckPoint1 = true;
    public bool CheckPoint2 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(CheckPoint1 == true)
            {
                SaveSystem.ThisCheckPoint1 = SaveSystem.GameTime;
                SaveSystem.CheckPointPass1 = true;
            }

            if (CheckPoint1 == true)
            {
                SaveSystem.ThisCheckPoint2 = SaveSystem.GameTime;
                SaveSystem.CheckPointPass2 = true;
            }
        }
    }
}
