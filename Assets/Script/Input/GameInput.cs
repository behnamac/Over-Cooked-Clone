using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameInput : MonoBehaviour
{
    public Action OnIntractionAction;
    private InputController controller;


    private void Awake()
    {
        controller= new InputController();
        controller.Player.Enable();
        controller.Player.Intractions.performed += Intraction_performed;
    }

    public Vector2 GetMovementVectorNormalize()
    {
        Vector2 inputVector=controller.Player.movement.ReadValue<Vector2>();

        inputVector=inputVector.normalized;
        return inputVector; 
    }

    public void Intraction_performed(InputAction.CallbackContext obj)
    {
        OnIntractionAction?.Invoke();
    }
}
