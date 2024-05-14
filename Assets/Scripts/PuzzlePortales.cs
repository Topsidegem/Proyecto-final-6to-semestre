using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePortales : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    public GameObject portal4;
    public GameObject portal5;
    public GameObject portal6;
    public GameObject portal7;
    public GameObject portal8;
    public GameObject button1;
    public GameObject button2;
    public GameObject trofeo2;
    public GameObject trofeo3;
    public GameObject puerta;

    public void prenderPortal2()
    {
        portal2.SetActive(true);
    }

    public void prenderPortal3()
    {
        portal3.SetActive(true);
    }

    public void prenderPortal4()
    {
        portal4.SetActive(true);
    }

    public void prenderPortal5()
    {
        portal5.SetActive(true);
    }

    public void prenderPortal6()
    {
        portal6.SetActive(true);
    }

    public void prenderPortal7()
    {
        portal7.SetActive(true);
    }

    public void prenderPortal8()
    {
        portal8.SetActive(true);
    }

    public void prenderBoton1()
    {
        button1.SetActive(true);
    }

    public void prenderBoton2()
    {
        button2.SetActive(true);
    }

    public void apagarPortal1()
    {
        portal2.SetActive(false);
    }

    public void apagarPortal2()
    {
        portal2.SetActive(false);
    }

    public void apagarPortal3()
    {
        portal3.SetActive(false);
    }

    public void apagarPortal4()
    {
        portal4.SetActive(false);
    }

    public void apagarPortal5()
    {
        portal5.SetActive(false);
    }

    public void apagarPortal6()
    {
        portal6.SetActive(false);
    }

    public void apagarPortal7()
    {
        portal7.SetActive(false);
    }

    public void apagarPortal8()
    {
        portal8.SetActive(false);
    }

    public void apagarBoton1()
    {
        button1.SetActive(false);
    }

    public void apagarBoton2()
    {
        button2.SetActive(false);
    }

    public void abrirPuerta()
    {
        puerta.transform.position = new Vector3(0f, 90f, 0f);
        trofeo2.SetActive(true);
        trofeo3.SetActive(true);
    }
}
