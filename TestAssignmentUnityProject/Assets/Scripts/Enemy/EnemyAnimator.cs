using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private EnemyBehaviour _enemyBehaviour;

    private readonly int _isWalk = Animator.StringToHash("isWalk");
    private readonly int _doTouch = Animator.StringToHash("doTouch");
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyBehaviour = GetComponent<EnemyBehaviour>();
        _animator.SetBool(_isWalk, true);
    }

    private void OnEnable()
    {
        _enemyBehaviour.OnBulletHit += OnTouched;
    }

    private void OnDisable()
    {
        _enemyBehaviour.OnBulletHit -= OnTouched;
    }

    private void OnTouched()
    {
        _animator.SetTrigger(_doTouch);
    }
}
