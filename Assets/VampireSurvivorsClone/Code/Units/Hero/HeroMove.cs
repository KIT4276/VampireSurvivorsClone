using UnityEngine;
using Zenject;


public class HeroMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 720f;
    [SerializeField] private CharacterController _characterController;

    private PlayerInput _input;
    private Vector3 _moveWorld;
    private Transform _cameraTransform;

    private bool _isMoving = false;

    public void Init(PlayerInput playerInput) =>
        _input = playerInput;

    private void Awake()
    {
        _input.MovePressed += OnMovePressed;
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (_isMoving)
            Move();
    }

    private void OnDisable() =>
        _input.MovePressed -= OnMovePressed;

    private void Move()
    {
        _moveWorld = CameraRelativeDirection(_input.InputVector);

        _characterController.Move(_moveWorld * _speed * Time.deltaTime);

        if (_moveWorld.sqrMagnitude > 0.0001f)                          //AI
        {
            Quaternion targetRot = Quaternion.LookRotation(_moveWorld, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRot,
                _turnSpeed * Time.deltaTime
            );
        }
    }

    private Vector3 CameraRelativeDirection(Vector2 input)              //AI
    {
        if (_cameraTransform == null)
        {
            Vector3 d = new Vector3(input.x, 0f, input.y);
            return d.sqrMagnitude > 1f ? d.normalized : d;
        }

        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 dir = right * input.x + forward * input.y;
        return dir.sqrMagnitude > 1f ? dir.normalized : dir;
    }

    private void OnMovePressed(bool isMoving) =>
        _isMoving = isMoving;
}
