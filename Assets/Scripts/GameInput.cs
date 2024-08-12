using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    public PlayerInputActions inputActions;
    private void Awake()
    {
        Instance = this;
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
    public float GetRotateValue()
    {

        float inputVector = inputActions.Player.Rotate.ReadValue<float>();

        return inputVector;
    }
}
