using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGate : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ShipController>().CheckWinCondition();
            other.gameObject.GetComponent<ShipController>().hudMessage.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ShipController>().hudMessage.SetActive(false);
        }

    }


}
