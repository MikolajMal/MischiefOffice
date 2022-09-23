using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public static bool canPlayerMove = true;
    public static bool isItemPicked = false;

    public ParticleSystem makingTrapPartisleSystem;

    void DisableMoving()
    {
        canPlayerMove = false;
    }

    void EnableMoving()
    {
        canPlayerMove = true;
    }

    void ItemPicked()
    {
        isItemPicked = true;
    }

    void StartMakingTrapParticalSystem()
    {
        makingTrapPartisleSystem.Play();
    }

    void StopMakingTrapParticalSystem()
    {
        makingTrapPartisleSystem.Stop();
    }
}
