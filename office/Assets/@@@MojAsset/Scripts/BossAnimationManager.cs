using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationManager : MonoBehaviour
{
    public static bool animationEnded = false;

    public GameObject coffeeCup;
    public ParticleSystem skullsPS, hashPS, ampresandPS, asteriskPS, exclamationMarkPS, spitPS, sneezPS;

    TrapsManager trapsManager;

    /// <summary>
    ///    było potrzebne do uruchomienia animacji samych pułapek ale raczej z tego zrezygnuję żeby ułatwić sobie życie
    ///TrapsManager trapsManager;
    /// Start is called before the first frame update
    ///void Start()
    ///{
    ///    //było potrzebne do uruchomienia animacji samych pułapek ale raczej z tego zrezygnuję żeby ułatwić sobie życie
    ///    //trapsManager = TrapsManager.instance;
    ///}
    /// </summary>

    private void Start()
    {
        coffeeCup.SetActive(false);

        trapsManager = TrapsManager.instance;
    }

    #region Animations operations
    /// <summary>
    /// Animations operations
    /// </summary>
    void AnimationEnded()
    {
        animationEnded = true;
    }

    void SetCoffeeCupActive()
    {

        coffeeCup.SetActive(!coffeeCup.activeInHierarchy);
    }
    #endregion


    #region Disabling completed traps
    /// <summary>
    /// Disabling completed traps to not make them by the boss again
    /// </summary>
    void DisableSugarBowlTrap()
    {
        trapsManager.isSugarBowlTrapSet = false;
    }

    void DisableFlowerTrap()
    {
        trapsManager.isFlowerTrapSet = false;
    }
    #endregion

    /// <summary>
    /// Adding anger
    /// </summary>
    void AddAnger()
    {
        BossAngerMeasurement.AddAnger(70);
    }

    void PlayAngryParticles()
    {
        skullsPS.Play();
        hashPS.Play();
        ampresandPS.Play();
        asteriskPS.Play();
        exclamationMarkPS.Play();
    }

    void TrapCompleted()
    {
        trapsManager.completedTraps++;
    }

    void SpitCoffee()
    {
        spitPS.Play();
    }

    void Sneeze()
    {
        sneezPS.Play();
    }
}
