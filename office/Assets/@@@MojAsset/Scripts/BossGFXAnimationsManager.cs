using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGFXAnimationsManager : MonoBehaviour
{
    public static bool animationPrototypeEnded = false;

    TrapsManager trapsManager;

    private void Start()
    {
        trapsManager = TrapsManager.instance;
    }




    void AnimationPrototypeEnded()
    {
        animationPrototypeEnded = true;
    }

    void CallPilkaTrapAnimation()
    {
        //trapsManager.playPilkaAnimation = true;
    }
}
