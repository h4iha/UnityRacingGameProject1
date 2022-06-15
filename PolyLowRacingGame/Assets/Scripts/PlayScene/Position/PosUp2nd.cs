using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosUp2nd : MonoBehaviour
{
    public GameObject posText;
    
    private void OnTriggerExit(Collider other) {
        if(other.tag == "PosCar") {
            posText.GetComponent<Text>().text = "2";
        }
    }
}
