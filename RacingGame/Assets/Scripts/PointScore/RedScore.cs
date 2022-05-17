using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RaceManager.CurrentScore += 500;
    }
}
