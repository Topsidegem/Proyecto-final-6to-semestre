using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    Podio1 p1;
    Podio2 p2;
    Podio3 p3;
    Podio4 p4;
    Podio5 p5;

    void Start()
    {
        p1 = GameObject.Find("Sphere").GetComponent<Podio1>();
        p2 = GameObject.Find("Sphere (1)").GetComponent<Podio2>();
        p3 = GameObject.Find("Sphere (2)").GetComponent<Podio3>();
        p4 = GameObject.Find("Sphere (3)").GetComponent<Podio4>();
        p5 = GameObject.Find("Sphere (4)").GetComponent<Podio5>();
    }

    void Update()
    {
        if(p1.hasTrophy1 == true && p2.hasTrophy2 == true && p3.hasTrophy3 == true && p4.hasTrophy4 == true && p5.hasTrophy5 == true)
        {
            print("Se acabo el juego");
            Application.Quit();
        }
    }
}
