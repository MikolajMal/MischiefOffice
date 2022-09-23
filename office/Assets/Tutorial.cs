using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;

    bool isTutorialActive;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex ==1)
        {
            Time.timeScale = 0f;
            tutorial.SetActive(true);
            isTutorialActive = true;
        }
        else
        {
            Time.timeScale = 1f;
            tutorial.SetActive(false);
            isTutorialActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!isTutorialActive)
            {
                Time.timeScale = 0f;
                tutorial.SetActive(true);
                isTutorialActive = true;
            }
            else if (isTutorialActive)
            {
                Time.timeScale = 1f;
                tutorial.SetActive(false);
                isTutorialActive = false;
            }
        }
    }
}
