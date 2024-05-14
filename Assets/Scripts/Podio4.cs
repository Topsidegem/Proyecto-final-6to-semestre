using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podio4 : MonoBehaviour
{
    public bool hasTrophy4 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trophy"))
        {
            hasTrophy4 = true;
        }
    }
}
