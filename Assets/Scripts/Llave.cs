using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public GameObject llave;
    public int llaves;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            llave.SetActive(false);
            llaves++;
            print(llaves);
        }
    }
}
