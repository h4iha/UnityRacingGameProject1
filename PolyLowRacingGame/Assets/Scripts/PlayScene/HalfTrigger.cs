using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfTrigger : MonoBehaviour
{
    
    public GameObject FinishTriggerObject;
    public GameObject HalfTriggerObject;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {

            FinishTriggerObject.gameObject.SetActive(true);
            HalfTriggerObject.gameObject.SetActive(false);
        }
    }
}
