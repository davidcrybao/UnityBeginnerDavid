using UnityEngine;
using UnityEngine.Events;

public class PlayerTank : TankBase
{
    public event UnityAction OnPlayerFire;

    public event UnityAction OnPlayerTakeDamage;

    public event UnityAction OnPlayerLose;

    [SerializeField] private Weapon currentWeapon;

    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform weaponPoint;

    private void Start()
    {
        gameInput.inputActions.Player.Fire.performed += Fire_performed;
    }

    private void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Fire();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, Space.Self);
    }

    public void Rotate()
    {
        float inputFloat = gameInput.GetRotateValue();
        this.transform.Rotate(inputFloat * Vector3.up * bodyRotateSpeed * Time.deltaTime);
    }

    public override void OnDamaged(TankBase other)
    {
        base.OnDamaged(other);
        GameUIPanel.Instance.UpdateHP(maxHealth, currentHealth);
        OnPlayerTakeDamage?.Invoke();
    }

    public override void OnDeath()
    {
        base.OnDeath();
        OnPlayerLose?.Invoke();
    }

    public override void Fire()
    {
        currentWeapon?.Fire(this);
        OnPlayerFire?.Invoke();
    }


    #region ÊôÐÔ½±Àø
    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
    }

    public void UpdateAttack(int amount)
    {

        attack += amount;
    }
    public void UpdateDefence(int amount)
    {

        defence += amount;
    }
    public void UpdateSpeed(int amount)
    { 
    
        moveSpeed+= amount;
    }

    #endregion
    public void SetWeapon(Weapon weapon)
    {
        currentWeapon = Instantiate(weapon, weaponPoint.position, weaponPoint.rotation, weaponPoint);
    }
}