using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleRuedayArma : MonoBehaviour
{
    public GameObject trofeo4;
    public GameObject puerta1;
    public GameObject puerta2;
    public GameObject canvas;
    public TextMeshProUGUI textMeshPro;

    Llave llave;

    private void Start()
    {
        llave = GameObject.Find("rust_key 1").GetComponent<Llave>();
    }

    private void Update()
    {
        if(llave.llaves == 1)
        {
            abrirPuerta();
        }
    }

    public void abrirPuerta()
    {
        puerta1.transform.position = new Vector3(0f, 90f, 0f);
        puerta2.transform.position = new Vector3(0f, 90f, 0f);
        trofeo4.SetActive(true);
        canvas.SetActive(true);
        textMeshPro.text = "Trofeos Obtenidos 5/5";
    }
}
