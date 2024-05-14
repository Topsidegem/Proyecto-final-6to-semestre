using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podio5 : MonoBehaviour
{
    public bool hasTrophy5 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trophy"))
        {
            hasTrophy5 = true;
        }
    }
}
