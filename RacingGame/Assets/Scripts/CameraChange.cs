using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject NorCam;
    public GameObject FarCam;
    public GameObject FrontCam;
    public int CamMode;

    void Update()
    {
        if(Input.GetButtonDown("ChangeCameraView"))
        {
            if(CamMode == 3)
            {
                CamMode = 0;
            }else
            {
                CamMode += 1;
            }
            StartCoroutine(Modechange());
        }
    }

    IEnumerator Modechange()
    {
        yield return new WaitForSeconds(0.01f);
        if(CamMode == 0)
        {
            NorCam.gameObject.SetActive(true);
            FrontCam.gameObject.SetActive(false);
        }
        else if (CamMode == 1)
        {
            FarCam.gameObject.SetActive(false);
            FrontCam.gameObject.SetActive(true);
        }
        else if (CamMode == 2)
        {
            NorCam.gameObject.SetActive(false);
            FarCam.gameObject.SetActive(true);
        }
    }

}
