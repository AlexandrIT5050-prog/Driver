using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player  Instance { get; set; }

    [SerializeField]
    private float movingSpeed = 3f;
    [SerializeField]
    private float runningSpeed = 8f;
    private float minMovingSpeed = 0.1f;
    private bool isWalking;
    private bool isRunning;


    private Vector3 inputVector;
    private Rigidbody rb;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (GameInput.Instance != null)
        {
            GameInput.Instance.OnPlayerRunningStarted += GameInput_OnPlayerRunningStarted;
            GameInput.Instance.OnPlayerRunningCanceled += GameInput_OnPlayerRunningCanceled;
        }
    }
    private void Update()
    {
        inputVector = GameInput.Instance.GetMovementVector();
   
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float currentSpeed = isRunning? runningSpeed:movingSpeed;
        rb.MovePosition(rb.position + inputVector * (currentSpeed * Time.fixedDeltaTime));
        bool isMoving = inputVector.sqrMagnitude > minMovingSpeed * minMovingSpeed;

        isWalking = isMoving;
        isWalking = isMoving && !isRunning;
        isRunning = isMoving && isRunning;
    }

    private void GameInput_OnPlayerRunningStarted(object sender, EventArgs e)
    {
        isRunning = true;
    }

    private void GameInput_OnPlayerRunningCanceled(object sender, EventArgs e)
    {
        isRunning = false;
    }

    public bool IsWalking()
    {
        return isWalking;
    }
    public bool IsRunning()
    {
        return isRunning;
    }


}
