using System;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private const string IS_WALKING = "isWalking";
    private const string IS_RUNNING = "isRunning";

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        animator.SetBool(IS_WALKING, Player.Instance.IsWalking());
        animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());
    }

}
