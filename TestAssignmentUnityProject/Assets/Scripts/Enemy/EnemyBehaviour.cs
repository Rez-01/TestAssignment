using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private int _points;
    private Health _health;

    private float _velocity = 2f;
    private Vector2 _movementDirection;
    private Vector2 _movementPerSecond;

    private AudioSource _audioSource;

    public Action OnBulletHit;
    public static Action<int> OnDeath;
    
    private void Awake()
    {
        _health = GetComponent<Health>();
        _audioSource = GetComponent<AudioSource>();
        _health.OnDeath.AddListener(Die);
    }

    private void OnDisable()
    {
        _health.OnDeath.RemoveListener(Die);
    }

    private void Start()
    {
        CalculateNewMovementVector();
    }

    private void Update()
    {
        transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime), 
            transform.position.y + (_movementPerSecond.y * Time.deltaTime));
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
        _audioSource.Play();
    }

    private void CalculateNewMovementVector()
    {
        _movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        _movementPerSecond = _movementDirection * _velocity;
    }

    private void Die()
    {
        OnDeath?.Invoke(_points);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Wall wall))
        {
            CalculateNewMovementVector();
        }
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.TryGetComponent(out Wall wall))
        {
            CalculateNewMovementVector();
        }
    }
}
