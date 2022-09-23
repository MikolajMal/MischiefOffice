using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGFXAnimationManager : MonoBehaviour
{

    public static bool animationTrapSettingStarted = false;
    public static bool animationTrapSettingEnded = false;

    ParticleSystem trapMakingParticalSystem;

    private void Start()
    {
        trapMakingParticalSystem = GetComponentInChildren<ParticleSystem>();
    }


    void AnimationTrapSettingStarted()
    {
        animationTrapSettingStarted = true;
        animationTrapSettingEnded = false;
    }
    void AnimationTrapSettingEnded()
    {
        animationTrapSettingStarted = false;
        animationTrapSettingEnded = true;
    }


    void StartTrapMakingParticalSystem()
    {
        trapMakingParticalSystem.Play();
    }

    void StopTrapMakingParticalSystem()
    {
        trapMakingParticalSystem.Stop();
    }
}
