using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField] private float _damage;
    private void Update()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out EnemyBehaviour enemyBehaviour))
        {
            enemyBehaviour.TakeDamage(_damage);
            enemyBehaviour.OnBulletHit?.Invoke();
            Destroy(gameObject);
        }
    }
}
