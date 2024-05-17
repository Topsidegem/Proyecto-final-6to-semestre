using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [SerializeField] AgressiveAgent m_agent;

    private void Start() {
        //m_agent = GameObject.Find("Zombie1").GetComponent<AgressiveAgent>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            m_agent.turnbool(other.transform);
            print("entro");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            m_agent.turnbool(this.transform);
            print("salio");
        }
    }
}
