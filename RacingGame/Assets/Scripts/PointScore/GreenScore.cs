using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RaceManager.CurrentScore += 100;
    }
}
