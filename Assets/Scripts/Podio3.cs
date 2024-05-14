using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podio3 : MonoBehaviour
{
    public bool hasTrophy3 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trophy"))
        {
            hasTrophy3 = true;
        }
    }
}
