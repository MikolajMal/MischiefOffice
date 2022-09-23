using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    //Te zmienne muszą byc takie same jak w SaveAndLoad.cs
    public int allGainedCups;

    #region Levels Stats
    public int level01Score;
    public int level01Cups;

    public int level02Score;
    public int level02Cups;
    #endregion

    public PlayerStats(SaveAndLoad saveAndLoad)
    {
        allGainedCups = saveAndLoad.allGainedCups;

        level01Score = saveAndLoad.level01Score;
        level01Cups = saveAndLoad.level01Cups;
    }
}
