using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    bool playerDetected;

    public Animator bossAnimator;

    Vector3 lookDirection;
    float rotationSpeed = 10f;


    //Detection Areas
    public Collider[] detectionAreas;
    public Transform playerPosition;

    //Disableing items of Boss
    public GameObject coffeeCup;


    // Start is called before the first frame update
    void Start()
    {
        playerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        if (IsPlayerDetected())
        {
            PlayerDetected();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerDetected();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        lookDirection = other.transform.position - transform.position;
    }

    bool IsPlayerDetected()
    {
        foreach (var area in detectionAreas)
        {
            Vector3 closestPointToTheBoss = area.ClosestPointOnBounds(transform.position);
            Vector3 closestPointToThePlayer = area.ClosestPointOnBounds(playerPosition.position);

            float distanceToTheBoss = Vector3.Distance(closestPointToTheBoss, transform.position);
            float distanceToThePlayer = Vector3.Distance(closestPointToThePlayer, playerPosition.position);

            //Debug.Log("Boss: " + area.name + " " + distanceToTheBoss + "      Player: " + area.name + " " + distanceToThePlayer);

            if ((distanceToTheBoss < 0.1) && (distanceToThePlayer < 0.1))
            {
                Debug.Log(area.name);
                return true;
            }
        }

        return false;
    }

    void PlayerDetected()
    {
        coffeeCup.SetActive(false);

        lookDirection = playerPosition.position - transform.position;

        GetComponent<BossRotation>().enabled = false;
        GetComponentInParent<BossMovement>().enabled = false;
        playerDetected = true;



        bossAnimator.SetTrigger("gameOver");
        GameManager.gameOver = true;

    }
}
