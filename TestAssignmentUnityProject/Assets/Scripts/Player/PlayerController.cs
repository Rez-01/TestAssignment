using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5f;

    private int _points = 0;

    public UnityEvent OnMoveStart;
    public UnityEvent OnMoveEnd;

    public static Action<int> OnPointsChanged;
    
    public bool IsMoving { get; private set; }

    private void OnEnable()
    {
        EnemyBehaviour.OnDeath += AddPoints;
    }

    private void OnDisable()
    {
        EnemyBehaviour.OnDeath -= AddPoints;
    }

    private void Start()
    {
        OnPointsChanged?.Invoke(0);
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        var direction = new Vector3(horizontal, vertical, 0);
        if(direction.sqrMagnitude > 1f) direction.Normalize();

        var lastMoving = IsMoving;
        IsMoving = direction.sqrMagnitude > 0f;
        
        if(IsMoving && lastMoving != IsMoving) OnMoveStart?.Invoke();
        if(!IsMoving && lastMoving != IsMoving) OnMoveEnd?.Invoke();
        
        transform.Translate(direction * (speed * Time.deltaTime));
        //transform.DOMove(transform.position + direction, .5f);
    }

    private void AddPoints(int points)
    {
        _points += points;
        OnPointsChanged?.Invoke(_points);
    }
}
