using System;
using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

public class PlayerInput : IInitializable, ILateDisposable
{
    private Controls _controls;

    public event Action<bool> MovePressed;

    public Vector2 InputVector {  get; private set; }

    public void Initialize()
    {
        _controls = new();
        _controls.Enable();

        _controls.Player.Move.performed += OnMove;
        _controls.Player.Move.canceled += OnMove;
    }

    public void LateDispose()
    {
        _controls.Player.Move.performed -= OnMove;
        _controls.Player.Move.canceled -= OnMove;
        _controls.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        InputVector = ctx.ReadValue<Vector2>();

        MovePressed?.Invoke(InputVector!=Vector2.zero);
    }
}
