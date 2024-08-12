using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTank : TankBase
{
    public event UnityAction OnPlayerFire;
    public event UnityAction OnPlayerTakeDamage;
    public event UnityAction OnPlayerLose;

    [SerializeField] private GameInput gameInput;
    private void OnEnable()
    {
       
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);
        Debug.Log(inputVector);
        float moveDistance = moveSpeed * Time.deltaTime;
        transform.position += moveDirection * moveDistance;

    }
    public override void OnDamaged(TankBase other)
    {
        base.OnDamaged(other);
        OnPlayerTakeDamage?.Invoke();
    }

    public override void OnDeath()
    {
        base.OnDeath();
        OnPlayerLose?.Invoke();
    }
    public override void Fire()
    {
        OnPlayerFire?.Invoke();
    }
}
