using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed=3;
    [SerializeField] private float _distance = 5;

    private Transform _target;
    private Vector3 _direction;

    public void SetTarget(Transform target) =>
    _target = target;

    private void Update()
    {
        if (_target == null || Vector3.Distance(_target.position, transform.position ) <= _distance) 
            return;

        transform.LookAt(_target.position);

        _direction = (_target.position - transform.position).normalized;
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
