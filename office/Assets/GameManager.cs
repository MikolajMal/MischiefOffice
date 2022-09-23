using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool levelCompleted = false;
    public int totalCoffeeCupsGained;

    public GameObject gameOverScreen;
    public GameObject levelCompletedScreen;
    public GameObject coffeeCups, coffeeCupLowGained, coffeeCupMiddleGained, coffeeCupHighGained;

    bool gameEnded = false;

    public TMP_Text trapsAmountText;
    public TMP_Text gainedPointsText;
    public TMP_Text extraPointsText;
    public TMP_Text finalScoreText;
    public static int maxAngerAchieved = 0;

    TrapsManager trapsManager;

    public SaveAndLoad levelProperties;

    public AudioMixer audioMixer;
    float startVolume = 5f;
    public AudioSource levelCompletedMusic;
    public AudioSource gameOverMusic;

    private void Awake()
    {
        totalCoffeeCupsGained = 0;
    }

    private void Start()
    {
        trapsManager = TrapsManager.instance;

        gameOver = false;
        levelCompleted = false;
        gameOverScreen.SetActive(false);
        levelCompletedScreen.SetActive(false);
        maxAngerAchieved = 0;

        audioMixer.SetFloat("volumeBackgroundLevelMusic", startVolume); 

        coffeeCups.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded) return;

        if (gameOver && !gameEnded && !levelCompleted)
        {
            StartCoroutine(TurnDownBackgroundMusic());
            StartCoroutine(GameOver());
            gameEnded = true;
        }

        if (AreAllTrapsCompleted() || Input.GetKeyDown(KeyCode.O) || (AlarmClock.timeToEnd <= 0f))
        {
            StartCoroutine(TurnDownBackgroundMusic());
            StartCoroutine(LevelCompleted());
            gameEnded = true;
        }
    }

    IEnumerator TurnDownBackgroundMusic()
    {
        if (gameOver)
        {
            gameOverMusic.Play();
        }
        else
        {
            levelCompletedMusic.Play();
        }
        
        

        float actualVolume = startVolume;
        while (actualVolume > -80)
        {
            audioMixer.SetFloat("volumeBackgroundLevelMusic", actualVolume);
            actualVolume --;
            yield return new WaitForSeconds(0.005f);


        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        gameOverScreen.SetActive(true);
    }

    bool AreAllTrapsCompleted()
    {
        return trapsManager.completedTraps == trapsManager.trapsAmount;
    }

    IEnumerator LevelCompleted()
    {
        levelCompleted = true;
        SetUpLevelCompletedScreen();
        yield return new WaitForSeconds(1f);
        levelCompletedScreen.SetActive(true);
        //Some time needed for LevelCompleted screen animations
        yield return new WaitForSeconds(20f);
        Time.timeScale = 0;
    }

    void SetUpLevelCompletedScreen()
    {
        trapsAmountText.text = trapsManager.completedTraps.ToString() + "/" + trapsManager.trapsAmount.ToString();

        SetupPoints();
    }

    void SetupPoints()
    {
        int allExtraPoints = (trapsManager.trapsAmount - 1);
        int extraPoints = maxAngerAchieved;
        int allPoints = trapsManager.trapsAmount * 10 + allExtraPoints * 5;
        int gaindPoints = trapsManager.completedTraps * 10 + extraPoints * 5;

        extraPointsText.text = extraPoints.ToString() + "/" + allExtraPoints.ToString();
        gainedPointsText.text = gaindPoints.ToString() + "/" + allPoints.ToString();

        SetFinalScore(gaindPoints, allPoints);
    }

    void SetFinalScore(int gaindPoints, int maxPoints)
    {
        int finalPercentages = gaindPoints * 100 / maxPoints;
        finalScoreText.text = finalPercentages.ToString() + "%";

        StartCoroutine(ShowGainedCoffeeCups(finalPercentages));
    }

    IEnumerator ShowGainedCoffeeCups(int finalPercentages)
    {
        int coffeeCupsGaindAtThisLevel = 0;

        yield return new WaitForSeconds(5f);

        coffeeCups.SetActive(true);

        if (finalPercentages >= 99)
        {
            totalCoffeeCupsGained += 3;
            coffeeCupsGaindAtThisLevel = 3;
        }
        else if (finalPercentages < 50)
        {
            coffeeCupLowGained.SetActive(false);
            coffeeCupMiddleGained.SetActive(false);
            coffeeCupHighGained.SetActive(false);

            coffeeCupsGaindAtThisLevel = 0;
        }
        else if (finalPercentages < 75)
        {
            totalCoffeeCupsGained += 1;
            coffeeCupMiddleGained.SetActive(false);
            coffeeCupHighGained.SetActive(false);

            coffeeCupsGaindAtThisLevel = 1;
        }
        else if (finalPercentages < 99)
        {
            totalCoffeeCupsGained += 2;
            coffeeCupHighGained.SetActive(false);

            coffeeCupsGaindAtThisLevel = 2;
        }

        levelProperties.UpdateLevelStats(finalPercentages, coffeeCupsGaindAtThisLevel);
    }
}
