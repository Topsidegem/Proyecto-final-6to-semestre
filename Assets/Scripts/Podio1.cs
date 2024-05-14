using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podio1 : MonoBehaviour
{
    public bool hasTrophy1 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trophy"))
        {
            hasTrophy1 = true;
        }
    }
}
