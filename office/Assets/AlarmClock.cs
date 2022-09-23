using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlarmClock : MonoBehaviour
{
    TrapsManager trapsManager;

    [Header("Value of current level time.")]
    public float timeForLevel;

    public static float timeToEnd;

    float tempTime;

    [Header("TMP_Text to assign")]
    public TMP_Text timer;

    public TMP_Text pranksAmount, bonusAmount;

    int minutes, seconds;

    void Start()
    {
        trapsManager = TrapsManager.instance;

        timeToEnd = timeForLevel;

        minutes = (int)timeForLevel / 60;
        seconds = (int)timeForLevel % 60;

        tempTime = timeForLevel;
    }

    void Update()
    {
        Timer();

        UpdateStatus();
    }

    void Timer()
    {
        timeToEnd = timeForLevel;

        if (timeForLevel <= 0f) return;

        timeForLevel -= Time.deltaTime;
        if ((int)tempTime> (int)timeForLevel)
        {
            minutes = (int)timeForLevel / 60;
            seconds = (int)timeForLevel % 60;
            tempTime = timeForLevel;
            timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

    }

    void UpdateStatus()
    {
        //Updating pranks amount
        pranksAmount.text = trapsManager.completedTraps.ToString() + "/" + trapsManager.trapsAmount.ToString();

        //Updating max anger amount
        bonusAmount.text = GameManager.maxAngerAchieved + "/" + (trapsManager.trapsAmount - 1);
    }
}
