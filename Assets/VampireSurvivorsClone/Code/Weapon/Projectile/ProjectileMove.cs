using UnityEngine;

public class ProjectileMove : MonoBehaviour// AI предложил время жизни реализовать здесь,
                                                 // я вынесла в другой класс
{
    [SerializeField] private float _speed = 20f;

     private Vector3 _direction;

    public void SpawnInit(Vector3 worldDirection)
    {
        if (worldDirection.sqrMagnitude < 0.0001f) return;

        _direction = worldDirection.normalized;

        transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);
    }

    private void Update() => 
        transform.position += _direction * _speed * Time.deltaTime;
}
