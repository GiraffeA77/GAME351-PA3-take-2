using system.Collections;
using system.Collections.Generic;
using UnityEngine;


public class CameraChange : MonoBehaviour {
    public gameObject FirstCam;
    public GameObject ThirdCam;
    public int CamMode;

    void update(){
        if(input.GetButtonDown ("Camera")) {
            if (CamMode == 1) {
                CamMode == 0;
        } else {
            CamMode += 1;
        }
        StartCoroutine (CamChange());
    }

    IEnumerator CamChange(){
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0) {
            FirstCam.SetActive(false);
            ThirdCam.SetActive(true);
        }
        if (CamMode == 1){
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);
        }
    }
}


