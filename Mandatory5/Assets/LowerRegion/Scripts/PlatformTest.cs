using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTest : MonoBehaviour
{
    Vector3 startPosition;
    public Transform targetPosition, targetPosition2;
    public Vector3 targetPoint;
    public float moveSpeed = 1, waitTime;
    private float elapsedTime;
    

    public Vector3 currentTarget;
    
    void Start()
    {
        startPosition = transform.position;
        targetPoint = targetPosition.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("SporeZone"))
        {
            Debug.Log("SPORE TRIGGER ENTER");
            targetPoint = targetPosition.position;
        }*/
    }


    void OnTriggerStay(Collider Other)
    {   
        if(Other.CompareTag("Player"))
        {
            Other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider Other)
    {
        if(Other.CompareTag("Player"))
        {
            Other.transform.SetParent(null);
        }
    }


    void Update()
    {
        if(PlayerDrugChecker.isHigh == true)
        {
            Vector3 direction = targetPoint - transform.position;
            transform.Translate(direction.normalized * Time.deltaTime * moveSpeed);

            if (Vector3.Distance(transform.position, targetPosition2.position) < 0.1f)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime > waitTime)
                {
                    targetPoint = targetPosition.position;
                    elapsedTime = 0;
                }
            }

            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime > waitTime)
                {
                    targetPoint = targetPosition2.position;
                    elapsedTime = 0;
                }
            }
        }
        /*else
        {
            transform.position = startPosition;
            targetPoint = startPosition;
        }*/
    }
}
