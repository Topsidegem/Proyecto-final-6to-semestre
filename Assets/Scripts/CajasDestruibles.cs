using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajasDestruibles : MonoBehaviour
{
    public GameObject caja;
    public GameObject llave;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            caja.SetActive(false);
            llave.SetActive(true);
        }
    }
}
