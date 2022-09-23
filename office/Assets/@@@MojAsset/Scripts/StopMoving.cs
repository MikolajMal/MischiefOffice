using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoving : MonoBehaviour
{
    public Animator playerAnimator;

    ThirdPersonMovement TPMscript;


    // Start is called before the first frame update
    void Start()
    {
        TPMscript = GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver)
        {
            //playerAnimator.SetTrigger("gameLost");
            TPMscript.enabled = false;
            playerAnimator.SetTrigger("gameLost");
            return;
        }

        if ((PlayerGFXAnimationManager.animationTrapSettingStarted || !PlayerAnimationManager.canPlayerMove) && TPMscript.enabled)
        {
            TPMscript.enabled = false;
        }
        else if ((PlayerGFXAnimationManager.animationTrapSettingStarted || PlayerAnimationManager.canPlayerMove) && !TPMscript.enabled)
        {
            TPMscript.enabled = true;
        }
    }
}
