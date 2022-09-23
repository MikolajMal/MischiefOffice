using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{
    //Te zmienne muszą byc takie same jak w PlayerStats.cs
    public int allGainedCups;

    public int level01Score;
    public int level01Cups;

    public int level02Score;
    public int level02Cups;

    private void Awake()
    {
        string path = Application.persistentDataPath + "/levelsStats.save";
        if (/*SceneManager.GetActiveScene().buildIndex == 0 &&*/ File.Exists(path))
        {
            LoadLevelStats();
        }
    }

    public void UpdateLevelStats(int score, int cups)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        switch (sceneIndex)
        {
            case 1:
                if (score > level01Score)
                {
                    level01Score = score;
                }
                if (cups > level01Cups)
                {
                    allGainedCups += cups - level01Cups;

                    level01Cups = cups;
                }
                break;
            default:
                break;
        }

        SaveSystem.SaveLevelStats(this);
    }

    public void LoadLevelStats()
    {
        PlayerStats playerStats = SaveSystem.LoadLevelStats();

        allGainedCups = playerStats.allGainedCups;

        level01Score = playerStats.level01Score;
        level01Cups = playerStats.level01Cups;

        level02Score = playerStats.level02Score;
        level02Cups = playerStats.level02Cups;
    }
}
