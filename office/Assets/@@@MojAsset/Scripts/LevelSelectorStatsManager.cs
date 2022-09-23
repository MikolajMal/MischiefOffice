using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelectorStatsManager : MonoBehaviour
{
    public SaveAndLoad saveAndLoad;

    [Header("All coffee cups")]
    public TMP_Text allCoffeeCups;

    [Header("Level 01 SETUP")]
    public TMP_Text level01ScoreUI;
    public GameObject lowCup01UI, middleCup01UI, highCup01UI;

    [Header("Level 02 SETUP")]
    public TMP_Text level02ScoreUI;
    public GameObject lowCup02UI, middleCup02UI, highCup02UI;

    private void OnEnable()
    {
        allCoffeeCups.text = saveAndLoad.allGainedCups.ToString() + "/3";

        // LEVEL 01
        level01ScoreUI.text = saveAndLoad.level01Score.ToString() + "%";
        HideUnclaimedCups(saveAndLoad.level01Cups, lowCup01UI, middleCup01UI, highCup01UI);

        // LEVEL 02
        //level02ScoreUI.text = saveAndLoad.level02Score.ToString() + "%";

    }

    void HideUnclaimedCups(int cupsNumber, GameObject lowCup, GameObject middleCup, GameObject highCup)
    {
        lowCup.SetActive(true);
        middleCup.SetActive(true);
        highCup.SetActive(true);

        switch (cupsNumber)
        {
            case 0:
                lowCup.SetActive(false);
                middleCup.SetActive(false);
                highCup.SetActive(false);
                break;
            case 1:
                middleCup.SetActive(false);
                highCup.SetActive(false);
                break;
            case 2:
                highCup.SetActive(false);
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
