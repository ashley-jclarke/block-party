using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    private InputAction interact;
    public event EventHandler OnInteractAction;



    void Awake()
    {
        interact = InputSystem.actions.FindAction("Interact");
        interact.performed += Interact_performed;

    }

    private void Interact_performed(InputAction.CallbackContext context)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
