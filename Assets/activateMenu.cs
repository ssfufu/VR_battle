using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class activateMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;

    [SerializeField] InputActionReference activeButtonRef;

    void Start()
    {
        menu.SetActive(false);
        activeButtonRef.action.performed += ToggleMenu;

    }

    void ToggleMenu( InputAction.CallbackContext context)
    {
        menu.SetActive(!menu.activeSelf);
    }
    
}
