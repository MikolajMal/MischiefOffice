using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject levelSelector;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Slider sliderProgressBar;
    public TMPro.TMP_Text progressTextTMP;

    public AudioMixer audioMixer;
    float startVolume = 15f;

    private void Start()
    {
        audioMixer.SetFloat("volumeMainMenu", startVolume);
        levelSelector.SetActive(false);
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(TurnDownMusic());
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator TurnDownMusic()
    {
        float actualVolume = startVolume;
        while (actualVolume > -80)
        {
            audioMixer.SetFloat("volumeMainMenu", actualVolume);
            actualVolume-=2;
            yield return new WaitForSeconds(0.01f);
        }

    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            sliderProgressBar.value = progress;
            progressTextTMP.text = (int)(progress*100f) + "%";

            yield return null;
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
