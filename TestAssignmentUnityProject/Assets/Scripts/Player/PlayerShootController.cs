using UnityEngine;
using UnityEngine.Events;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rotationPoint;

    public UnityEvent OnShoot;
    public void Update()
    {
        if (!MenuView.IsPaused)
        {
            RotateTowardsMouse();
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }

    private void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - rotationPoint.position.x, mousePosition.y - rotationPoint.position.y);
        //calculate angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rotate
        rotationPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    private void Shoot()
    {
        Instantiate(bulletPrefab, shootPoint.position, rotationPoint.rotation);
        
        OnShoot.Invoke();
    }
}
