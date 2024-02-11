using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputController;


[CreateAssetMenu(fileName ="NewInput",menuName ="CreateInput")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public Action<Vector2> MoveAction;
    private InputController inputControl;

    private void OnEnable()
    {
        if (inputControl == null)
        {
            inputControl = new InputController();
            inputControl.Player.SetCallbacks(this);
        }

        inputControl.Player.Enable();
    }


    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveAction?.Invoke(context.ReadValue<Vector2>());
    }
}
