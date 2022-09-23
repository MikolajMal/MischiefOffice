using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAngerMeasurement : MonoBehaviour
{
    public static float angerValue;
    static bool wasAngerAdded = false;

    float countdown = 0.5f;

    void Start()
    {
        angerValue = 0;
    }

    private void Update()
    {
        if (angerValue <= 0) return;

        if (wasAngerAdded)
        {
            countdown += 5f;
            wasAngerAdded = false;
        }
        else if (countdown <= 0f)
        {
            angerValue -= 0.1f;
            countdown = 0.07f;
        }

        countdown -= Time.deltaTime;

        Debug.Log(angerValue);
    }

    public static void AddAnger(int angerAmount)
    {
        if ((angerValue + angerAmount) > 100f)
        {
            angerValue = 100f;
            GameManager.maxAngerAchieved++;
        }
        else
        {
            angerValue += angerAmount;
        }
        wasAngerAdded = true;
    }

    IEnumerator MaxAngerReached()
    {
        GameManager.maxAngerAchieved++;
        yield return new WaitUntil(() => angerValue < 100);
    }

}
