using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BButon : MonoBehaviour
{
    [SerializeField] GameObject menuBButton;
    [SerializeField] InputActionProperty bButon;


    void Start(){
        bButon.action.performed += MenuONOff;
    }

    void Update() {
        
    }

    void MenuONOff(InputAction.CallbackContext context) {
        menuBButton.SetActive(!menuBButton.activeSelf);
    }
}
