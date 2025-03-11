using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EscapeCutScene : MonoBehaviour {
    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;
    public CinemachineVirtualCamera vcam3;
    public GameObject gameplayCam;
    private bool isCutsceneActive = true;

    void Start() {
        gameplayCam.SetActive(false);
        vcam1.Priority = 20;
        vcam2.Priority = 20;
        vcam3.Priority = 20;
    }

    void Update() {
        if (isCutsceneActive && Input.GetKeyDown(KeyCode.Escape)) {
            ExitCutscene();
        }
    }

    void ExitCutscene() {
        vcam1.Priority = 0;
        vcam2.Priority = 0;
        vcam3.Priority = 0;
        gameplayCam.SetActive(true);
        isCutsceneActive = false;
    }
}
