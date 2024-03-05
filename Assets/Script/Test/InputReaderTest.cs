using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static TestInput;

[CreateAssetMenu(fileName = "Test Input", menuName = "CreateInput/Test Input")]
public class InputReaderTest : ScriptableObject, IPlayerTestActions, IUIActions
{

    public Action<bool> OnJumpEvent;
    public Action<Vector2> OnMoveEvent;
    public Action<bool> OnUIEvent;
    public Action<bool> OnUIEnter;
    public Action<bool> OnGamePause;

    private TestInput inputs;

    private void OnEnable()
    {
        if (inputs == null)
        {
            inputs = new TestInput();
            inputs.PlayerTest.SetCallbacks(this);
            inputs.UI.SetCallbacks(this);
        }
        inputs.PlayerTest.Enable();
        inputs.UI.Enable();
    }



    public void OnJump(InputAction.CallbackContext context)
    {
        // if (context.performed)
        OnJumpEvent?.Invoke(context.performed);
        //else
        //    OnJumpEvent?.Invoke(false);

    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnUINavigation(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnUIEvent?.Invoke(true);
        else
            OnUIEvent?.Invoke(false);
    }

    public void OnEnter(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnUIEnter?.Invoke(true);
        else
            OnUIEnter?.Invoke(false);
    }


    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnGamePause?.Invoke(true);
        else
            OnGamePause?.Invoke(false);
    }
}
