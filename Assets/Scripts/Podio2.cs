using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podio2 : MonoBehaviour
{
    public bool hasTrophy2 = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trophy"))
        {
            hasTrophy2 = true;
        }
    }
}
