using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    TrapsManager trapsManager;

    public Animator bossAnimator;
    bool isBossWalking = false;
    public Animator doorAnimator;

    public float speed = 1f;
    public Transform[] checkPoints;
    public int actualCheckPoint;

    float startTime = 0.01f;
    float waitTime;

    public static bool checkPointAchieved;

    public Animator animatorGFX;

    string actualAnimationToPlay;

    public bool isTrapSet = false;


    private void Start()
    {
        trapsManager = TrapsManager.instance;

        actualCheckPoint = 0;
        waitTime = startTime;

        checkPointAchieved = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 dir = checkPoints[actualCheckPoint].position - transform.position;
        //.normalized - użyte żeby prędkość była cały czas taka sama
        if (dir.magnitude > 0.2f)
        {
            transform.Translate(dir.normalized * speed * Time.deltaTime);
            if (!isBossWalking)
            {
                bossAnimator.SetBool("isBossWalking", true);
                isBossWalking = true;
            }
        }
        else if (waitTime <= 0)
        {
            if (actualCheckPoint < checkPoints.Length - 1)
            {
                actualCheckPoint++;
            }
            else
            {
                actualCheckPoint = 0;
            }

            //po skończeniu odliczania czasu do następnego checkpointu resetujemy wszystkie flagi
            BossGFXAnimationsManager.animationPrototypeEnded = false;
            BossAnimationManager.animationEnded = false;
            checkPointAchieved = false;
            waitTime = startTime;
        }
        //nie zostanie wykonana funkcja dopóki będzie spełniany puierwszy warunek if (dir.magnitude>0.2f), ponieważ tutaj mamy else if
        else if (checkPoints[actualCheckPoint].tag == "Trap" && !checkPointAchieved)
        {
            bossAnimator.SetBool("isBossWalking", false);
            isBossWalking = false;

            TrapInteractionManager();
        }
        else if (checkPoints[actualCheckPoint].tag == "BossInteraction" && !checkPointAchieved)
        {
            BossInteractionManager();
        }
        //tymczasowo żeby boss osiągnął wszystkie check pointy nawet jeśli nie ma w nich animacji
        else if (!checkPointAchieved)
        {
            BossGFXAnimationsManager.animationPrototypeEnded = true;
            checkPointAchieved = true;

        }
        //jeśli animacja jest zakończona bądż jeśli aktualny check point nie ma animacji to odliczamy czas do następnego checkpointu 
        //(aktualnie wszystkie check pointy mają animację; 
        //jeśli by któryś nie ma trezba wstawić na przykład=> else if (BossGFXAnimationsManager.animationPrototypeEnded || actualCheckPoint == 0))
        else if (BossGFXAnimationsManager.animationPrototypeEnded || BossAnimationManager.animationEnded)
        {
            waitTime -= Time.deltaTime;
            checkPointAchieved = true;
            //Debug.Log(waitTime);
        }

    }

    void TrapInteractionManager()
    {
        Debug.Log("wybieranie");
        switch (checkPoints[actualCheckPoint].name)
        {
            case "CoffeeDrinking":

                bossAnimator.SetTrigger("pickingCoffee");

                //TO DO: Animacja picia kawy animatorGFX.SetTrigger();
                if (trapsManager.isSugarBowlTrapSet)
                {
                    bossAnimator.SetTrigger("trapActive");
                    checkPointAchieved = true;
                    waitTime = 2f;
                    trapsManager.isSugarBowlTrapSet = false;
                }
                else
                {
                    bossAnimator.SetTrigger("noTrap");
                    checkPointAchieved = true;
                    waitTime = 1f;
                }
                break;
            case "FlowerSniffing02":

                bossAnimator.SetTrigger("sniffing");

                if (trapsManager.isFlowerTrapSet)
                {
                    bossAnimator.SetTrigger("flowerTrapActive");
                    checkPointAchieved = true;
                    waitTime = 1f;
                    trapsManager.isFlowerTrapSet = false;
                }
                else
                {
                    bossAnimator.SetTrigger("noFlowerTrap");
                    checkPointAchieved = true;
                    waitTime = 1f;
                }
                break;
            default:
                Debug.LogError("Nie znaleziono podanej pulapki (BossMovement.cs)");
                break;
        }

    }

    void BossInteractionManager()
    {
        switch (checkPoints[actualCheckPoint].name)
        {
            case "OpenDoor":
                if (DoorOpen.isDoorOpen == false)
                {
                    doorAnimator.SetBool("isDoorOpen", true);
                    DoorOpen.isDoorOpen = true;
                }

                checkPointAchieved = true;

                //tymczasowa zmienna do informowaniu że zakończono czynność w tym check point'cie
                BossGFXAnimationsManager.animationPrototypeEnded = true;
                break;

            case "CloseDoor":
                if (DoorOpen.isDoorOpen == true)
                {
                    doorAnimator.SetBool("isDoorOpen", false);
                    DoorOpen.isDoorOpen = false;
                }

                checkPointAchieved = true;

                //tymczasowa zmienna do informowaniu że zakończono czynnośc w tym check point'cie - w przyszłości zmienić na animacje oficjalną
                //lub zamienic na osobna zmienną do zmknięcia/ otwarcia drzwi (lub innych interakcji)
                BossGFXAnimationsManager.animationPrototypeEnded = true;
                break;
            case "CoffeeMaking":
                bossAnimator.SetTrigger("makingCoffee");
                checkPointAchieved = true;
                break;
            case "CoffeeMaking02":
                bossAnimator.SetTrigger("pickCoffee");
                checkPointAchieved = true;
                break;
            default:
                break;
        }
    }

}
