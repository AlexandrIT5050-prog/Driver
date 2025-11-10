using System;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public static Animation Instance { get; private set; }

    private const string IS_WALKING = "isWalking";
    private const string IS_RUNNING = "isRunning";

    private Animator animator;

    public EventHandler OnRunning;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        animator.SetBool(IS_WALKING, Player.Instance.IsWalking());
    }

    public void Running()
    {
        OnRunning?.Invoke(this, EventArgs.Empty);
        animator.SetBool(IS_RUNNING,Player.Instance.IsRunning());
    }

}
