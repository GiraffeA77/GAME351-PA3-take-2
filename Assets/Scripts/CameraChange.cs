using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {
    public GameObject FirstCam;
    public GameObject ThirdCam;
    private bool isFirstPerson = true;

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            isFirstPerson = !isFirstPerson;
            if (isFirstPerson) {
                ActivateFirstPersonCamera();
            } else {
                ActivateThirdPersonCamera();
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            isFirstPerson = true;
            ActivateFirstPersonCamera();
        }
    }

    void ActivateFirstPersonCamera() {
        FirstCam.SetActive(true);
        ThirdCam.SetActive(false);
    }

    void ActivateThirdPersonCamera() {
        FirstCam.SetActive(false);
        ThirdCam.SetActive(true);
    }
}
