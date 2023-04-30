using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Vector2 _xSpawnRange;
    [SerializeField] private Vector2 _ySpawnRange;

    // We spawn enemy at the start of the game and every time an enemy dies
    private void OnEnable()
    {
        EnemyBehaviour.OnDeath += Spawn;
    }

    private void OnDisable()
    {
        EnemyBehaviour.OnDeath -= Spawn;
    }

    private void Awake()
    {
        Spawn(0);
    }
    
    private void Spawn(int points)
    {
        float xPos = Random.Range(_xSpawnRange.x, _xSpawnRange.y);
        float yPos = Random.Range(_ySpawnRange.x, _ySpawnRange.y);
        Instantiate(_enemy, new Vector2(xPos, yPos), _enemy.gameObject.transform.rotation);
    }
}
