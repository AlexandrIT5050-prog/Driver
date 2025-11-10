using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
   public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputActions;

    public event EventHandler OnPlayerRunning;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        playerInputActions.Player.Running.performed += PlayerRunning;
    }

    public Vector3 GetMovementVector()
    {
        Vector3 inputVector = playerInputActions.Player.Move.ReadValue<Vector3>();
        return inputVector;
    }

    public void PlayerRunning(InputAction.CallbackContext obj)
    {
        OnPlayerRunning?.Invoke(this, EventArgs.Empty);
    }

    


}
