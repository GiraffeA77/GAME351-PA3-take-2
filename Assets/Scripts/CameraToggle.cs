using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public Transform thirdPersonDefaultPosition;
    public float transitionSpeed = 5f;

    private bool isFirstPerson = false;
    private Transform currentCamera;

    void Start()
    {
        currentCamera = thirdPersonCamera.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleCameraView();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetThirdPersonCamera();
        }

        SmoothCameraTransition();
    }

    void ToggleCameraView()
    {
        isFirstPerson = !isFirstPerson;
        firstPersonCamera.SetActive(isFirstPerson);
        thirdPersonCamera.SetActive(!isFirstPerson);
        currentCamera = isFirstPerson ? firstPersonCamera.transform : thirdPersonCamera.transform;
    }

    void ResetThirdPersonCamera()
    {
        if (!isFirstPerson && thirdPersonDefaultPosition != null)
        {
            thirdPersonCamera.transform.position = thirdPersonDefaultPosition.position;
            thirdPersonCamera.transform.rotation = thirdPersonDefaultPosition.rotation;
        }
    }

    void SmoothCameraTransition()
    {
        if (!isFirstPerson && thirdPersonDefaultPosition != null)
        {
            thirdPersonCamera.transform.position = Vector3.Lerp(thirdPersonCamera.transform.position, thirdPersonDefaultPosition.position, Time.deltaTime * transitionSpeed);
            thirdPersonCamera.transform.rotation = Quaternion.Lerp(thirdPersonCamera.transform.rotation, thirdPersonDefaultPosition.rotation, Time.deltaTime * transitionSpeed);
        }
    }
}
