using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    public TMP_Text textProcenty;

    public void SetTimeToCompleteTrap(float trapProgress)
    {
        slider.maxValue = trapProgress;
        slider.value = 0f;
    }

    public void SetTrapProgressValue(float trapProgress)
    {
        slider.value = trapProgress;
        //aby wyświetlać wartość procentową należałoby użyć slider.normalizedValue * 100 aby otrzymać wartosć procentową
        //Debug.Log((int)(slider.normalizedValue * 100));

        textProcenty.text = ((int)(slider.normalizedValue * 100)).ToString() + "%";

    }
}
