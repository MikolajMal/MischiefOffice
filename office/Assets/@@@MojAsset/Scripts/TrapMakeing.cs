using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrapMakeing : Interactable
{
    TrapsManager trapsManager;

    public GameObject trap;

    public Animator playerGFXAnimator;

    Coroutine podkladaniePulapki;

    public ProgressBar progressBar;

    InteractionWindow interactionWindow;

    //Do zapobiegania rozpoczęciu rozpoczętej pułapki
    bool canTrapBeStarted = true;


    //wykorzystywany do wyłączania i włączania progrss baru:
    public GameObject progressBarGameObject;

    [Header("Progress Bar Properties")]
    public float frequencyUpdateProgressBar = 1f;



    [Header("Looking for selected object")]
    //ten obiekt to parent dla wszystkich slotów;
    //potrzebny jest do przeszukania jego child object'ów
    //aby znaleźć selected object który będzie można użyć do porównania czy mozna go wykorzystać
    //w aktualnej półapce
    public Transform itemsParent;


    [Header("Helper UI")]
    public TMP_Text helperText;
    public GameObject helperUI;


    //tablica slotów do przeszukiwania
    InventorySlot[] slots;

    //flaga do uniemożliwienia przerwania półapki gdy nie zostało wywołane podkładanie pułapki
    bool canTrapSettingBeStopped = false;

    void Start()
    {
        trapsManager = TrapsManager.instance;

        trap.SetActive(false);
        progressBarGameObject.SetActive(false);

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        if (playerGFXAnimator == null)
        {
            Debug.LogError("Nie przypisano animator'a dla player'a w Trap'ach!");
        }

        interactionWindow = GetComponent<InteractionWindow>();

        helperUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetTheTrap();

        if (canTrapSettingBeStopped && interactionAvailable && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Przerwanie podkładania pułapki");
            canTrapSettingBeStopped = false;
            StopCoroutine(podkladaniePulapki);
            playerGFXAnimator.SetTrigger("stopMakingTrap");
            progressBarGameObject.SetActive(false);
            canTrapBeStarted = true;
        }
    }


    //Podkładanie pułapki i sprawdzanie czy mamy pasujący element w ekwipunku
    void SetTheTrap()
    {
        if (interactionAvailable && Input.GetKeyDown(KeyCode.Z) && canTrapBeStarted)
        {
            Debug.Log("Wciśnięto Z");

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].isSlected && (slots[i].item.name == trap.gameObject.name))
                {
                    canTrapSettingBeStopped = true;
                    podkladaniePulapki = StartCoroutine(TrapSetting(i));
                    canTrapBeStarted = false;
                    return;
                }
                else if (slots[i].isSlected)
                {
                    Debug.Log("Niewalsciwy Item");
                    canTrapBeStarted = true;
                    helperText.text = "This thing doesn't fit here.";
                    StartCoroutine(HelperUI());
                    return;
                }
                else if (i == slots.Length - 1)
                {
                    Debug.Log("Nie wybrano Item'u");
                    canTrapBeStarted = true;
                    helperText.text = "Select what you want to use.";
                    StartCoroutine(HelperUI());
                    return;
                }
            }
        }
    }

    IEnumerator TrapSetting(int i)
    {
        float timeToConut;
        float timeToSetTrap;
        playerGFXAnimator.SetTrigger("startMakingTrap");
        //ustalenie na podstawie właściwości pułapki jak długo czekać (pomnożone przez 10 aby aktualizować progress bar)
        timeToConut = slots[i].item.timeToSetTheTrap * frequencyUpdateProgressBar;
        timeToSetTrap = slots[i].item.timeToSetTheTrap * frequencyUpdateProgressBar;
        progressBar.SetTimeToCompleteTrap(timeToConut);


        //wyświetlanie progress bar
        progressBarGameObject.SetActive(true);
        while (timeToConut >= 0)
        {
            //Debug.Log(timeToConut);

            progressBar.SetTrapProgressValue(timeToSetTrap - timeToConut);
            //warunek ten został wprowadzony aby nie było opóźnienia gdy już progress bar osiągnie 100%
            if (timeToConut != 0)
            {
                //tutaj będzie aktualizowanie progress bar co 1/frequencyUpdateProgressBar sekundy
                yield return new WaitForSeconds(1 / frequencyUpdateProgressBar);
            }
            timeToConut--;
        }
        //yield return new WaitForSeconds(slots[i].item.timeToSetTheTrap);
        playerGFXAnimator.SetTrigger("stopMakingTrap");
        trap.SetActive(true);
        TrapSet();
        canTrapSettingBeStopped = false;
        slots[i].UseItem();
        StartCoroutine("ProgressBarHideDelay");
    }

    IEnumerator ProgressBarHideDelay()
    {
        yield return new WaitForSeconds(1);
        progressBarGameObject.SetActive(false);

        canTrapBeStarted = true;
    }

    IEnumerator HelperUI()
    {
        helperUI.SetActive(true);
        yield return new WaitForSeconds(3);

        helperUI.SetActive(false);
        canTrapBeStarted = true;
    }

    void TrapSet()
    {
        //switch w którym argumentem jest nazwa obiektu który posiada ten skrypt - pułapka
        switch (this.gameObject.name)
        {
            case "SugarBowlTrap":
                trapsManager.isSugarBowlTrapSet = true;
                break;
            case "TrapPrototype":
                trapsManager.isPilkaTrapSet = true;
                break;
            case "FlowerTrap":
                trapsManager.isFlowerTrapSet = true;
                break;
            default:
                Debug.LogError("nazwa pułapki nie pokrywa się z żadną nazwą w switch'u dotyczącego która pułapka ma byc oznaczona jak podstawiona");
                break;
        }

        DisableInteractionWindow();

    }

    void DisableInteractionWindow()
    {
        interactionWindow.myDisplay.SetActive(false);

        interactionWindow.enabled = false;
    }
}
