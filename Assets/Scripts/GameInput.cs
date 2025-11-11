using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
   public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputActions;

    public event EventHandler OnPlayerRunningStarted;
    public event EventHandler OnPlayerRunningCanceled;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        playerInputActions.Player.Running.performed += PlayerRunningStarted;
        playerInputActions.Player.Running.canceled += PlayerRunningCanceled;
    }

    private void PlayerRunningStarted(InputAction.CallbackContext context)
    {
        OnPlayerRunningStarted?.Invoke(this, EventArgs.Empty);
    }
    private void PlayerRunningCanceled(InputAction.CallbackContext context)
    {
        OnPlayerRunningCanceled?.Invoke(this, EventArgs.Empty);
    }


    public Vector3 GetMovementVector()
    {
       return playerInputActions.Player.Move.ReadValue<Vector3>();
        
    }
    public Vector2 GetLookVector()
    {
        return playerInputActions.Player.Look.ReadValue<Vector2>();
    }






}
