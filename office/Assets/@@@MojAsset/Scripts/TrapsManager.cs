using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapsManager : MonoBehaviour
{
    #region Singleton
    /// <summary>
    /// Tworzymy to aby nie musieć robić FindObjectOfType<> więc robimy statyczną instancję tej klasy
    /// </summary>
    public static TrapsManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public int trapsAmount = 0;

    // Are the traps setted
    public bool isPilkaTrapSet = false;
    public bool isCoffeeTrapSet = false;

    public bool isSugarBowlTrapSet = false;
    public bool isFlowerTrapSet = false;

    // Number for completed traps
    public int completedTraps = 0;

    private void Start()
    {
        // Are the traps setted
        isPilkaTrapSet = false;
        isCoffeeTrapSet = false;

        isSugarBowlTrapSet = false;
        isFlowerTrapSet = false;

        SetTrapsAmount();
    }

    void SetTrapsAmount()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level_001":
                trapsAmount = 2;
                break;
        }
    }

}
