using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayStill : MonoBehaviour
{

    [Header("Offset for GFX of character")]
    [Range(0.0f, 10.0f)]
    public float highOffset = 0;

    Transform parentTransform;

    private void Start()
    {
        parentTransform = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = parentTransform.transform.position;
    }
}
