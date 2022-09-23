using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float speedModifier = 1f;


    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    bool isBusy;

    public Animator playerAnimator;

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // .normalized - używane by dwa chodzenie na ukos nie było szybsze; zwraca wartość nie większą niż 1
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f && !PauseMenu.GameIsPaused)
        {
            StarWalkAnimation();

            StartRunAnimation();



            //Obliczanie kąta obrotu w kierunku ruchu (typowe Third Person Controller zachowanie) żeby gracz patrzył w kierunku ruchu
            //Facing movement direction
            //+ cam.eulerAngles.y to wystarczy aby przód gracza był w kierunku w który kieruje kamera
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + cam.eulerAngles.y;
            //Mathf.SmoothDampAngle - Stopniowo zmienia kąt podany w stopniach w kierunku pożądanego kąta 
            //public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime);
            //ref float currentVelocity  - zapisuje do tej zmiennej aktualną prędkość
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //* Vector3.forward - to mnożenie zamienia rotacje w kierunek (rotation into direction);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * speedModifier  * Time.deltaTime);
        }
        else
        {
            StopWalkAnimation();
            StopRunAnimation();
        }

        //transform.position.y = 0f;
    }

    void StarWalkAnimation()
    {
        playerAnimator.SetBool("isWalking", true);
    }

    void StopWalkAnimation()
    {
        playerAnimator.SetBool("isWalking", false);
    }

    void StartRunAnimation()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedModifier = 1.5f;
            playerAnimator.SetBool("isRunning", true);

        }
        else
        {
            speedModifier = 1;
            playerAnimator.SetBool("isRunning", false);
        }
    }

    void StopRunAnimation()
    {
            speedModifier = 1;
            playerAnimator.SetBool("isRunning", false);
    }

}
