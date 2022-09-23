using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject bossCamera;
    bool isPlayerCameraActive = true;


    // Start is called before the first frame update
    void Start()
    {
        playerCamera.SetActive(true);
        bossCamera.SetActive(false);
        isPlayerCameraActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCamera();
    }

    private void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isPlayerCameraActive)
            {
                playerCamera.SetActive(false);
                bossCamera.SetActive(true);

                isPlayerCameraActive = false;
            }
            else
            {
                playerCamera.SetActive(true);
                bossCamera.SetActive(false);

                isPlayerCameraActive = true;
            }
        }
        else if (GameManager.gameOver)
        {
            playerCamera.SetActive(false);
            bossCamera.SetActive(true);

            isPlayerCameraActive = false;
        }
        else if (GameManager.levelCompleted)
        {
            playerCamera.SetActive(true);
            bossCamera.SetActive(false);

            isPlayerCameraActive = true;
        }
    }
}
