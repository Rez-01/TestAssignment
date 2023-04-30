using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _controller;

    private readonly int _isWalk = Animator.StringToHash("isWalk");

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _controller.OnMoveStart.AddListener(StartMoving);
        _controller.OnMoveEnd.AddListener(StopMoving);
    }

    private void OnDisable()
    {
        _controller.OnMoveStart.RemoveListener(StartMoving);
        _controller.OnMoveEnd.RemoveListener(StopMoving);
    }

    private void StartMoving()
    {
        _animator.SetBool(_isWalk, true);
    }

    private void StopMoving()
    {
        _animator.SetBool(_isWalk, false);
    }
}
