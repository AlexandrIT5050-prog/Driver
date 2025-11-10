using System;
using UnityEngine;
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
        GameInput.Instance.OnPlayerRunning += GameInput_OnPlayerRunning;
    }

    private void GameInput_OnPlayerRunning(object sender, EventArgs e)
    {
        Animation.Instance.Running();
       
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
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.deltaTime));
        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed || Mathf.Abs(inputVector.z)>minMovingSpeed)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
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
