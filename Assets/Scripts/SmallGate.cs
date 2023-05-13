using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGate : MonoBehaviour
{
    public GameObject Bridge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LeanTween.moveLocalY(Bridge, -50, 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LeanTween.moveLocalY(Bridge, -29, 1);
        }

    }
}
