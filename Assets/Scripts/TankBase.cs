using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBase : MonoBehaviour
{
    [SerializeField] protected int attack;
    [SerializeField] protected int defence;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int moveSpeed;
    [SerializeField] protected int bodyRotateSpeed;
    [SerializeField] protected int headRotateSpeed;


    public virtual void Fire()
    { }

    public virtual void OnDeath()
    { }

    public virtual void OnDamaged()
    {
    }
}
