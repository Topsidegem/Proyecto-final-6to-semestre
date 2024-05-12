using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzlePalancas : MonoBehaviour
{
    public GameObject palanca1;
    public GameObject palanca2;
    public GameObject palanca3;
    public GameObject trofeo1;
    public GameObject puerta;

    public void prenderPalanca2()
    {
        palanca2.SetActive(true);
    }

    public void prenderPalanca3()
    {
        palanca3.SetActive(true);
    }

    public void abrirPuerta() 
    {
        puerta.transform.position = new Vector3(0f, 90f, 0f);
        trofeo1.SetActive(true);
    }
}
