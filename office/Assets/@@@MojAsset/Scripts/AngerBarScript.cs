using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngerBarScript : MonoBehaviour
{
    public Slider slider;

    public Sprite[] mood;

    public Image bossIcon;

    private void Update()
    {
        slider.value = BossAngerMeasurement.angerValue;

        ChangeImage();
    }

    private void ChangeImage()
    {
        if (BossAngerMeasurement.angerValue<=0)
        {
            bossIcon.sprite = mood[0];
        }
        else if (BossAngerMeasurement.angerValue > 0 && BossAngerMeasurement.angerValue <= 25)
        {
            bossIcon.sprite = mood[1];
        }
        else if (BossAngerMeasurement.angerValue > 25 && BossAngerMeasurement.angerValue <= 50)
        {
            bossIcon.sprite = mood[2];

        }
        else if (BossAngerMeasurement.angerValue > 50 && BossAngerMeasurement.angerValue <= 75)
        {
            bossIcon.sprite = mood[3];
        }
        else if (BossAngerMeasurement.angerValue > 75 && BossAngerMeasurement.angerValue <= 100)
        {
            bossIcon.sprite = mood[4];
        }
    }
}
