using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grip : MonoBehaviour
{
    public InputActionReference grip;
  
    void Start()
    {
        grip.action.performed += Action_performed;        
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        print("press grip");
    }   
}