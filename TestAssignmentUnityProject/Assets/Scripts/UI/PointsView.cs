using TMPro;
using UnityEngine;

public class PointsView : MonoBehaviour
{
    private TMP_Text _text;
    private AudioSource _audioSource;
    
    private void OnEnable()
    {
        PlayerController.OnPointsChanged += UpdateText;
        EnemyBehaviour.OnDeath += PlaySound;
    }

    private void OnDisable()
    {
        PlayerController.OnPointsChanged -= UpdateText;
        EnemyBehaviour.OnDeath -= PlaySound;
    }

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void UpdateText(int points)
    {
        _text.text = "Points: " + points;
    }

    private void PlaySound(int points)
    {
        _audioSource.Play();
    }
}
