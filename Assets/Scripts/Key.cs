using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private void Start()
    {
        LeanTween.rotateY(this.gameObject,180, 1).setLoopPingPong();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ShipController>().AddKey();
            Destroy(gameObject);
        }
    }

}
