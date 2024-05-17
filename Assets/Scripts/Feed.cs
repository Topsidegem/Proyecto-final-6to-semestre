using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour {

    PartnerAgent m_agent;

    private void Start() {
        m_agent = GameObject.Find("cat").GetComponent<PartnerAgent>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            m_agent.feeding(gameObject.transform);
        }
    }
}
